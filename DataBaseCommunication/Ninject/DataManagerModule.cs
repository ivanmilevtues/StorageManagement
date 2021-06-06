﻿using AutoMapper;
using DataBaseCommunication.DTO;
using DataBaseCommunication.Managers;
using DataBaseCommunication.Models;
using Ninject.Modules;

namespace DataBaseCommunication.Ninject
{
    internal class DataManagerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateDTOMapper());
            Bind<StorageManagementDBContext>().ToSelf().InSingletonScope();
            Bind<UserDBManager>().ToSelf().InSingletonScope();
        }

        private IMapper CreateDTOMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
