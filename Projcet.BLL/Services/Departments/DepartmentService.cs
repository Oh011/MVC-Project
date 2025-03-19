using Microsoft.EntityFrameworkCore;
using Project.BLL.Dtos.Departments;
using Project.DAL.Entites.Departments;
using Project.DAL.presistance.UnitOfWork;

namespace Project.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IUnitOfWork _UnitOfWork;



        public DepartmentService(IUnitOfWork unitOfWork)
        {

            this._UnitOfWork = unitOfWork;

        }

        public IEnumerable<ReturnDepartmentDto> GetAllDepartments()
        {


            var result = _UnitOfWork.DepartmentRepository.GetAllQueryable().Where(d => d.IsDeleted == false)
                .Select(D => new ReturnDepartmentDto
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

            _UnitOfWork.DepartmentRepository.Add(CreatedDepartment);

            return _UnitOfWork.Complete();
        }

        public bool DeleteDepartment(int id)
        {

            var result = _UnitOfWork.DepartmentRepository.GetById(id);


            if (result != null)
            {
                _UnitOfWork.DepartmentRepository.Delete(result);

                var RowsAffected = _UnitOfWork.Complete();


                return RowsAffected > 0;
            }

            return false;
        }


        public ReturnDepartmentDetailsDto? GetById(int id)
        {


            var department = _UnitOfWork.DepartmentRepository.GetById(id);


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


            _UnitOfWork.DepartmentRepository.Update(department);

            return _UnitOfWork.Complete();
        }

        public IEnumerable<ReturnDepartmentDto> SearchByName(string Name)
        {


            var result = _UnitOfWork.DepartmentRepository.GetAllQueryable().Where(D => D.IsDeleted == false &&


            (string.IsNullOrEmpty(Name) || D.Name.ToLower().Contains(Name.ToLower()))

            ).Select(D => new ReturnDepartmentDto
            {
                Id = D.Id,
                Name = D.Name,
                //Description = D.Description,
                Code = D.Code,
                CreationDate = D.CreationDate,

            }).AsNoTracking().ToList();


            return result;
        }
    }
}
