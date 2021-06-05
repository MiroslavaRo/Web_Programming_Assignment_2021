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
                      AvatarFile = "flower.jpg",
                      Status= "Love my life 😍"
                  });

            modelBuilder.Entity<User>()
               .HasData(new User
               {
                   UserId = 2,
                   Username = "LolitaKit",
                   Password = "Ger34_",
                   Email = "lolita_hanta@gmail.com",
                   AvatarFile = "vdct5dfk.jpg",
                   Status= "Artist/Illustrator/Commissions Opened 💖"
               });
            modelBuilder.Entity<User>()
              .HasData(new User
              {
                  UserId = 3,
                  Username = "FunnyTom",
                  Password = "ToMik",
                  Email = "thomasLi@gmail.com",
                  AvatarFile = null,
                  Status=null
              });

            
            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    PostId=1,
                    Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Hashtag =  "#cute #cutie #kitty #pretty" ,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    PhotoFile = "img2.jpg",
                    UserId = 1
                });
            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    PostId=2,
                    Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Hashtag =  "#cute #happy" ,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    PhotoFile = "flower.jpg",
                    UserId = 1
                });
            modelBuilder.Entity<Post>()
                .HasData(
                new Post
                {
                    PostId=3,
                    Comment = "Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Hashtag =  "#kitty" ,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    PhotoFile = "beautiful.jpg",
                    UserId = 2
                });
            modelBuilder.Entity<Post>()
               .HasData(
               new Post
               {
                   PostId = 4,
                   Comment = "Ipsum dolor sit amet consectetur adipisicing elit.",
                   Hashtag = "#smile #happy",
                   DateCreated = DateTime.UtcNow,
                   DateModified = DateTime.UtcNow,
                   PhotoFile = "smile.jpg",
                   UserId = 3
               });



        }
    }
        
}
