using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API.Posts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostsDbContext _context;

        public PostsController(PostsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Posts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var post = _context.GetPost(id);
            if (post == null) return NotFound();
            
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            _context.InsertPost(post);
            return Created($"/posts/{post.Id}", post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Post post)
        {
            if (post.Id == Guid.Empty) post.Id = id;
            else if (post.Id != id) return BadRequest("The Id of the body doesn't match the URI.");
            
            var existingPost = _context.GetPost(post.Id);
            if (existingPost == null)
            {
                _context.InsertPost(post);
                return Created($"/posts/{post.Id}", post);
            }

            _context.Update(existingPost, post);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _context.DeletePost(id);
            return Ok();
        }
    }
}