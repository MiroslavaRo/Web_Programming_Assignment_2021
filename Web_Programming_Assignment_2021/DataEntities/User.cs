using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programming_Assignment_2021.DataEntities
{
    public class User : IdentityUser
    {
        public string StupidProperty { get; set; }
    }
}