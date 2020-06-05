using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Post1Controller : ControllerBase
    {
        private readonly IPostRepository1 _postRepository1; 
        public Post1Controller(IPostRepository1 postRepository1)
        {
            _postRepository1 = postRepository1;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts1()
        {
            var post1 = await _postRepository1.GetPost1();

            return Ok(post1);
        }
    }
}