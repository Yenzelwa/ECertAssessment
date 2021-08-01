using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.MVC.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string type { get; set; }
        public DateTime expires { get; set; }
        public DateTime issued { get; set; }
    }
}
