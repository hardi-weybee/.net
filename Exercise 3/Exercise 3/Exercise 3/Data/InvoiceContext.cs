using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options)
        {

        }

        public DbSet<Party> Party { get; set; }        

        public DbSet<Product> Product { get; set; }

        public DbSet<AssignParty> AssignParty { get; set; }

        public DbSet<ProductRate> ProductRate { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Party>().HasIndex(x => new { x.PartyName }).IsUnique(true);
            mb.Entity<Product>().HasIndex(x => new { x.ProductName }).IsUnique(true);
        }
    }
}
