using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.ViewModels.User;
using Projcet.DAL.Entites.Identity;

namespace MVC_Project.Controllers
{

    [Authorize]
    public class UserController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IWebHostEnvironment _webHostEnvironment;


        public UserController(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {



            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Users = _userManager.Users.AsQueryable();




            var Result = await Users.Select(U => new UserViewModel
            {
                Id = U.Id,
                FName = U.FName,
                LName = U.LName,
                Email = U.Email,

            }).ToListAsync();


            foreach (var user in Result)
            {


                user.Roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id));
            }


            return View(Result);

        }




        [HttpGet]
        public async Task<IActionResult> SearchByName(string Name)
        {




            var users = await _userManager.Users
    .Where(u => string.IsNullOrEmpty(Name) || u.UserName.ToLower().Contains(Name.ToLower()))
    .Select(u => new UserViewModel
    {
        Id = u.Id,
        FName = u.FName,
        LName = u.LName,
        Email = u.Email

    }).ToListAsync();





            if (Request.Headers["Source"].ToString() == "JS")
            {

                return PartialView("PartialViews\\ReturnPartial", users);
            }

            return View(nameof(Index), users);





        }




        [HttpGet]

        public async Task<IActionResult> Details(string? id)
        {


            if (id is null)
                return BadRequest();


            var User = await _userManager.FindByIdAsync(id);


            if (User == null)
                return NotFound();



            var UserViewModel = new UserViewModel()
            {

                FName = User.FName,
                LName = User.LName,
                Email = User.Email,
                Roles = _userManager.GetRolesAsync(User).Result,
            };


            return View(UserViewModel);




        }


        [HttpGet]

        public async Task<IActionResult> Edit(string? id)
        {

            if (id is null)
                return BadRequest();

            var User = await _userManager.FindByIdAsync(id);



            if (User == null)
                return NotFound();






            return View(new UserViewModel()
            {

                FName = User.FName,
                LName = User.LName,
                Email = User.Email,
                Roles = await _userManager.GetRolesAsync(User),

            });





        }


        [HttpPost]

        public async Task<IActionResult> Edit(string id, UserViewModel user)
        {


            if (!ModelState.IsValid)
                return View(user);


            var message = string.Empty;


            try
            {


                var User = await _userManager.FindByIdAsync(id);




                if (User == null)
                    return NotFound();

                else
                {

                    User.FName = user.FName;
                    User.LName = user.LName;
                    User.Email = user.Email;


                    var Result = await _userManager.UpdateAsync(User);



                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));

                    else
                    {
                        message = "User can not be updated";
                    }
                }

            }


            catch (Exception ex)
            {



                if (this._webHostEnvironment.IsDevelopment())
                    message = ex.Message;

                else message = "Employee can not be Updated";
            }

            return View(user);
        }



        [HttpPost]

        public async Task<IActionResult> Delete(string? id)
        {

            var message = string.Empty;
            try
            {
                var User = await _userManager.FindByIdAsync(id);


                if (User is null)
                    return NotFound();



                else
                {



                    var Result = await _userManager.DeleteAsync(User);



                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));

                    else
                    {
                        message = "User can not be Deleted";
                    }

                }


            }

            catch (Exception ex)
            {





                if (this._webHostEnvironment.IsDevelopment())
                    message = ex.Message;

                else
                    message = "Error happened when deleting the User";

            }

            return RedirectToAction(nameof(Index));





        }
    }
}
