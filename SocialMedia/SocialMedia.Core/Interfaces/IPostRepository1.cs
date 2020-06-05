using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository1
    {
        Task<IEnumerable<Post1>> GetPost1();
    }
}
