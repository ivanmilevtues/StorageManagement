namespace DataBaseCommunication.Managers
{
    abstract internal class AbstractDbManager
    {
        protected StorageManagementDBContext dbContext;

        public AbstractDbManager(StorageManagementDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
    }
}
