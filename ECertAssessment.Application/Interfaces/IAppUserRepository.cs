


using ECertAssessment.Domain.Entities;
using System.Threading.Tasks;

namespace ECertAssessment.Application.Interfaces
{
    public interface IAppUserRepository
    {
        Task<string> AddUser(AspNetUser entity);
        Task<AspNetUser> LoginUser(string email, string password);
    }
}