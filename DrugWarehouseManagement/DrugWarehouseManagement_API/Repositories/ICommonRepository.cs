using DrugWarehouseManagement_API.Entities;
using System.Diagnostics.Metrics;

namespace DrugWarehouseManagement_API.Repositories
{
    public interface ICommonRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> GetById(Guid id);
    }
}
