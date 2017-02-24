using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Repository.Interface;
using System;
using System.Data;
using System.Xml.Linq;
using System.Collections.Generic;

namespace GS.Recruitment.Repository.Implementation
{
    public class UserSettingsRepository: IRepository<UserSettings>
    {
        public string ConnectionString { get; set; }
        

        public UserSettingsRepository()
		{
            ConnectionString = WebConfigConnectionString.RecruitmentConnection;
        }

        /// <summary>
        /// Get user settings by user id
        /// </summary>
        public UserSettings Get(Guid id)
        {
            UserSettings setting = new UserSettings();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "settings.UserSettings_Get";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
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
        public bool AddEdit(UserSettings entity)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "settings.UserSettings_AddEdit";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, entity.UserId);
                dataManager.Add("@SystemNotifications", SqlDbType.Bit, ParameterDirection.Input, entity.SystemNotifications);
                dataManager.Add("@EmailNotifications", SqlDbType.Bit, ParameterDirection.Input, entity.EmailNotifications);
                
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public List<UserSettings> List()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public bool Delete(UserSettings entity)
        {
            throw new NotImplementedException();
        }
    }
}
