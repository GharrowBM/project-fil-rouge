﻿using System;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilRouge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IRepository<Post> _postRepository;

        public PostController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        // GET: api/<APIController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Post postToGet = _postRepository.Get(id);

            if (postToGet != null)
            {
                return Ok(postToGet);
            }

            return NotFound(new {Message = "Cannot GET this post..."});
        }

        // POST api/<APIController>
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            if (_postRepository.Add(post))
            {
                return Ok(new {Message=$"{post.Title} successfully added to database!"});    
            }
            
            return NotFound(new {Message=$"{post.Title} cannot be added to database..."});
            
            
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            Post postToEdit = _postRepository.Get(id);

            if (postToEdit != null)
            {
                postToEdit.Title = post.Title;
                postToEdit.Content = post.Content;
                postToEdit.EditedAt = DateTime.Now;
                postToEdit.Score = post.Score;
                postToEdit.Answers = post.Answers;
                postToEdit.Tags = post.Tags;
                
                if (_postRepository.Update(id, postToEdit))
                {
                    return Ok(new {Message = $"{post.Title} modified with success!"});
                }
            }
            
            return NotFound(new {Message = $"{post.Title} cannot be modified..."});
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_postRepository.Delete(id))
            {
                return Ok(new {Message = "Post " + id + " deleted with success!"});
            }

            return NotFound(new {Message = "Post" + id + " cannot be deleted..."});
        }
    }
}