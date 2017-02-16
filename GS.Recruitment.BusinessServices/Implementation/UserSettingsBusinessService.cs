using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class UserSettingsBusinessService
    {
        public UserSettingsBusinessService()
        {
        }

        /// <summary>
        /// Get User Settings by user id
        /// </summary>
        public UserSettings Get(Guid userId)
        {
            return UserSettingsRepository.Get(userId);
        }

        /// <summary>
        /// AddEdit user settings
        /// </summary>
        public bool AddEdit(UserSettings settings)
        {
            return UserSettingsRepository.AddEdit(settings);
        }

    }
}
