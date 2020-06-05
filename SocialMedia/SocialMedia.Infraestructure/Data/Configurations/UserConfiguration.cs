using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infraestructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .HasColumnName("IdUsuario");

            builder.Property(e => e.IsActive)
                .HasColumnName("Activo");

            builder.Property(e => e.Lastname)
                .HasColumnName("Apellidos")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Birthdate)
                .HasColumnName("FechaNacimiento")
                .HasColumnType("date");

            builder.Property(e => e.Firstname)
                .HasColumnName("Nombres")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNumber)
                .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
