using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostMongoRepository : IPostRepository1
    {
        public async Task<IEnumerable<Post1>> GetPost1()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post1
            {
                PostId = x,
                Description = $"Description Mongo {x}",
                Date = DateTime.Now,
                Image = $"https://misapis.{x}",
                UserId = x
            }); ;
            await Task.Delay(5);
            return posts;
        }
    }
}
