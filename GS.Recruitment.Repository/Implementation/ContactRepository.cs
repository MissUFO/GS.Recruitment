using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace GS.Recruitment.Repository.Implementation
{
	public class ContactRepository
    {
		public ContactRepository()
		{
		}

        /// <summary>
        /// Get contact by contactdetailid
        /// </summary>
        public static Contact Get(Guid id)
        {
            Contact contact = new Contact();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "contact.Details_Get";
                dataManager.Add("@ContactDetailId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                contact.UnpackXML(xmlOut.Element("Contact"));
            }

            return contact;
        }

        /// <summary>
        /// AddEdit contact
        /// </summary>
        /// <param name="user"></param>
        public static bool AddEdit(Contact contact)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "contact.Details_AddEdit";
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
        /// Get contacts list
        /// </summary>
        public static List<Contact> List()
        {
            List<Contact> contacts = new List<Contact>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "contact.Details_List";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                contacts.UnpackXML(xmlOut);
            }

            return contacts;
        }

        /// <summary>
        /// Get candidates list
        /// </summary>
        public static List<Contact> ListCandidates()
        {
            List<Contact> contacts = new List<Contact>();

            using (DataManager dataManager = new DataManager(ConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "contact.Details_List_Candidates";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                contacts.UnpackXML(xmlOut);
            }

            return contacts;
        }

    }
}
