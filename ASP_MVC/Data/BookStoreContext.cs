using ASP_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASP_MVC.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { 
        Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
