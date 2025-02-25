using Microsoft.EntityFrameworkCore;
using Projcet.DAL.Entites.Departments;
using Projcet.DAL.prestance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projcet.DAL.prestance.Repostories.Departments
{
    internal class DepartmentRepository : IDepartmentRepository
    {

        private ApplicationDbContext _context;



        public DepartmentRepository(ApplicationDbContext context)
        {

            this._context = context;
        }
        public IEnumerable<Department> GetAll(bool AsNoTracking = true)
        {

            if (AsNoTracking)
            {
                return _context.Departments.ToList();

            }

            return _context.Departments.AsNoTracking().ToList();
        }
        public Department? GetById(int id)
        {


            var department = _context.Departments.Find(id);//--> finds by primary key first locally then in DataBase 


            return department;
        }
        public int AddDepartment(Department department)
        {
          

            _context.Departments.Add(department);

          
            return _context.SaveChanges();
        }

        public int DeleteDepartment(Department department)
        {
            
            _context.Remove(department);

            return _context.SaveChanges();
        }



        public int UpdateDepartment(Department department)
        {
            
            _context.Update(department);

            return _context.SaveChanges();
        }
    }
}
