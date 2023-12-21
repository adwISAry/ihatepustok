﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using nov30task.Models;
using nov30task.ViewModels.AuthVM;
using Microsoft.AspNetCore.Identity;

namespace nov30task.Controllers
{
    public class AuthController : Controller
    {


        SignInManager<AppUser> _signInManager { get; }
        UserManager<AppUser> _userManager { get; }
        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = new AppUser
            {
                UserName = vm.UserName,
                Email = vm.Email,
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(vm);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(vm);
        }
    }
}