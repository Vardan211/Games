using System.Linq;
using System.Threading.Tasks;

namespace Games.DataAcess.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}
