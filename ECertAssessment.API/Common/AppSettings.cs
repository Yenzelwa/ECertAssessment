using System;
using System.Collections.Generic;
using System.Text;

namespace ECertAssessment.API.Common
{
    public interface IAppSettings
    {
        JWT JWT { get; set; }
        ConnectionStrings ConnectionStrings { get; set; }

    }

    public class AppSettings : IAppSettings
    {
        public JWT JWT { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string MySqlConnection { get; set; }
    }

    public class JWT
    {
        public string SecretKey { get; set; }
        public string TokenType { get; set; }
        public int TokenExpiresMins { get; set; }
    }

}


