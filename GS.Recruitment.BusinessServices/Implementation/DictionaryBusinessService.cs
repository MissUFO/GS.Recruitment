using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class DictionaryBusinessService
    {
        protected DictionaryRepository repo = new DictionaryRepository();

        public DictionaryBusinessService()
        {
        }

        public DictionaryItem Get(string name, Guid id)
        {
            return repo.Get(name, id);
        }

        public bool AddEdit(string name, DictionaryItem entity)
        {
            return repo.AddEdit(name, entity);
        }


        public List<DictionaryItem> List(string name)
        {
            return repo.List(name);
        }

        public List<DictionaryItem> List(string name, Guid parentId)
        {
            return repo.List(name, parentId);
        }

        public bool Delete(string name, DictionaryItem entity)
        {
            return repo.Delete(name, entity);
        }
       
    }
}
