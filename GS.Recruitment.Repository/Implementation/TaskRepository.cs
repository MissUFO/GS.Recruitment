using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
	public class TaskRepository
    {
		public TaskRepository()
		{
		}


        /// <summary>
        /// Get task by taskid
        /// </summary>
        public static Task Get(Guid id)
        {
            Task task = new Task();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "process.Tasks_Get";
                dataManager.Add("@TaskID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                task.UnpackXML(xmlOut.Element("Task"));
            }

            return task;
        }

        /// <summary>
        /// AddEdit task
        /// </summary>
        /// <param name="task"></param>
        public static bool AddEdit(Task task)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "process.Tasks_AddEdit";
                //dataManager.Add("@UserID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, user.UserId);
                //dataManager.Add("@FirstName", SqlDbType.NVarChar, ParameterDirection.Input, user.FirstName);
                //dataManager.Add("@LastName", SqlDbType.NVarChar, ParameterDirection.Input, user.LastName);
                //dataManager.Add("@Login", SqlDbType.NVarChar, ParameterDirection.Input, user.Login);
                //dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, user.Password);
                //dataManager.Add("@UserStatus", SqlDbType.Int, ParameterDirection.Input, (int)user.UserStatus);
                //dataManager.Add("@RoleType", SqlDbType.Int, ParameterDirection.Input, (user.Roles != null && user.Roles.Count > 0) ? (int)user.Roles[0].RoleType : (int)RoleType.Recruiter);
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Get tasks list
        /// </summary>
        public static List<Task> List()
        {
            List<Task> tasks = new List<Task>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "process.Tasks_List";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                tasks.UnpackXML(xmlOut);
            }

            return tasks;
        }

        /// <summary>
        /// Get tasks list by user from id
        /// </summary>
        public static List<Task> ListUserFrom(Guid userId)
        {
            List<Task> tasks = new List<Task>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "process.Tasks_List_UserFrom";
                dataManager.Add("@UserFromId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                tasks.UnpackXML(xmlOut);
            }

            return tasks;
        }

        /// <summary>
        /// Get tasks list by user to id
        /// </summary>
        public static List<Task> ListUserTo(Guid userId)
        {
            List<Task> tasks = new List<Task>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "process.Tasks_List_UserTo";
                dataManager.Add("@UserToId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                tasks.UnpackXML(xmlOut);
            }

            return tasks;
        }
    }
}
