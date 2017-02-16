using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
	public class NotificationRepository
    {
		public NotificationRepository()
		{
		}


        /// <summary>
        /// Get notification by id
        /// </summary>
        public static Notification Get(Guid id)
        {
            Notification notification = new Notification();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "msg.Notifications_Get";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                notification.UnpackXML(xmlOut.Element("Notification"));
            }

            return notification;
        }

        /// <summary>
        /// AddEdit notification
        /// </summary>
        /// <param name="notification"></param>
        public static bool AddEdit(Notification notification)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "msg.Notifications_AddEdit";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, notification.Id);
                dataManager.Add("@Subject", SqlDbType.NVarChar, ParameterDirection.Input, notification.Subject);
                dataManager.Add("@Message", SqlDbType.NVarChar, ParameterDirection.Input, notification.Message);
                dataManager.Add("@NotificationType", SqlDbType.Int, ParameterDirection.Input, notification.NotificationType);
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, notification.UserId);
                dataManager.Add("@EntityId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, notification.EntityId);
                dataManager.Add("@EntityType", SqlDbType.Int, ParameterDirection.Input, notification.EntityType);
                dataManager.Add("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, notification.CreatedOn);
                dataManager.Add("@IsReceived", SqlDbType.Bit, ParameterDirection.Input, notification.IsReceived);
                dataManager.Add("@ReceivedOn", SqlDbType.DateTime, ParameterDirection.Input, notification.ReceivedOn);
                
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Get notifications list
        /// </summary>
        public static List<Notification> List(Guid userId)
        {
            List<Notification> notifications = new List<Notification>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "msg.Notifications_List";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                notifications.UnpackXML(xmlOut);
            }

            return notifications;
        }

    }
}
