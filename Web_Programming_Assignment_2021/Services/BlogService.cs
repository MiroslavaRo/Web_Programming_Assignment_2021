using Web_Programming_Assignment_2021.Data;
using Web_Programming_Assignment_2021.DataEntities;
using Web_Programming_Assignment_2021.Models.Blog;
using Web_Programming_Assignment_2021.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web_Programming_Assignment_2021.Services
{
    public class BlogService : IBlogService
    {
        private readonly MyBlogContext blogContext;

        public BlogService(MyBlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public List<CategoryViewModel> GetCategories()
        {
            return blogContext
                .Categories
                .OrderBy(c => c.Title)
                .Select(c => new CategoryViewModel { Id = c.Id, Title = c.Title })
                .ToList();
        }

        public CategoryViewModel GetCategory(int Id)
        {
            return blogContext
                .Categories
                .Where(c => c.Id == Id)
                .Select(c => new CategoryViewModel { Id = c.Id, Title = c.Title })
                .FirstOrDefault();
        }

        public bool UpdateCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                Category category = new Category();

                if (categoryViewModel.Id > 0)
                {
                    // Get existing category
                    category = blogContext.Categories.Where(p => p.Id == categoryViewModel.Id).FirstOrDefault();
                }
                else
                {
                    // Add new category
                    blogContext.Categories.Add(category);
                }

                // Update category details
                category.Title = categoryViewModel.Title;

                blogContext.SaveChanges();

                categoryViewModel.Id = category.Id;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<PostViewModel> GetPosts()
        {
            return blogContext
                .Posts
                .Select(p =>
                    new PostViewModel
                    {
                        Id = p.Id,
                        CategoryId = p.CategoryId,
                        CategoryTitle = p.Category.Title,
                        Content = p.Content,
                        DateCreated = p.DateCreated,
                        DateModified = p.DateModified,
                        Photo = p.Photo,
                        SubTitle = p.SubTitle,
                        Title = p.Title
                    }
                    )
                .ToList();
        }

        public PostViewModel GetPost(int Id)
        {
            return blogContext
                .Posts
                .Where(p => p.Id == Id)
                .Select(p =>
                    new PostViewModel
                    {
                        Id = p.Id,
                        CategoryId = p.CategoryId,
                        CategoryTitle = p.Category.Title,
                        Content = p.Content,
                        DateCreated = p.DateCreated,
                        DateModified = p.DateModified,
                        Photo = p.Photo,
                        SubTitle = p.SubTitle,
                        Title = p.Title
                    }
                    )
                .FirstOrDefault();
        }

        public bool UpdatePost(PostViewModel postViewModel)
        {
            try
            {
                Post post = new Post();

                if (postViewModel.Id > 0)
                {
                    // Get existing post
                    post = blogContext.Posts.Where(p => p.Id == postViewModel.Id).FirstOrDefault();
                }
                else
                {
                    // Add new post
                    blogContext.Posts.Add(post);
                    post.DateCreated = DateTime.Now;
                }

                // Update post details
                post.CategoryId = postViewModel.CategoryId;
                post.Content = postViewModel.Content;
                post.DateModified = DateTime.Now;
                post.SubTitle = postViewModel.SubTitle;
                post.Title = postViewModel.Title;

                if (postViewModel.PhotoFile != null)
                {
                    post.Photo = postViewModel.Photo;
                }

                blogContext.SaveChanges();

                postViewModel.Id = post.Id;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}