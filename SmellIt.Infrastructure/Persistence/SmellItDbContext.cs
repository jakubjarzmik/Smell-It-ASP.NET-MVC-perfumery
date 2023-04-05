﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;

namespace SmellIt.Infrastructure.Persistence
{
    public class SmellItDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<FragranceGroup> FragranceGroups { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JJERZUPC;Database=SmellItDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedAddresses)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Address>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedAddresses)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Address>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedAddresses)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Brand>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedBrands)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Brand>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedBrands)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Brand>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedBrands)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FragranceGroup>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedFragranceGroups)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceGroup>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedFragranceGroups)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FragranceGroup>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedFragranceGroups)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gender>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedGenders)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Gender>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedGenders)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Gender>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedGenders)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedProducts)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedProducts)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProducts)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedProductCategories)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedProductCategories)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProductCategories)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedProductImages)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedProductImages)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductImage>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedProductImages)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CreatedBy)
                .WithMany(u=>u.CreatedUsers)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(u => u.ModifiedBy)
                .WithMany(u=>u.ModifiedUsers)
                .HasForeignKey(u => u.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.DeletedUsers)
                .HasForeignKey(u => u.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
