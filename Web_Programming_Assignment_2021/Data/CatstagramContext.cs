using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Models;

namespace Web_Programming_Assignment_2021.Data
{
    public class CatstagramContext : DbContext
    {
        public CatstagramContext(DbContextOptions<CatstagramContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                  .HasData(new User
                  {
                      UserId = 1,
                      Username = "_Cutie_34",
                      Password = "PaS_S",
                      Email = "katrin@gmail.com",
                      AvatarFile = "flower.jpg"
                  });
            modelBuilder.Entity<User>()
               .HasData(new User
               {
                   UserId = 2,
                   Username = "LolitaKit",
                   Password = "Ger34_",
                   Email = "lolita_hanta@gmail.com",
                   AvatarFile = "beautiful.jpg"
               });


            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    PostId=1,
                    Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Hashtag = "#cute #cutie #kitty",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    PhotoFile = "cute.jpg",
                    UserId = 1
                });
            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    PostId=2,
                    Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Hashtag = "#cute #happy",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    PhotoFile = "flower.jpg",
                    UserId = 1
                });;
            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    PostId=3,
                    Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Hashtag = "#kitty",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    PhotoFile = "beautiful.jpg",
                    UserId = 2
                });


        }
    }
        
}
