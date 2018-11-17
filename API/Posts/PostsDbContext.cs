using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Posts
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }

        private DbSet<Post> Posts { get; set; }

        public List<Post> FindAll()
        {
            return Posts.ToList();
        }
        
        public Post Find(Guid id)
        {
            return Posts.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Post post)
        {
            if(post.Id == Guid.Empty) post.Id = Guid.NewGuid();
            post.CreatedDate = DateTime.Now;
            
            Posts.Add(post);
            SaveChanges();
        }

        public void Update(Post existingPost, Post newPost)
        {            
            existingPost.Title = newPost.Title;
            existingPost.Content = newPost.Content;
            existingPost.Author = newPost.Author;
            existingPost.CreatedDate = newPost.CreatedDate;
            SaveChanges();
        }

        public void Delete(Post post)
        {
            Posts.Remove(post);
            SaveChanges();
        }
    }
}