using System;
using System.Collections.Generic;

#nullable disable

namespace ECertAssessment.Domain.Entities
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            Categories = new HashSet<Category>();
            Files = new HashSet<File>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
