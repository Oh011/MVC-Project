using Microsoft.EntityFrameworkCore;
using Projcet.DAL.Entites;
using Projcet.DAL.prestance.Data;

namespace Projcet.DAL.presistance.Repostories.Generic
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

        public int Add(T entity)
        {

            _dbSet.Add(entity);

            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {

            _dbSet.Remove(entity);


            return _dbContext.SaveChanges();
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

        public int Update(T entity)
        {

            _dbSet.Update(entity);

            return _dbContext.SaveChanges();
        }
    }
}
