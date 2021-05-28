using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Models;

namespace Web_Programming_Assignment_2021.Data
{
    public static class CatstagramData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CatstagramContext(serviceProvider.GetRequiredService<DbContextOptions<CatstagramContext>>()))
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                       new User
                       {
                           UserId=1,
                           Username="_Cutie_34",
                           Password="PaS_S",
                           Email="katrin@gmail.com",
                           Avatar=null
                       },
                        new User
                        {
                            UserId = 2,
                            Username = "LolitaKit",
                            Password = "Ger34_",
                            Email = "lolita_hanta@gmail.com",
                            Avatar="pic_1.jpg"
                        }

                   );

                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Hashtag ="#cute #cutie #kitty",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            Photo = "img_1.jpg",
                            UserId=1
                        },
                          new Post
                          {
                              Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                              Hashtag = "#cute #happy",
                              DateCreated = DateTime.Now,
                              DateModified = DateTime.Now,
                              Photo = "img_2.jpg",
                              UserId = 1
                          },
                            new Post
                            {
                                Comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                                Hashtag = "#kitty",
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now,
                                Photo = "img_3.jpg",
                                UserId = 2
                            }

                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
