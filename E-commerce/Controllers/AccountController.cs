﻿using E_commerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser>
        signInManager;
        public AccountController(UserManager<IdentityUser>
        userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign the user to the "Customer" role by default
                    await userManager.AddToRoleAsync(user, "User");

                    // Sign in the user
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet
]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost
        ]
        public async Task <IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if
            (ModelState.IsValid
            )
            {
                var result = await signInManager.PasswordSignInAsync
                (model.Email
                ,
                model.Password, model.RememberMe, false);
                if
                (result.Succeeded
                )
                {
                    if (!string.IsNullOrEmpty
                    (returnUrl))
                    {
                        return LocalRedirect
                        (returnUrl);
                    }
                    else
                    {
                        return RedirectToAction
                        ("Index", "Home");
                    }
                }
                ModelState.AddModelError
                (string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
    }
}
