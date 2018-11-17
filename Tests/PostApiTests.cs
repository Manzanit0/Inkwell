using System;
using System.Collections.Generic;
using System.Linq;
using API.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class PostApiTests : IDisposable
    {
        public PostApiTests()
        {
            _dbContext = CreateDbContextWithData();
            _controller = new PostsController(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private readonly PostsDbContext _dbContext;
        private readonly PostsController _controller;

        private List<Post> DbPosts => _dbContext.FindAll();

        private static PostsDbContext CreateDbContextWithData()
        {
            var dbContext = new PostsDbContext(Options);
            dbContext.Insert(new Post {Id = Guid.NewGuid(), Author = "XXX", Title = "YYY", Content = "ZZZ"});
            dbContext.Insert(new Post {Id = Guid.NewGuid(), Author = "XXX", Title = "YYY", Content = "ZZZ"});
            return dbContext;
        }

        private static DbContextOptions<PostsDbContext> Options =>
            new DbContextOptionsBuilder<PostsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

        [Fact]
        public void DeletePost()
        {
            Assert.Equal(2, DbPosts.Count);

            var existingPost = DbPosts.FirstOrDefault();
            var result = _controller.Delete(existingPost.Id) as OkResult;

            Assert.NotNull(result);
            Assert.Equal(1, DbPosts.Count);
            Assert.Null(DbPosts.Find(x => x.Id == existingPost.Id));
        }
        
        [Fact]
        public void DeleteWithInvalidIdReturnsNotFound()
        {
            var result = _controller.Delete(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }

        [Fact]
        public void GetReturnsAllRecords()
        {
            var result = _controller.Get() as OkObjectResult;
            var posts = result.Value as List<Post>;

            Assert.Equal(2, posts.Count);
        }

        [Fact]
        public void GetWithIdReturnsCorrectRecord()
        {
            var result = _controller.Get(DbPosts[0].Id) as OkObjectResult;
            var post = result.Value as Post;

            Assert.Equal(DbPosts[0].Id, post.Id);
        }

        [Fact]
        public void GetWithInvalidIdReturnsNotFound()
        {
            var result = _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }

        [Fact]
        public void PostCreatesNewRecord()
        {
            Assert.Equal(2, DbPosts.Count);

            var result = _controller.Post(new Post()) as CreatedResult;
            var post = result.Value as Post;

            Assert.Equal(3, DbPosts.Count);
            Assert.Equal(1, DbPosts.FindAll(x => x.Id == post.Id).Count);
            Assert.Equal($"/posts/{post.Id}", result.Location);
        }

        [Fact]
        public void PutCreatesNewRecord()
        {
            Assert.Equal(2, DbPosts.Count);

            var result = _controller.Put(Guid.NewGuid(), new Post()) as CreatedResult;
            var post = result.Value as Post;

            Assert.Equal(3, DbPosts.Count);
            Assert.Equal(1, DbPosts.FindAll(x => x.Id == post.Id).Count);
            Assert.Equal($"/posts/{post.Id}", result.Location);
        }

        [Fact]
        public void PutOverridesExistingRecord()
        {
            Assert.Equal(2, DbPosts.Count);

            var existingPost = DbPosts.FirstOrDefault();
            existingPost.Title = "Changed Title";

            var result = _controller.Put(existingPost.Id, existingPost) as OkObjectResult;
            var post = result.Value as Post;

            Assert.Equal(2, DbPosts.Count);
            Assert.Equal("Changed Title", DbPosts.Find(x => x.Id == post.Id).Title);
        }

        [Fact]
        public void PutReturnsBadRequestUponIdMismatch()
        {
            var result = _controller.Put(Guid.NewGuid(), new Post {Id = Guid.NewGuid()});

            Assert.True(result is BadRequestObjectResult);
            Assert.Equal(2, DbPosts.Count);
        }
    }
}