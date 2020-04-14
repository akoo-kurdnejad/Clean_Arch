using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        bool IsExistEmail(string email);
        bool IsExistUserName(string username);
        bool IsExist(string email, string password);
        void Save();
    }
}
