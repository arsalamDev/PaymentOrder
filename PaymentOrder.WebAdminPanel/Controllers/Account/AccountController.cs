using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaymentOrder.Core.Domain.Entities.Auth;
using PaymentOrder.WebAdminPanel.Models.Auth;

namespace PaymentOrder.WebAdminPanel.Controllers.Auth
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AuthEntity> userManager;
        private readonly SignInManager<AuthEntity> signInManager;
        public AccountController(UserManager<AuthEntity> userManager, SignInManager<AuthEntity> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            //var user = userManager.FindByNameAsync(model.Email).Result;
            //if(user == null)
            //{
            //    return Content("Username or password is incorrect");
            //}

            //var signInResult = signInManager.PasswordSignInAsync(user, model.Password, true, false).Result;

            //if (signInResult.Succeeded)
            //    return RedirectToAction("Index", "Employees");

            //return Content("Username or password is incorrect");



                var user = userManager.FindByNameAsync(model.Email).Result;
                if (user == null)
                {
                    return View(model);
                }


                var signInResult = signInManager.PasswordSignInAsync(user, model.Password, true, false).Result;


                if (signInResult.Succeeded)
                {

                    return RedirectToAction("Index", "Employees");
                }
            return View(model);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
