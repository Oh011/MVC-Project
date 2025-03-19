using Microsoft.AspNetCore.Mvc;
using MVC_Project.ViewModels.Departments;
using Project.BLL.Dtos.Departments;
using Project.BLL.Services.Departments;

namespace MVC_Project.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _DepartmentService;

        private readonly ILogger _logger;


        private readonly IWebHostEnvironment webHostEnvironment;


        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }


        [HttpGet]
        public IActionResult Index()
        {

            var Departments = _DepartmentService.GetAllDepartments();

            return View(Departments);
        }



        public IActionResult SearchByName(string Name)
        {

            var result = _DepartmentService.SearchByName(Name);

            if (Request.Headers["Source"].ToString() == "JS")
            {
                return PartialView("PartialViews\\ReturnPartial", result);

            }



            return View("Index", result);
        }


        [HttpGet]

        public IActionResult Create()
        {

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(CreateDepartmentDto entity)
        {

            if (!ModelState.IsValid)
            {
                return View(entity);
            }


            var ErrorMessage = "";


            try
            {

                int RowsAffected = _DepartmentService.CreateDepartment(entity);


                if (RowsAffected > 0)
                {
                    TempData["Msg"] = "Success";
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    ErrorMessage = "Department can not be created";
                    ModelState.AddModelError("Message", ErrorMessage);
                    return View(entity);
                }


            }

            catch (Exception ex)
            {



                _logger.LogError(ex, ex.Message);

                if (this.webHostEnvironment.IsDevelopment())
                {
                    ErrorMessage = ex.Message;

                    ModelState.AddModelError("", ErrorMessage);
                    return View(entity);

                }

                else
                {
                    ErrorMessage = "Department can not be created";
                    return View("Error", ErrorMessage);
                }
            }

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
                return BadRequest();



            var entity = _DepartmentService.GetById(id.Value);



            if (entity == null)
                return NotFound();


            return View(entity);


        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null)
                return BadRequest();



            var entity = _DepartmentService.GetById(id.Value);



            if (entity == null)
                return NotFound();


            var department = new DepartmentEditViewModel()
            {
                Code = entity.Code,
                Name = entity.Name,
                CreationDate = entity.CreationDate,
                Description = entity.Description,
            };

            return View(department);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, DepartmentEditViewModel entity)
        {

            if (!ModelState.IsValid)
                return View(entity);


            var ErrorMessage = "";


            try
            {

                var department = new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = entity.Code,
                    Name = entity.Name,
                    CreationDate = entity.CreationDate,
                    Description = entity.Description,
                };


                var RowsAffected = _DepartmentService.UpdateDepartment(department);



                if (RowsAffected > 0)
                    return RedirectToAction(nameof(Index));


                else
                {

                    ErrorMessage = "Department can not be updated";
                    ModelState.AddModelError("", ErrorMessage);
                    return View(entity);
                }
            }


            catch (Exception ex)
            {



                _logger.LogError(ex, ex.Message);

                if (this.webHostEnvironment.IsDevelopment())
                {
                    ErrorMessage = ex.Message;

                    ModelState.AddModelError("", ErrorMessage);
                    return View(entity);

                }

                else
                {
                    ErrorMessage = "Department can not be Updated";
                    return View("Error", ErrorMessage);
                }
            }

        }






        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {

            var message = string.Empty;
            try
            {
                var result = _DepartmentService.DeleteDepartment(id);


                if (result)
                    return RedirectToAction(nameof(Index));


                message = "Error happened when deleting the department";

            }

            catch (Exception ex)
            {


                this._logger.LogError(ex, ex.Message);


                if (this.webHostEnvironment.IsDevelopment())
                    message = ex.Message;

                else
                    message = "Error happened when deleting the department";

            }

            return RedirectToAction(nameof(Index));





        }



    }
}
