﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using DataBaseCommunication.DTO;
using StorageManagement.Commands;
using StorageManagement.Security.Attributes;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private readonly UserService userService;
        private readonly StateService state;
        private readonly List<UserDTO> _users;

        public event PropertyChangedEventHandler PropertyChanged;

        private Array roles = Enum.GetValues(typeof(RoleDTO));

        private UserDTO _editedUser = new UserDTO();

        private string _filter = "";

        public AdminViewModel(UserService userService, StateService state)
        {
            this.userService = userService;
            this.state = state;
            _users = userService.GetUsers().ToList();
        }

        public string Filter
        { 
            get => _filter;
            set
            {
                _filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Users)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditedUser)));
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
            _users.Add(userService.CreateUser(EditedUser));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Users)));
        }

        [PermissionRequired(RoleDTO.Admin)]
        private void ResetPassword()
        {
            userService.ResetPassword(EditedUser);
        }
    }
}