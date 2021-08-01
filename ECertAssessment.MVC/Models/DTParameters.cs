using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.MVC.Models
{
    public class DTParameters
    {
        public class DtParameters
        {
            public int draw { get; set; }
            public int start { get; set; }
            public int length { get; set; }
            public DtSearch search { get; set; }

        }
        public class DtColumn
        {
            public string data { get; set; }
            public string name { get; set; }
            public bool searchable { get; set; }
            public bool orderable { get; set; }
            public DtSearch search { get; set; }
        }
        public class DtOrder
        {
            public int column { get; set; }
            public DtOrderDir dir { get; set; }
        }

        public enum DtOrderDir
        {
            Asc,
            Desc
        }

        public class DtSearch
        {
            public string value { get; set; }
            public bool regex { get; set; }
        }
    }
}
