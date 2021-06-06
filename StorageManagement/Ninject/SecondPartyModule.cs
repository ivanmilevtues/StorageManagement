using DataBaseCommunication;
using Ninject.Modules;

namespace StorageManagement.Ninject
{
    class SecondPartyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataFacade>().To<DataFacade>().InSingletonScope();
        }
    }
}
