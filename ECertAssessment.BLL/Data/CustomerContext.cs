using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ECertAssessment.BLL.Models;

namespace ECertAssessment.BLL.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Product> Customers { get; set; }

         CustomerContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Update Created and Modified timestamps for all new/updated entities
        /// </summary>
        /// <returns></returns>
    }
}