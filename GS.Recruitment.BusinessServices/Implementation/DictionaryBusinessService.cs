﻿using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class DictionaryBusinessService
    {
        protected DictionaryRepository dataRepository { get; set; }

        public DictionaryBusinessService()
        {
            dataRepository = new DictionaryRepository();
        }

        public DictionaryItem Get(string name, Guid id)
        {
            return dataRepository.Get(name, id);
        }

        public bool AddEdit(string name, DictionaryItem entity)
        {
            return dataRepository.AddEdit(name, entity);
        }


        public List<DictionaryItem> List(string name)
        {
            return dataRepository.List(name);
        }

        public List<DictionaryItem> List(string name, Guid parentId)
        {
            return dataRepository.List(name, parentId);
        }

        public bool Delete(string name, DictionaryItem entity)
        {
            return dataRepository.Delete(name, entity);
        }
       
    }
}
