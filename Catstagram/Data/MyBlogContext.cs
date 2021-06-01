using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Catstagram.DataEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Catstagram.Data
{
    public class MyBlogContext : IdentityDbContext<User>
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}