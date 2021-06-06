using Ninject.Modules;
using StorageManagement.Services;

namespace StorageManagement.Ninject
{
    class ServicesModule : NinjectModule
    {

        public override void Load()
        {
            Bind<UserService>().ToSelf().InSingletonScope();
            Bind<StateService>().ToSelf().InSingletonScope();
        }
    }
}
