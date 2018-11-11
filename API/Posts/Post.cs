using System;
using System.ComponentModel.DataAnnotations;

namespace API.Posts
{
    public class Post
    {
        [Key] public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}