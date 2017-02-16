using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
	public class UserSettingsRepository
    {
		public UserSettingsRepository()
		{
		}


        /// <summary>
        /// Get user settings by user id
        /// </summary>
        public static UserSettings Get(Guid userId)
        {
            UserSettings setting = new UserSettings();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "settings.UserSettings_Get";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                setting.UnpackXML(xmlOut.Element("UserSetting"));
            }

            return setting;
        }

        /// <summary>
        /// AddEdit user setting
        /// </summary>
        public static bool AddEdit(UserSettings setting)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "settings.UserSettings_AddEdit";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, setting.UserId);
                dataManager.Add("@SystemNotifications", SqlDbType.Bit, ParameterDirection.Input, setting.SystemNotifications);
                dataManager.Add("@EmailNotifications", SqlDbType.Bit, ParameterDirection.Input, setting.EmailNotifications);
                
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
        

    }
}
