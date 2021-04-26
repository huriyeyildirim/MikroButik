using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miktobutik.Models.EntityModel;
namespace MikroButik.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<OrnekTablo>().ToTable("OrnekTablo");
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Product>().ToTable("Products");//.HasOne<Category>().WithOne();
            builder.Entity<Photo>().ToTable("Photos");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<User>().ToTable("Users");


            base.OnModelCreating(builder);

        }

        public DbSet<OrnekTablo> OrnekTablo { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
