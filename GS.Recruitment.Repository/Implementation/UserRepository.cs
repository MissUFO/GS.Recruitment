using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
    public class UserRepository
	{
		public UserRepository()
		{
		}

        /// <summary>
        /// Get User by userid
        /// </summary>
        public static User Get(Guid id)
        {
            User user = new User();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_Get";
                dataManager.Add("@UserID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                user.UnpackXML(xmlOut.Element("User"));
            }

            return user;
        }

        /// <summary>
        /// Get user by login and password if the user is exist
        /// </summary>
        public static User Login(string login, string password)
        {
            User user = new User();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_Login";
                dataManager.Add("@Login", SqlDbType.NVarChar, ParameterDirection.Input, login);
                dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, password);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                user.UnpackXML(xmlOut.Element("User"));
            }
            return user;
        }

        /// <summary>
        /// Change user status
        /// </summary>
        public static bool ChangeStatus(Guid id, int statusId)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_ChangeStatus";
                dataManager.Add("@UserID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@StatusID", SqlDbType.Int, ParameterDirection.Input, statusId);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Change user status
        /// </summary>
        public static bool ChangePassword(Guid id, string password)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_ChangePassword";
                dataManager.Add("@UserID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, password);

                dataManager.ExecuteNonQuery();
                result = true;
            }

            return result;
        }

        /// <summary>
        /// AddEdit User
        /// </summary>
        /// <param name="user"></param>
        public static bool AddEdit(User user)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_AddEdit";
                dataManager.Add("@UserID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, user.UserId);
                dataManager.Add("@FirstName", SqlDbType.NVarChar, ParameterDirection.Input, user.FirstName);
                dataManager.Add("@LastName", SqlDbType.NVarChar, ParameterDirection.Input, user.LastName);
                dataManager.Add("@Login", SqlDbType.NVarChar, ParameterDirection.Input, user.Login);
                dataManager.Add("@Password", SqlDbType.NVarChar, ParameterDirection.Input, user.Password);
                dataManager.Add("@UserStatus", SqlDbType.Int, ParameterDirection.Input, (int)user.UserStatus);
                dataManager.Add("@RoleType", SqlDbType.Int, ParameterDirection.Input, (user.Roles != null && user.Roles.Count > 0) ? (int)user.Roles[0].RoleType : (int)RoleType.Recruiter);
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        public static bool Delete(Guid userId)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_Delete";
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userId);
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Get Users list
        /// </summary>
        public static List<User> List()
        {
            List<User> users = new List<User>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_List";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                users.UnpackXML(xmlOut);
            }

            return users;
        }

        /// <summary>
        /// Get Users list
        /// </summary>
        public static List<User> ListRecruiters()
        {
            List<User> users = new List<User>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "auth.Users_List_Recruiters";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                users.UnpackXML(xmlOut);
            }

            return users;
        }
    }
}
