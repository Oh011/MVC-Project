using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Dtos.Departments;
using Project.BLL.Dtos.Employees;
using Project.BLL.Services.Departments;
using Project.BLL.Services.Employees;
using Project.DAL.Entites.Common.Enums;

namespace MVC_Project.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly IEmployeeService employeeService;

        private readonly IWebHostEnvironment webHostEnvironment;


        private readonly ILogger<EmployeeController> logger;


        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment, ILogger<EmployeeController> logger)
        {
            this.employeeService = employeeService;
            this.webHostEnvironment = webHostEnvironment;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var Result = employeeService.GetAllEmployees();


            return View(Result);
        }



        public IActionResult SearchByName(string Name)
        {


            var result = employeeService.SearchByName(Name);

            if (Request.Headers["Source"].ToString() == "JS")
            {
                return PartialView("PartialViews\\ReturnPartial", result);

            }


            return View("Index", result);


        }


        [HttpGet]

        public IActionResult Create([FromServices] IDepartmentService departmentService)
        {

            var departments = departmentService.GetAllDepartments();


            ViewBag.Departments = new SelectList(departments, nameof(ReturnDepartmentDto.Id), nameof(ReturnDepartmentDto.Name));


            return View();

        }

        [HttpPost]





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeDto employee)
        {

            if (!ModelState.IsValid)
                return View(employee);

            // Stay on the same page if validation fails and The validation messages for fileds appears



            var message = string.Empty;
            try
            {
                var Result = this.employeeService.CreateEmployee(employee);


                if (Result > 0)
                {
                    return RedirectToAction(nameof(Index));
                    //is used to redirect the user to another action method within a controller.
                }


                else
                {

                    message = "Employee can not be created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(employee);
                }

            }

            catch (Exception ex) // DataBase Exceptions is logged 
            {

                //Logging ==> File , Database , console {small apps}

                logger.LogError(ex, ex.Message);

                if (this.webHostEnvironment.IsDevelopment())
                {

                    message = ex.Message;
                    ModelState.AddModelError(string.Empty, message);

                    return View(employee);
                }

                else
                {

                    message = "employee can not be created";
                    ModelState.AddModelError(string.Empty, message);
                    return View("Error", message);
                }

            }
        }



        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
                return BadRequest();



            var result = employeeService.GetEmployeeById(id.Value);


            if (result == null)
                return NotFound();



            return View(result);

        }


        [HttpGet]

        public async Task<IActionResult> Edit([FromServices] IDepartmentService departmentService, int? id)
        {

            if (id is null)
                return BadRequest();

            var employee = this.employeeService.GetEmployeeById(id.Value);



            if (employee == null)
                return NotFound();


            var departments = departmentService.GetAllDepartments();


            //Returns ReturnDepartmentDetailsDto


            var DepartmentId = departments.Where(d => d.Name == employee.Department).Select(d => d.Id).FirstOrDefault();



            ViewBag.Departments = new SelectList(departments, nameof(ReturnDepartmentDto.Id), nameof(ReturnDepartmentDto.Name),

                employee.Department);


            return View(new EmployeeUpdateDto
            {

                Id = id.Value,
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.TryParse<Gender>(employee.Gender, out var gender) ? gender : default,
                EmployeeType = Enum.TryParse<EmployeeType>(employee.EmployeeType, out var Emptype) ? Emptype : default,
                DepartmentId = DepartmentId,


            });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, EmployeeUpdateDto employee)
        {


            if (!ModelState.IsValid)
                return View(employee);


            var message = string.Empty;


            try
            {


                var result = this.employeeService.UpdateEmployee(employee);


                if (result > 0)
                    return RedirectToAction(nameof(Index));

                else
                    message = "Employee can not be Updated";

            }


            catch (Exception ex)
            {

                this.logger.LogError(ex, ex.Message);

                if (this.webHostEnvironment.IsDevelopment())
                    message = ex.Message;

                else message = "Employee can not be Updated";
            }

            return View(employee);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {



            var message = string.Empty;
            try
            {
                var result = this.employeeService.DeleteEmployee(id);


                if (result)
                    return RedirectToAction(nameof(Index));


                message = "Error happened when deleting the Employee";

            }

            catch (Exception ex)
            {


                this.logger.LogError(ex, ex.Message);


                if (this.webHostEnvironment.IsDevelopment())
                    message = ex.Message;

                else
                    message = "Error happened when deleting the Employee";

            }

            return RedirectToAction(nameof(Index));


        }
    }
}
