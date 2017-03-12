using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using GS.Recruitment.Repository.Interface;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class ExceptionsBusinessService
    {
        public IRepository<SysException> dataRepository { get; set; }

        public ExceptionsBusinessService()
        {
            dataRepository = new ExceptionsRepository();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        public SysException Get(Guid id)
        {
            return dataRepository.Get(id);
        }

        /// <summary>
        /// AddEdit
        /// </summary>
        public bool AddEdit(SysException entity)
        {
            return dataRepository.AddEdit(entity);
        }

        /// <summary>
        /// Get list
        /// </summary>
        public List<SysException> List()
        {
            return dataRepository.List();
        }

        /// <summary>
        /// Delete 
        /// </summary>
        public bool Delete(Guid id)
        {
            return dataRepository.Delete(id);
        }

    }
}
