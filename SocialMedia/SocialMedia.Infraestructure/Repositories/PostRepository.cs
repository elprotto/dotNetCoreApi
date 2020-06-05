using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostRepository : IPostInterface
    {
        public Task<IEnumerable<Post>> GetPost()
        {
            
        }
    }
}
