using Microsoft.EntityFrameworkCore;
using Project.DAL.Entites;
using Project.DAL.prestance.Data;

namespace Project.DAL.presistance.Repostories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {

            _dbSet.Add(entity);


        }

        public void Delete(T entity)
        {


            entity.IsDeleted = true;



        }

        public IEnumerable<T> GetAll(bool AsNoTracking = true)
        {


            if (AsNoTracking)
            {

                return _dbSet.AsNoTracking().ToList();
            }


            return _dbSet.ToList();
        }

        public IQueryable<T> GetAllQueryable()
        {


            return _dbSet;
        }

        public T? GetById(int id)
        {


            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {

            _dbSet.Update(entity);


        }
    }
}
