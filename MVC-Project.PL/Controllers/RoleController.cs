using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.ViewModels.Roles;
using Projcet.DAL.Entites.Identity;

namespace MVC_Project.Controllers
{


    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManger;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IWebHostEnvironment _webHostEnvironment;


        public RoleController(RoleManager<IdentityRole> RoleManger, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {


            _roleManger = RoleManger;
            _webHostEnvironment = webHostEnvironment;

            _userManager = userManager;


        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Roles = _roleManger.Roles.AsQueryable();

            var Result = await Roles.Select(R => new RolesViewModel
            {


                Id = R.Id,
                Name = R.Name


            }).ToListAsync();





            return View(Result);

        }




        [HttpGet]
        public async Task<IActionResult> SearchByName(string Name)
        {


            var Roles = _roleManger.Roles.AsQueryable();


            var Result = await Roles.Where(r =>

                string.IsNullOrEmpty(Name) || r.Name.ToLower().Contains(Name.ToLower())

                )
                .Select(R => new RolesViewModel
                {


                    Id = R.Id,
                    Name = R.Name


                }).ToListAsync();









            if (Request.Headers["Source"].ToString() == "JS")
            {

                return PartialView("PartialViews\\ReturnPartial", Result);
            }

            return View(nameof(Index), Result);





        }




        [HttpGet]

        public async Task<IActionResult> Details(string? id)
        {


            if (id is null)
                return BadRequest();


            var Role = await _roleManger.FindByIdAsync(id);


            if (User == null)
                return NotFound();



            var RolesViewModel = new RolesViewModel()
            {

                Id = Role.Id,
                Name = Role.Name


            };


            return View(RolesViewModel);




        }


        [HttpGet]

        public async Task<IActionResult> Edit(string? id)
        {

            if (id is null)
                return BadRequest();

            var Role = await _roleManger.FindByIdAsync(id);



            if (Role == null)
                return NotFound();



            var users = await _userManager.Users.ToListAsync();


            return View(new RolesViewModel()
            {

                Id = Role.Id,
                Name = Role.Name,
                Users = users.Select(U => new UserRoleViewModel()
                {

                    UserId = U.Id,
                    UserName = U.UserName,
                    IsSelected = _userManager.IsInRoleAsync(U, Role.Name).Result

                }).ToList()

            });





        }



        [ValidateAntiForgeryToken]

        [HttpPost]

        public async Task<IActionResult> Edit(string id, RolesViewModel Model)
        {


            if (!ModelState.IsValid)
                return View(Model);


            var message = string.Empty;


            try
            {


                var Role = await _roleManger.FindByIdAsync(id);




                if (User == null)
                    return NotFound();

                else
                {

                    Role.Name = Model.Name;


                    var Result = await _roleManger.UpdateAsync(Role);



                    foreach (var UserRole in Model.Users)
                    {

                        var User = await _userManager.FindByIdAsync(UserRole.UserId);



                        if (User is not null)
                        {


                            if (UserRole.IsSelected && !(await _userManager.IsInRoleAsync(User, Role.Name)))
                            {

                                await _userManager.AddToRoleAsync(User, Role.Name);
                            }


                            else if (!UserRole.IsSelected && await _userManager.IsInRoleAsync(User, Model.Name))
                            {


                                _userManager.RemoveFromRoleAsync(User, Model.Name);
                            }

                        }

                    }


                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));

                    else
                    {
                        message = "Role can not be updated";
                    }
                }

            }


            catch (Exception ex)
            {



                if (this._webHostEnvironment.IsDevelopment())
                    message = ex.Message;

                else message = "Role can not be Updated";
            }

            return View(Model);
        }



        [HttpPost]

        public async Task<IActionResult> Delete(string? id)
        {

            var message = string.Empty;
            try
            {
                var Role = await _roleManger.FindByIdAsync(id);


                if (Role is null)
                    return NotFound();



                else
                {



                    var Result = await _roleManger.DeleteAsync(Role);



                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));

                    else
                    {
                        message = "Role can not be Deleted";
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

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]



        public async Task<IActionResult> Create(RolesViewModel model)
        {


            if (ModelState.IsValid)
            {


                await _roleManger.CreateAsync(new IdentityRole()
                {

                    Name = model.Name,
                });

                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }

    }

}


