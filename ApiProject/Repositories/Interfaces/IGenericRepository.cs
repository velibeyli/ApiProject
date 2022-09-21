using System.Linq.Expressions;

namespace ApiProject.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T,bool>> filter = default);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter = default);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
