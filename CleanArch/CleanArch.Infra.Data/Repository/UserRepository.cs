using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private UniversityDBContext _context;

        public UserRepository(UniversityDBContext context)
        {
            this._context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool IsExistEmail(string email)
        {
          return  _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
