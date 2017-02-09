using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Recruitment.Repository
{
    public class ConnectionString
    {
        public static string RecruitmentConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Recruitment.database"].ConnectionString;
            }
        }
    }
}
