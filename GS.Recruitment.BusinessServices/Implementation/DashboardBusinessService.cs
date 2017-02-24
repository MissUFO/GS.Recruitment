using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class DashboardBusinessService
    {
        public DashboardBusinessService()
        {
        }
       
        public Dashboard Get_Admin(Guid userId)
        {
            return DashboardRepository.Get_Admin(userId);
        }

        public Dashboard Get_Recruiter(Guid userId)
        {
            return DashboardRepository.Get_Recruiter(userId);
        }
    }
}
