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
        public IEnumerable<Post> Get()
        {
            return _context.Posts.ToList();
        }

        [HttpGet("{id}")]
        public Post Get(Guid id)
        {
            return _context.GetPost(id);
        }

        [HttpPost]
        public void Post([FromBody] Post post)
        {
            _context.InsertPost(post);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Post value)
        {
            // Just in case the user of the API puts the Id in the url but not in the body.
            if (value.Id.Equals(new Guid())) value.Id = id;
            
            _context.UpsertPost(value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _context.DeletePost(id);
        }
    }
}