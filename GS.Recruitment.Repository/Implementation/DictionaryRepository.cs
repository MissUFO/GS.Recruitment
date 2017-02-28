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
	public class DictionaryRepository : IDictionaryRepository<DictionaryItem>
    {
        public string ConnectionString { get; set; }

        public DictionaryRepository()
        {
            ConnectionString = WebConfigConnectionString.RecruitmentConnection;
        }
        
        public DictionaryItem Get(string name, Guid id)
        {
            DictionaryItem entity = new DictionaryItem();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = string.Format("enum.{0}_Get", name);
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("DictionaryItem"));
            }

            return entity;
        }

        public bool AddEdit(string name, DictionaryItem entity)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = string.Format("enum.{0}_AddEdit", name);
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, entity.Id);
                dataManager.Add("@Name", SqlDbType.NVarChar, ParameterDirection.Input, entity.Name);
                dataManager.Add("@ParentId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, entity.ParentId);
                dataManager.Add("@OutputId", SqlDbType.UniqueIdentifier, ParameterDirection.Output);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        public List<DictionaryItem> List(string name)
        {
            List<DictionaryItem> entities = new List<DictionaryItem>();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = string.Format("enum.{0}_List", name);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entities.UnpackXML(xmlOut);
            }

            return entities;
        }

        public List<DictionaryItem> List(string name, Guid parentId)
        {
            List<DictionaryItem> entities = new List<DictionaryItem>();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = string.Format("enum.{0}_List", name);
                dataManager.Add("@ParentId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, parentId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entities.UnpackXML(xmlOut);
            }

            return entities;
        }

        public bool Delete(string name, DictionaryItem entity)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = string.Format("enum.{0}_Delete", name);
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, entity.Id);
                
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
    }
}
