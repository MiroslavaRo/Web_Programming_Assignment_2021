﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_Programming_Assignment_2021.DataEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Web_Programming_Assignment_2021.Data
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