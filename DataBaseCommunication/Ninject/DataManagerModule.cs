using DataBaseCommunication.Managers;
using Ninject.Modules;

namespace DataBaseCommunication.Ninject
{
    internal class DataManagerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StorageManagementDBContext>().ToSelf().InSingletonScope();
            Bind<UserDBManager>().ToSelf().InSingletonScope();
        }
    }
}
