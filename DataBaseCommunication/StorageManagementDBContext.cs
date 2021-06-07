using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DataBaseCommunication.DBInitializers;
using DataBaseCommunication.Models;

namespace DataBaseCommunication
{
    internal class StorageManagementDBContext: DbContext
    {
        public StorageManagementDBContext(DBInitializer dBInitializer)
        {
            Database.SetInitializer(dBInitializer);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }
    }
}
