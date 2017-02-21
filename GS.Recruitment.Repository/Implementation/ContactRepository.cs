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
                dataManager.Add("@ContactDetailId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, contact.Id);
                dataManager.Add("@FirstName", SqlDbType.NVarChar, ParameterDirection.Input, contact.FirstName);
                dataManager.Add("@LastName", SqlDbType.NVarChar, ParameterDirection.Input, contact.LastName);
                dataManager.Add("@MiddleName", SqlDbType.NVarChar, ParameterDirection.Input, contact.MiddleName);
                dataManager.Add("@Address", SqlDbType.NVarChar, ParameterDirection.Input, contact.Address);
                dataManager.Add("@PostCode", SqlDbType.NVarChar, ParameterDirection.Input, contact.PostCode);
                dataManager.Add("@CityId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, contact.CityId);
                dataManager.Add("@CountryId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, contact.CountryId);
                dataManager.Add("@Birthday", SqlDbType.DateTime, ParameterDirection.Input, contact.Birthday);
                dataManager.Add("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, contact.CreatedOn != DateTime.MinValue ? contact.CreatedOn : DateTime.Now);
                dataManager.Add("@ModifiedOn", SqlDbType.DateTime, ParameterDirection.Input, contact.ModifiedOn != DateTime.MinValue ? contact.ModifiedOn : DateTime.Now);
                dataManager.Add("@CreatedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, contact.CreatedBy);
                dataManager.Add("@ModifiedBy", SqlDbType.UniqueIdentifier, ParameterDirection.Input, contact.ModifiedBy);
                dataManager.Add("@OutputId", SqlDbType.UniqueIdentifier, ParameterDirection.Output);

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
