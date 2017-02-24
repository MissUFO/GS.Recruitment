using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using System;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
    public class DashboardRepository
    {
		public DashboardRepository()
		{
		}


        public static Dashboard Get_Admin(Guid userId)
        {
            Dashboard dashboard = new Dashboard();

            using (DataManager dataManager = new DataManager(WebConfigConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "[msg].[Dashboard_Get_Admin]";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                dashboard.UnpackXML(xmlOut);
            }

            return dashboard;
        }

        public static Dashboard Get_Recruiter(Guid userId)
        {
            Dashboard dashboard = new Dashboard();

            using (DataManager dataManager = new DataManager(WebConfigConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "[msg].[Dashboard_Get_Recruiter]";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                dashboard.UnpackXML(xmlOut);
            }

            return dashboard;
        }

    }
}
