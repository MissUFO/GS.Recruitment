using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using GS.Recruitment.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
	public class TaskRepository : IRepository<Task>
    {
        public string ConnectionString { get; set; }

        public TaskRepository()
        {
            ConnectionString = WebConfigConnectionString.RecruitmentConnection;
        }

        /// <summary>
        /// Get task by taskid
        /// </summary>
        public Task Get(Guid id)
        {
            Task task = new Task();

            using (DataManager dataManager = new DataManager(ConnectionString))
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
        public bool AddEdit(Task task)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Tasks_AddEdit";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, task.Id);
                dataManager.Add("@Title", SqlDbType.NVarChar, ParameterDirection.Input, task.Title);
                dataManager.Add("@Description", SqlDbType.NVarChar, ParameterDirection.Input, task.Description);
                if (task.StartDate.HasValue)
                    dataManager.Add("@StartDate", SqlDbType.DateTime, ParameterDirection.Input, task.StartDate.Value);
                if(task.EndDate.HasValue)
                    dataManager.Add("@EndDate", SqlDbType.DateTime, ParameterDirection.Input, task.EndDate.Value);
                dataManager.Add("@UserFromId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, task.UserFromId);
                dataManager.Add("@UserToId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, task.UserToId);
                dataManager.Add("@TaskStatus", SqlDbType.TinyInt, ParameterDirection.Input, (int)task.TaskStatus);
                dataManager.Add("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, task.CreatedOn != DateTime.MinValue ? task.CreatedOn : DateTime.Now);
                dataManager.Add("@ModifiedOn", SqlDbType.DateTime, ParameterDirection.Input, task.ModifiedOn != DateTime.MinValue ? task.ModifiedOn : DateTime.Now);
                dataManager.Add("@CreatedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, task.CreatedBy != Guid.Empty? task.CreatedBy : task.UserFromId);
                dataManager.Add("@ModifiedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, task.ModifiedBy != Guid.Empty ? task.ModifiedBy : task.UserFromId);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Get tasks list
        /// </summary>
        public List<Task> List()
        {
            List<Task> tasks = new List<Task>();

            using (DataManager dataManager = new DataManager(ConnectionString))
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
        public List<Task> ListUserFrom(Guid userId)
        {
            List<Task> tasks = new List<Task>();

            using (DataManager dataManager = new DataManager(ConnectionString))
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
        public List<Task> ListUserTo(Guid userId)
        {
            List<Task> tasks = new List<Task>();

            using (DataManager dataManager = new DataManager(ConnectionString))
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

        public bool Delete(Guid id)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Tasks_Delete";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
    }
}
