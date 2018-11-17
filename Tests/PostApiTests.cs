using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using API.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class PostApiTests
    {
        [Fact]
        public void GetReturnsAllRecords()
        {
            var dbContext = CreateDbContextWithData();
            var controller = new PostsController(dbContext);

            var result = controller.Get() as OkObjectResult;
            var posts = result.Value as List<Post>;
            
            Assert.Equal(2, posts.Count);
        }
        
        [Fact]
        public void GetWithIdReturnsCorrectRecord()
        {
            var dbContext = CreateDbContextWithData();
            var controller = new PostsController(dbContext);
            var posts = dbContext.Posts.ToList();
            
            var result = controller.Get(posts[0].Id) as OkObjectResult;
            var post = result.Value as Post;
            
            Assert.Equal(posts[0].Id, post.Id);
        }
        
        [Fact]
        public void PostCreatesNewRecord()
        {
            var dbContext = CreateDbContextWithData();
            Assert.Equal(2, dbContext.Posts.ToList().Count);
            
            var controller = new PostsController(dbContext);
                       
            var result = controller.Post(new Post()) as CreatedResult;
            var post = result.Value as Post;

            var posts = dbContext.Posts.ToList();
            Assert.Equal(3, posts.Count);
            Assert.Equal(1, posts.FindAll(x => x.Id == post.Id).Count);
            Assert.Equal($"/posts/{post.Id}", result.Location);
        }
        
        [Fact]
        public void PutCreatesNewRecord()
        {
            var dbContext = CreateDbContextWithData();
            Assert.Equal(2, dbContext.Posts.ToList().Count);
            
            var controller = new PostsController(dbContext);
            
            var result = controller.Put(Guid.NewGuid(), new Post()) as CreatedResult;
            var post = result.Value as Post;

            var posts = dbContext.Posts.ToList();           
            Assert.Equal(3, posts.Count);
            Assert.Equal(1, posts.FindAll(x => x.Id == post.Id).Count);
            Assert.Equal($"/posts/{post.Id}", result.Location);
        }
        
        [Fact]
        public void PutOverridesExistingRecord()
        {
            var dbContext = CreateDbContextWithData();
            Assert.Equal(2, dbContext.Posts.ToList().Count);                        

            var existingPost = dbContext.Posts.FirstOrDefault();
            existingPost.Title = "Changed Title";
            
            var controller = new PostsController(dbContext);
            var result = controller.Put(existingPost.Id, existingPost) as OkObjectResult;
            var post = result.Value as Post;

            var posts = dbContext.Posts.ToList();           
            Assert.Equal(2, posts.Count);         
            Assert.Equal("Changed Title", posts.Find(x => x.Id == post.Id).Title);
        }

        [Fact]
        public void PutReturnsBadRequestUponIdMismatch()
        {
            var dbContext = CreateDbContextWithData();            
            var controller = new PostsController(dbContext);
            var result = controller.Put(Guid.NewGuid(), new Post {Id = Guid.NewGuid() }) as BadRequestObjectResult;

            Assert.NotNull(result);
            
            var posts = dbContext.Posts.ToList();           
            Assert.Equal(2, posts.Count);
        }
        
        [Fact]
        public void DeletePost()
        {
            var dbContext = CreateDbContextWithData();
            Assert.Equal(2, dbContext.Posts.ToList().Count);                        

            var existingPost = dbContext.Posts.FirstOrDefault();

            var controller = new PostsController(dbContext);
            var result = controller.Delete(existingPost.Id) as OkResult;
            
            Assert.NotNull(result);

            var posts = dbContext.Posts.ToList();           
            Assert.Equal(1, posts.Count);         
            Assert.Null(posts.Find(x => x.Id == existingPost.Id));
        }
        
        private static PostsDbContext CreateDbContextWithData()
        {
            var dbContext = new PostsDbContext(Options);
            dbContext.Posts.Add(new Post { Id = Guid.NewGuid(), Author = "XXX", Title = "YYY", Content = "ZZZ" });
            dbContext.Posts.Add(new Post { Id = Guid.NewGuid(), Author = "XXX", Title = "YYY", Content = "ZZZ" });
            dbContext.SaveChanges();            
            return dbContext;
        }

        private static DbContextOptions<PostsDbContext> Options =>
            new DbContextOptionsBuilder<PostsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()                
                .Options;
    }
}