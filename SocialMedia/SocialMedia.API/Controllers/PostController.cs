﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            // Global filter replace this
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.InsertPost(post);

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, PostDto postDto)
        {
            var currentPost = _mapper.Map<Post>(postDto);
            currentPost.PostId = id;

            var result = await _postRepository.UpdatePost(currentPost);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {

            var result = await _postRepository.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}