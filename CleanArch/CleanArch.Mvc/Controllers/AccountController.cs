using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            CheckUser checkUserName = _userService.CheckUserName(register.UserName);
            CheckUser checkEmail = _userService.CheckEmail(register.Email);

            if(checkUserName!= CheckUser.OK || checkEmail != CheckUser.OK)
            {
                ViewBag.Check = checkUserName;
                return View(register);
            }

            User user = new User()
            {
                Email = register.Email.Trim().ToLower(),
                PhoneNumber = register.PhoneNumber.Trim(),
                UserName = register.UserName.ToLower(),
                Password = PasswordHelper.EncodePasswordMd5(register.Password)

            };

            _userService.RegisterUser(user);

            return View("SuccessRegister", register);
        }
    }
}