using System;
using ECertAssessment.BLL.Data.Repositories;

namespace ECertAssessment.BLL.Data
{
    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        void Commit();
    }
}