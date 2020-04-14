using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public CheckUser CheckEmail(string email)
        {
            bool EmailValid = _userRepository.IsExistEmail(email);

            if (EmailValid)
                return CheckUser.EmailNotValid;

            return CheckUser.OK;
        }

        public CheckUser CheckUserName(string userName)
        {
            bool UserNameValid = _userRepository.IsExistUserName(userName);

            if (UserNameValid)
                return CheckUser.UserNameNotValid;

            return CheckUser.OK;
        }

        public bool IsExist(string email, string password)
        {
            return _userRepository.IsExist(email.Trim().ToLower(), PasswordHelper.EncodePasswordMd5(password));
        }

        public int RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.Save();
            return user.UserId;
        }
    }
}
