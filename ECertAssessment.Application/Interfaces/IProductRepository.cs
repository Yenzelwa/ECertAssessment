


using ECertAssessment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECertAssessment.Application.Interfaces
{
    public interface IProductRepository: IGenericRepository<ECertAssessment.Domain.Entities.Product>
    {
        Task<int> GetAllCount();
        Task<IEnumerable<ECertAssessment.Domain.Entities.Product>> GetAllFilter(int start, int length);
    }
}