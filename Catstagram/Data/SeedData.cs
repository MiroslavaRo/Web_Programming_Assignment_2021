using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Catstagram.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyBlogContext(serviceProvider.GetRequiredService<DbContextOptions<MyBlogContext>>()))
            {
                // Uncomment line below if you need to recreate your data
                //context.Posts.RemoveRange(context.Posts);
                //context.SaveChanges();
                //context.Categories.RemoveRange(context.Categories);
                //context.SaveChanges();

                // Look for any movies.
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            Title = "Web"
                        },

                        new Category
                        {
                            Title = "Design"
                        },

                        new Category
                        {
                            Title = "Branding"
                        },

                        new Category
                        {
                            Title = "Photography"
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    var category = context.Categories.First();

                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Work Single Page 1",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_1.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 2",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_1.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 3",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_2.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 4",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_3.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 5",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_3.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 6",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_4.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 7",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_5.jpg"
                        },

                        new Post
                        {
                            Title = "Work Single Page 8",
                            SubTitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            CategoryId = category.Id,
                            Photo = "img_6.jpg"
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}