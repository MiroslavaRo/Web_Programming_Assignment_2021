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
    }
}
