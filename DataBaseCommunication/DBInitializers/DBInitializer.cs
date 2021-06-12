using System.Data.Entity;

namespace DataBaseCommunication.DBInitializers
{
    class DBInitializer : DropCreateDatabaseIfModelChanges<StorageManagementDBContext>
    {
        private readonly ISeed[] seeds;

        public DBInitializer(ISeed[] seeds)
        {
            this.seeds = seeds;
        }

        protected override void Seed(StorageManagementDBContext context)
        {
            foreach(var seed in seeds)
            {
                seed.AddToSeed(ref context);
            }

            base.Seed(context);
        }
    }
}
