using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string ProfilePhoto { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Comment> Comments { get; } = new List<Comment>();
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}