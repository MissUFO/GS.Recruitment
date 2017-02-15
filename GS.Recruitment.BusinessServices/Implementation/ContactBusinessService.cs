using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
	public class ContactBusinessService
    {
		public ContactBusinessService()
		{
		}

        public List<Contact> List()
        {
            return ContactRepository.List();
        }

        public List<Contact> ListCandidates()
        {
            return ContactRepository.ListCandidates();
        }

        public Contact Get(Guid id)
        {
            return ContactRepository.Get(id);
        }
        
        public bool AddEdit(Contact item)
        {
            return ContactRepository.AddEdit(item);
        }
    }
}
