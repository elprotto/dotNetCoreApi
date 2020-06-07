using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        //private readonly IPostRepository _postRepository;
        //private readonly IUserRepository _userRepository;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        public PostService(IRepository<Post> postRepository, IRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return true;
        }

        public async Task<Post> GetPost(int id)
        {

            return await _postRepository.GetById(id);
        }

        public async  Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
            var user = await _userRepository.GetById(post.UserId);
            //First Businnes Rule Validation
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("sexo"))
            {
                throw new Exception("Content not Allowed");
            }
            await _postRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _postRepository.Update(post);
            return true;
        }
    }
}
