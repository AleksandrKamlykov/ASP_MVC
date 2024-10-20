using Microsoft.EntityFrameworkCore;
using ASP_MVC.Models;

namespace ASP_MVC.Data
{
    public class ApplicationContext :DbContext
    {


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
