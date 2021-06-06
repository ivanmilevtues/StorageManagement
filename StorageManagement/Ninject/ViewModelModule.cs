﻿using Ninject.Modules;
using StorageManagement.ViewModels;

namespace StorageManagement.Ninject
{
    class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AdminViewModel>().ToSelf().InSingletonScope();
        }
    }
}
