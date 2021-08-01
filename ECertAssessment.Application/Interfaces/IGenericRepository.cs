using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECertAssessment.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<string> Add(T entity);
        Task<string> Update(T entity);

    }
}
