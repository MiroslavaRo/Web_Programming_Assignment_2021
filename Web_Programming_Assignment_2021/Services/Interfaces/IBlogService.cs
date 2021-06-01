using Web_Programming_Assignment_2021.Models.Blog;
using System.Collections.Generic;

namespace Web_Programming_Assignment_2021.Services.Interfaces
{
    public interface IBlogService
    {
        List<PostViewModel> GetPosts();

        PostViewModel GetPost(int Id);

        bool UpdatePost(PostViewModel postViewModel);

        List<CategoryViewModel> GetCategories();

        CategoryViewModel GetCategory(int Id);

        bool UpdateCategory(CategoryViewModel categoryViewModel);
    }
}