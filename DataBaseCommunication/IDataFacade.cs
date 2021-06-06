using System;
using DataBaseCommunication.Models;

namespace DataBaseCommunication
{
    public interface IDataFacade
    {
        User GetUser(string username, String password);
    }
}
