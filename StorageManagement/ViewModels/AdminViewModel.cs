using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataBaseCommunication.DTO;
using StorageManagement.Commands;
using StorageManagement.Security.Attributes;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class AdminViewModel: AbstractViewModel
    {
        private readonly UserService userService;
        private readonly StateService state;
        private readonly List<UserDTO> _users;
        private Array roles = Enum.GetValues(typeof(RoleDTO));

        private UserDTO _editedUser = new UserDTO();

        private string _filter = "";

        public AdminViewModel(UserService userService, StateService state)
        {
            this.userService = userService;
            this.state = state;
            LoggedUser = state.User;
            _users = userService.GetUsers().ToList();
        }

        public UserDTO LoggedUser { get; set; }

        public string Filter
        { 
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged("Users");
            }
        }

        public Array Roles { get => roles; set => roles = value; }

        public List<UserDTO> Users 
        {
            get
            {
                var filterToken = _filter.ToLower();
                if (filterToken != "")
                {
                    return _users.Where(u => u.Username.ToLower().Contains(filterToken) || u.Role.ToString().ToLower().Contains(filterToken)).ToList();
                }
                else
                {
                    return _users.ToList();
                }
            }
        }

        public UserDTO EditedUser { 
            get => _editedUser; 
            set 
            {
                _editedUser = value;
                OnPropertyChanged("EditedUser");
            }
        }

        public ICommand CreateUserCommand
        {
            get => new PermissionRequiredCommand(CreateUser, state.User.Role);
        }

        public ICommand ResetUserPasswordCommand
        {
            get => new PermissionRequiredCommand(ResetPassword, state.User.Role);
        }

        [PermissionRequired(RoleDTO.Admin)]
        private void CreateUser()
        {
            var newUser = new UserDTO()
            {
                Username = EditedUser.Username,
                Password = EditedUser.Password,
                Role = EditedUser.Role,
            };
            _users.Add(userService.CreateUser(newUser));
            OnPropertyChanged("Users");
        }

        [PermissionRequired(RoleDTO.Admin)]
        private void ResetPassword()
        {
            userService.ResetPassword(EditedUser);
        }
    }
}
