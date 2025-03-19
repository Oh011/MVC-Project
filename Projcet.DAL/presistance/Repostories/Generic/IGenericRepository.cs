using Project.DAL.Entites;

namespace Project.DAL.presistance.Repostories.Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {




        public IEnumerable<T> GetAll(bool AsNoTracking = true);


        public IQueryable<T> GetAllQueryable();


        public T? GetById(int id);


        public void Add(T entity);

        public void Update(T entity);


        public void Delete(T entity);
    }
}
