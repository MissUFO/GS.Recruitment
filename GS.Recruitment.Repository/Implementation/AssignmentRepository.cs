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
	public class AssignmentRepository : IRepository<Assignment>
    {
        public string ConnectionString { get; set; }

        public AssignmentRepository()
        {
            ConnectionString = WebConfigConnectionString.RecruitmentConnection;
        }

        /// <summary>
        /// Get assignment by id
        /// </summary>
        public Assignment Get(Guid id)
        {
            Assignment assignment = new Assignment();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Assignments_Get";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                assignment.UnpackXML(xmlOut.Element("Assignment"));
            }

            return assignment;
        }

        /// <summary>
        /// AddEdit assignment
        /// </summary>
        /// <param name="assignment"></param>
        public bool AddEdit(Assignment assignment)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Assignments_AddEdit";
                dataManager.Add("@TaskId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.TaskId);
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.Id);
                dataManager.Add("@Title", SqlDbType.NVarChar, ParameterDirection.Input, assignment.Title);
                dataManager.Add("@Description", SqlDbType.NVarChar, ParameterDirection.Input, assignment.Description);
                if (assignment.StartDate.HasValue)
                    dataManager.Add("@StartDate", SqlDbType.DateTime, ParameterDirection.Input, assignment.StartDate.Value);
                if (assignment.EndDate.HasValue)
                    dataManager.Add("@EndDate", SqlDbType.DateTime, ParameterDirection.Input, assignment.EndDate.Value);
                dataManager.Add("@UserFromId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.UserFromId);
                dataManager.Add("@UserToId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.UserToId);
                dataManager.Add("@AssignmentStatus", SqlDbType.TinyInt, ParameterDirection.Input, (int)assignment.AssignmentStatus);
                dataManager.Add("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, assignment.CreatedOn != DateTime.MinValue ? assignment.CreatedOn : DateTime.Now);
                dataManager.Add("@ModifiedOn", SqlDbType.DateTime, ParameterDirection.Input, assignment.ModifiedOn != DateTime.MinValue ? assignment.ModifiedOn : DateTime.Now);
                dataManager.Add("@CreatedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.CreatedBy);
                dataManager.Add("@ModifiedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.ModifiedBy);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }


        /// <summary>
        /// Assign all contact to the assignment
        /// </summary>
        public bool AssignmentContact_AddEditBulk(List<AssignmentContact> assignmentContacts)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                //create datetable and call sp
                //dataManager.ExecuteString = "process.Assignments_AddEdit";
                //dataManager.Add("@TaskId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.TaskId);
                //dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.Id);
                //dataManager.Add("@Title", SqlDbType.NVarChar, ParameterDirection.Input, assignment.Title);
                //dataManager.Add("@Description", SqlDbType.NVarChar, ParameterDirection.Input, assignment.Description);
                //dataManager.Add("@UserFromId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.UserFromId);
                //dataManager.Add("@UserToId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.UserToId);
                //dataManager.Add("@AssignmentStatus", SqlDbType.TinyInt, ParameterDirection.Input, (int)assignment.AssignmentStatus);
                //dataManager.Add("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, assignment.CreatedOn != DateTime.MinValue ? assignment.CreatedOn : DateTime.Now);
                //dataManager.Add("@ModifiedOn", SqlDbType.DateTime, ParameterDirection.Input, assignment.ModifiedOn != DateTime.MinValue ? assignment.ModifiedOn : DateTime.Now);
                //dataManager.Add("@CreatedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.CreatedBy);
                //dataManager.Add("@ModifiedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignment.ModifiedBy);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
        
        /// <summary>
        /// Assign contact to the assignment or change status
        /// </summary>
        public bool AssignmentContact_AddEdit(AssignmentContact assignmentContact)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.AssignmentContacts_AddEdit";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignmentContact.Id);
                dataManager.Add("@AssignmentId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignmentContact.AssignmentId);
                dataManager.Add("@ContactId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, assignmentContact.ContactId);
                dataManager.Add("@AssignmentContactStatus", SqlDbType.TinyInt, ParameterDirection.Input, (int)assignmentContact.AssignmentContactStatus);
                dataManager.Add("@Comment", SqlDbType.NVarChar, ParameterDirection.Input, assignmentContact.Comment);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }


        /// <summary>
        /// Get assignments list by user id
        /// </summary>
        public List<Assignment> ListUserTo(Guid userId)
        {
            List<Assignment> assignments = new List<Assignment>();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Assignments_List_UserTo";
                dataManager.Add("@UserToId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                assignments.UnpackXML(xmlOut);
            }

            return assignments;
        }

        /// <summary>
        /// Get assignments list by task id
        /// </summary>
        public List<Assignment> ListTask(Guid taskId)
        {
            List<Assignment> assignments = new List<Assignment>();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Assignments_List_Task";
                dataManager.Add("@TaskId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, taskId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                assignments.UnpackXML(xmlOut);
            }

            return assignments;
        }

        public List<Assignment> List()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "process.Assignments_Delete";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
               
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
    }
}
