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
            if (item!= null)
            {
                Posts.Remove(item);
                SaveChanges();
            }
        }

        public void InsertPost(Post post)
        {
            post.Id = Guid.NewGuid();
            post.CreatedDate = DateTime.Now;
            
            Posts.Add(post);
            SaveChanges();
        }
    
        public void UpsertPost(Post post)
        {
            var existingPost = GetPost(post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.Author = post.Author;
                existingPost.CreatedDate = post.CreatedDate;
                SaveChanges();
            }
            else
            {
                InsertPost(post);
            }
        }
    }
}