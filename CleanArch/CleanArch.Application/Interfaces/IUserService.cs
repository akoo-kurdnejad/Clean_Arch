using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        CheckUser CheckUserName(string userName);
        CheckUser CheckEmail(string email);
        bool IsExist(string email, string password);
        int RegisterUser(User user);
    }
}
