using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.ViewModels.Identity;
using Projcet.BLL.Common.Services;
using Projcet.DAL.Entites.Identity;

namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IEmailService _emailService;




        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
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


                var User = new ApplicationUser()
                {

                    UserName = model.Email.Split("@")[0],
                    FName = model.FName,
                    LName = model.LName,
                    Email = model.Email,
                    IsAgree = model.IsAgree,
                };



                var Result = await _userManager.CreateAsync(User, model.Password);

                if (Result.Succeeded)
                {

                    return RedirectToAction("LogIn");

                }


                else
                {

                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }


            }

            return View(model);

        }



        public IActionResult LogIn()
        {


            return View();
        }



        [HttpPost]

        public async Task<IActionResult> LogIn(LogInViewModel model)
        {


            if (ModelState.IsValid)
            {



                var User = await _userManager.FindByEmailAsync(model.Email);



                if (User is not null)
                {

                    var Result = await _signInManager.PasswordSignInAsync(User, model.Password, model.RememberMe,

                        lockoutOnFailure: true);



                    if (Result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }


                    else if (Result.IsLockedOut)
                    {

                        ModelState.AddModelError(string.Empty, "Account is LockedOut");

                    }

                    else
                    {

                        ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    }
                }

                else
                {

                    ModelState.AddModelError(string.Empty, "UserName not found");
                }




            }

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {


            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(LogIn));


        }



        public IActionResult ForgetPassword()
        {


            return View();
        }


        [HttpPost]


        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {




            if (ModelState.IsValid)
            {


                var User = await _userManager.FindByNameAsync(model.Email);


                if (User is not null)
                {


                    var token = await _userManager.GeneratePasswordResetTokenAsync(User);


                    var url = Url.Action("ResetPassword", "Account", new
                    {

                        email = model.Email,
                        Token = token
                    }, Request.Scheme);



                    var email = new Email()
                    {

                        To = model.Email,
                        Subject = "Reset Your Password",
                        Body = url

                    };

                    await _emailService.SendEmail(email);

                    return RedirectToAction(nameof(CheckInbox));


                }
                ModelState.AddModelError(string.Empty, "Invalid credentials");

            }

            return View(model);

        }



        public IActionResult CheckInbox()
        {

            return View();
        }




        public IActionResult ResetPassword(string email, string Token)
        {


            TempData["Email"] = email;
            TempData["token"] = Token;


            return View();
        }


        [HttpPost]


        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {




            if (ModelState.IsValid)
            {




                var email = TempData["email"] as string;
                var Token = TempData["token"] as string;

                var user = await _userManager.FindByEmailAsync(email);



                if (user is not null)
                {


                    var result = await _userManager.ResetPasswordAsync(user, Token, model.Password);



                    if (result.Succeeded)
                    {


                        return RedirectToAction(nameof(LogIn));
                    }

                    else
                    {


                        foreach (var item in result.Errors)
                        {

                            ModelState.AddModelError(string.Empty, item.Description);
                        }

                        return View(model);
                    }
                }

            }

            return View(model);






        }


    }
}
