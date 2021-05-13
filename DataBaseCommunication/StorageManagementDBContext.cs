using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using DataBaseCommunication.Models;

namespace DataBaseCommunication
{
    class StorageManagementDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
