using System.Configuration;

namespace GS.Recruitment.Repository
{
    public class WebConfigConnectionString
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
