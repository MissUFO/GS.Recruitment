using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class UserSettingsBusinessService
    {
        protected UserSettingsRepository repo { get; set; }

        public UserSettingsBusinessService()
        {
            repo = new UserSettingsRepository();
        }

        /// <summary>
        /// Get User Settings by user id
        /// </summary>
        public UserSettings Get(Guid userId)
        {
            return repo.Get(userId);
        }

        /// <summary>
        /// AddEdit user settings
        /// </summary>
        public bool AddEdit(UserSettings settings)
        {
            return repo.AddEdit(settings);
        }
    }
}
