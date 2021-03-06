using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Services;
using SocialMedia.Infraestructure.Data;
using SocialMedia.Infraestructure.Filters;
using SocialMedia.Infraestructure.Repositories;
using System;

namespace SocialMedia.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(
                    options => {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    }
                )
                .ConfigureApiBehaviorOptions(options => {
                    //options.SuppressModelStateInvalidFilter = true;
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Connection string linked to dbContext
            services.AddDbContext<SocialMediaContext>(
                options => options.UseSqlServer(
                        Configuration.GetConnectionString("SocialMedia")
                    )
                );

            //Dependencies
            services.AddTransient<IPostRepository1,Post1Repository>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUnitOfWork, UnitOfWorkRepository>();


            //Reeplazados por el Irepository
            //services.AddTransient<IPostRepository, PostRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();

            // Scope Dependencies
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


            //Filters a nivel global de Modelos
            services.AddMvc(
                options =>
                {
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(// Se registran los validators
                    options => {
                        options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
