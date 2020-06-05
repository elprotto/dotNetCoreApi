using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class Post1Repository : IPostRepository1
    {
        public async Task<IEnumerable<Post1>> GetPost1()
        {
            var post = Enumerable.Range(1, 100).Select(x => new Post1
            {
                PostId = x,
                Description = $"Description {x}",
                Date = DateTime.Now,
                Image = $"https://misapis.{x}",
                UserId = x
            });
            await Task.Delay(5);
            return post;
        }
    }
}
