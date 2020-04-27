using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Create Author
                Console.WriteLine("Inserting a new author");
                db.Add(new Author { Name = "Marian", FirstName="Melnychuk" });
                db.SaveChanges();

                // Read Author
                Console.WriteLine("Querying for a author");
                var author = db.Authors
                    .OrderBy(b => b.AuthorId)
                    .First();

                // Update Author
                Console.WriteLine("Updating the author and adding a post");
                author.FirstName = "Petrov";
                author.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                // Read Author
                Console.WriteLine("Querying for a author");
                var post = author.Posts
                    .OrderBy(b => b.PostId)
                    .First();

                //Update Post
                Console.WriteLine("Updating the post and adding a comment");
                post.Comments.Add(
                    new Comment
                    {
                        Content = "The best comment ever!",
                        AuthorId = author.AuthorId
                    });
                db.SaveChanges();

                // Delete Author
                Console.WriteLine("Delete the author");
                db.Remove(author);
                db.SaveChanges();
            }
        }
    }
}