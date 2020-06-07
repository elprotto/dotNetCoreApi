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
        //Replaced by Irepository
        //private readonly IPostRepository _postRepository;
        //private readonly IUserRepository _userRepository;

        //Replaced By UnitOfWork
        //private readonly IRepository<Post> _postRepository;
        //private readonly IRepository<User> _userRepository;

        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
   
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }

        public async Task<Post> GetPost(int id)
        {

            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async  Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            //First Businnes Rule Validation
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("sexo"))
            {
                throw new Exception("Content not Allowed");
            }
            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }
    }
}
