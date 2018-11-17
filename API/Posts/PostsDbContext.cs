using System;
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

        public DbSet<Post> Posts { get; set; }
        
        public Post GetPost(Guid id)
        {
            return Posts.FirstOrDefault(x => x.Id == id);
        }

        public void DeletePost(Guid id)
        {
            var item = GetPost(id);
            if (item != null)
            {
                Posts.Remove(item);
                SaveChanges();
            }
        }

        public void InsertPost(Post post)
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
    }
}