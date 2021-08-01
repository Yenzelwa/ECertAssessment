

using ECertAssessment.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECertAssessment.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IAppUserRepository  appUserRepository , ICategoryRepository  categoryRepository , IProductRepository  productRepository , IFileRepository  fileRepository) 
        {
            AppUsers = appUserRepository;
            Products = productRepository;
            Categories = categoryRepository;
            Files = fileRepository;
        }

        public ICategoryRepository Categories { get; }

        public IProductRepository Products { get; }

        public IAppUserRepository AppUsers { get; }

        public IFileRepository Files { get; }
    }
}
