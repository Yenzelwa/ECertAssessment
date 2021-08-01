using ECertAssessment.BLL.Data.Repositories;

namespace ECertAssessment.BLL.Data
{
    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext db;

        private IProductRepository products;
        public IProductRepository Products { get; }

        /// <summary>
        /// Factoring method for starting a new UOW
        /// </summary>
        public static IUnitOfWork Begin()
        {
            return DataContainer.Resolve<IUnitOfWork>();
        }

        /// <summary>
        /// Commits changes made to all repositories
        /// </summary>
        public void Commit()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
