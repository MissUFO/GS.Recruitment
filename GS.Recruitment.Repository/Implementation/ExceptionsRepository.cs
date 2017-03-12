using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Framework.SQLDataAccess;
using GS.Recruitment.Repository.Interface;
using System;
using System.Data;
using System.Xml.Linq;
using System.Collections.Generic;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;

namespace GS.Recruitment.Repository.Implementation
{
    public class ExceptionsRepository: IRepository<SysException>
    {
        public string ConnectionString { get; set; }

        public ExceptionsRepository()
		{
            ConnectionString = WebConfigConnectionString.RecruitmentConnection;
        }

        /// <summary>
        /// Get exception info by id
        /// </summary>
        public SysException Get(Guid id)
        {
            SysException entity = new SysException();

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "log.Exceptions_Get";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("Exception"));
            }

            return entity;
        }

        /// <summary>
        /// AddEdit exception
        /// </summary>
        public bool AddEdit(SysException entity)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "log.Exceptions_AddEdit";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, entity.UserId);
                dataManager.Add("@Message", SqlDbType.NVarChar, ParameterDirection.Input, entity.Message);
                dataManager.Add("@Exception", SqlDbType.NVarChar, ParameterDirection.Input, entity.Exception);
                dataManager.Add("@Location", SqlDbType.NVarChar, ParameterDirection.Input, entity.Location);
                dataManager.Add("@ExceptionType", SqlDbType.TinyInt, ParameterDirection.Input, entity.ExceptionType);
                dataManager.Add("@ExceptionOn", SqlDbType.DateTime, ParameterDirection.Input, entity.ExceptionOn);
                dataManager.Add("@UserId", SqlDbType.UniqueIdentifier, ParameterDirection.Input, entity.UserId);

                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Get all exceptions
        /// </summary>
        public List<SysException> List()
        {
            List<SysException> list = new List<SysException>();

            using (DataManager dataManager = new DataManager(WebConfigConnectionString.RecruitmentConnection))
            {
                dataManager.ExecuteString = "log.Exceptions_List";
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                list.UnpackXML(xmlOut);
            }

            return list;
        }

        /// <summary>
        /// Delete exception from DB
        /// </summary>
        public bool Delete(Guid id)
        {
            bool result = false;

            using (DataManager dataManager = new DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "log.Exceptions_Delete";
                dataManager.Add("@Id", SqlDbType.UniqueIdentifier, ParameterDirection.Input, id);
                dataManager.ExecuteNonQuery();

                result = true;
            }

            return result;
        }
        
    }
}
