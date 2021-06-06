using System.Data.Entity.Migrations;

namespace DataBaseCommunication.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseCommunication.StorageManagementDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataBaseCommunication.StorageManagementDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
