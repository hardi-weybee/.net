using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specss.API.Data
{
    public class SpecsContext : DbContext
    {
        public SpecsContext(DbContextOptions<SpecsContext> options)
            : base(options)
        {

        }

        public DbSet<Specs> Specs { get; set; }


    }
}
