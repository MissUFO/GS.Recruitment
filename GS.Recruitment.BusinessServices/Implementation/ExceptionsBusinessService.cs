using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using GS.Recruitment.Repository.Interface;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class ExceptionsBusinessService
    {
        public IRepository<SysException> DataRepository { get; set; }

        public ExceptionsBusinessService()
        {
            DataRepository = new ExceptionsRepository();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        public SysException Get(Guid id)
        {
            return DataRepository.Get(id);
        }

        /// <summary>
        /// AddEdit
        /// </summary>
        public bool AddEdit(SysException entity)
        {
            return DataRepository.AddEdit(entity);
        }

        /// <summary>
        /// Get list
        /// </summary>
        public List<SysException> List()
        {
            return DataRepository.List();
        }

        /// <summary>
        /// Delete 
        /// </summary>
        public bool Delete(SysException entity)
        {
            return DataRepository.Delete(entity);
        }

    }
}
