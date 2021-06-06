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
        public StorageManagementDBContext(UserInitializer userInitializer)
        {
            Database.SetInitializer(userInitializer);
        }
        public DbSet<User> Users { get; set; }
    }
}
