using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;
using DataBaseCommunication.DBInitializers;
using DataBaseCommunication.Models;

namespace DataBaseCommunication
{
    internal class StorageManagementDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

        public StorageManagementDBContext(DBInitializer dBInitializer): base("StorageManagement")
        {
            Database.SetInitializer(dBInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithMany(p => p.ProductCategories)
                .Map(ppc =>
                {
                    ppc.MapLeftKey("ProductRefId");
                    ppc.MapRightKey("ProductCategoryRefId");
                    ppc.ToTable("ProductCategoryProduct");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
