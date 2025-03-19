using Demo.BLL.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.Departments;
using Project.BLL.Services.Employees;
using Project.DAL.presistance.UnitOfWork;
using Project.DAL.prestance.Data;
using Project.DAL.prestance.Repostories.Departments;
using Project.DAL.prestance.Repostories.Employees;


namespace MVC_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(Options =>


            Options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())

                );



            //Allows Di for ApplicationDbcontext and the Options

            builder.Services.AddDbContext<ApplicationDbContext>(Options =>
          {

              // ?? Enable Lazy Loading
              Options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);


              Options.UseLazyLoadingProxies();



              //Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
          });



            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();


            builder.Services.AddAutoMapper(typeof(MappingProfile));



            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
