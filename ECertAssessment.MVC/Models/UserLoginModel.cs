using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.MVC.Models
{
    public class UserLoginModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Token Token { get; set; }
    }
}
