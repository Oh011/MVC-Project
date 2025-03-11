using Microsoft.EntityFrameworkCore;
using Projcet.BLL.Dtos.Departments;
using Projcet.DAL.Entites.Departments;
using Projcet.DAL.prestance.Repostories.Departments;

namespace Projcet.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _DepartmentRepository;



        public DepartmentService(IDepartmentRepository departmentRepository)
        {

            _DepartmentRepository = departmentRepository;
        }

        public IEnumerable<ReturnDepartmentDto> GetAllDepartments()
        {


            var result = _DepartmentRepository.GetAllQueryable().Select(D => new ReturnDepartmentDto
            {

                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code = D.Code,
                CreationDate = D.CreationDate,

            }).AsNoTracking().ToList();


            return result;
        }
        public int CreateDepartment(CreateDepartmentDto Entity)
        {

            var CreatedDepartment = new Department()
            {


                Name = Entity.Name,
                Description = Entity.Description,
                Code = Entity.Code,
                CreationDate = Entity.CreationDate,
                LastModifiedBy = 1, //default value because there is no relations
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
            };

            return _DepartmentRepository.Add(CreatedDepartment);
        }

        public bool DeleteDepartment(int id)
        {

            var result = _DepartmentRepository.GetById(id);


            if (result != null)
            {
                var RowsAffected = _DepartmentRepository.Delete(result);

                return RowsAffected > 0;
            }

            return false;
        }


        public ReturnDepartmentDetailsDto? GetById(int id)
        {


            var department = _DepartmentRepository.GetById(id);


            if (department != null)
            {


                return new ReturnDepartmentDetailsDto()
                {

                    Id = department.Id,
                    Name = department.Name,
                    Description = department.Description,
                    Code = department.Code,
                    CreationDate = department.CreationDate,
                    LastModifiedOn = department.LastModifiedOn,
                    CreatedAt = department.CreatedOn,
                    CreatedBy = department.CreatedBy,
                    LastModifiedBy = department.LastModifiedBy

                };
            }
            return null;
        }

        public int UpdateDepartment(UpdateDepartmentDto entity)
        {


            var department = new Department()
            {

                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Code = entity.Code,
                CreationDate = entity.CreationDate,

            };


            return _DepartmentRepository.Update(department);
        }
    }
}
