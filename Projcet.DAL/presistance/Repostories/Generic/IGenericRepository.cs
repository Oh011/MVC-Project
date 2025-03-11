using Projcet.DAL.Entites;

namespace Projcet.DAL.presistance.Repostories.Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {




        public IEnumerable<T> GetAll(bool AsNoTracking = true);


        public IQueryable<T> GetAllQueryable();


        public T? GetById(int id);


        public int Add(T entity);

        public int Update(T entity);


        public int Delete(T entity);
    }
}
