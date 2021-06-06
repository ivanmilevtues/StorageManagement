using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.DBInitializers;
using Ninject.Modules;

namespace DataBaseCommunication.Ninject
{
    class InitializersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<UserInitializer>().ToSelf();
        }
    }
}
