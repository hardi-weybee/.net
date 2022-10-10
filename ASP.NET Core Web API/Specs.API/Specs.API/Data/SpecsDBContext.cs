using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpecsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecsAPI.Data
{
    public class SpecsDBContext : IdentityDbContext<ApplicationUser>
    {
        public SpecsDBContext(DbContextOptions<SpecsDBContext> options)
            : base(options)
        {

        }

        public DbSet<Specss> Specs { get; set; }


    }
}
