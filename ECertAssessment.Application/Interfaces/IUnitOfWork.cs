namespace ECertAssessment.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository  Categories { get; }
        IProductRepository   Products { get; }
        IAppUserRepository  AppUsers { get; }
        IFileRepository Files { get; }
    }
}