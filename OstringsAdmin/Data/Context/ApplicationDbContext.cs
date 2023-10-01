using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using OstringsAdmin.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using Ostrings.Data.Models;

namespace Ostrings.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductLocation>().HasKey(g => new { g.LocationId, g.ProductId });

            builder.Entity<ProductLocation>()
                .HasOne(g => g.Product)
                .WithMany(g => g.ProductLocations)
                .HasForeignKey(d => d.ProductId);

            builder.Entity<ProductLocation>()
                .HasOne(g => g.Location)
                .WithMany(g => g.ProductLocations)
                .HasForeignKey(g => g.LocationId);

            builder.Entity<SubcategoryProduct>().HasKey(g => new { g.SubcategoryId, g.ProductId });

            builder.Entity<SubcategoryProduct>()
                .HasOne(g => g.Product)
                .WithMany(g => g.Subcategories)
                .HasForeignKey(d => d.ProductId);

            builder.Entity<SubcategoryProduct>()
                .HasOne(g => g.Subcategory)
                .WithMany(g => g.Products)
                .HasForeignKey(g => g.SubcategoryId);

            builder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Subcategory>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<ProductImage>().HasQueryFilter(p => !p.Product.IsDeleted);
            builder.Entity<Provider>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Location>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Address>().HasQueryFilter(p => !p.IsDeleted);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SubcategoryProduct> SubcategoryProducts { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryEntry> InventoryEntries { get; set; }
        public DbSet<ProviderPayment> ProviderPayment { get; set; }
        public DbSet<ProductLocation> ProductLocations { get; set; }
    }
}
