using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataBaseCommunication.DTO;
using DataBaseCommunication.Models;

namespace DataBaseCommunication.Managers
{
    internal class UserDBManager : AbstractDbManager<User, UserDTO>
    {

        public UserDBManager(StorageManagementDBContext dBContext, IMapper dtoMapper) : base(dBContext, dtoMapper) { }

        public UserDTO GetUser(string username)
        {
            var user = dbContext.Users.Where(u => u.Username == username).FirstOrDefault();
            return MapToDTO(user);
        }

        public UserDTO GetUser(string username, string password) {
            var user = dbContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return MapToDTO(user);
        }

        public IEnumerable<UserDTO> GetAll() => dbContext.Users.AsEnumerable().Select(u => MapToDTO(u));

        public UserDTO CreateUser(UserDTO user)
        {
            var newUser = MapToModel(user);
            var userEntity = dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            return MapToDTO(userEntity);
        }

        public UserDTO Update(UserDTO editedUser)
        {
            var userEntity = dbContext.Users.Where(u => u.Username == editedUser.Username).FirstOrDefault();
            userEntity.Password = editedUser.Password;
            userEntity.Username = editedUser.Username;
            userEntity.Role = dtoMapper.Map<RoleDTO, Role>(editedUser.Role);
            dbContext.SaveChanges();

            return editedUser;
        }
    }
}
