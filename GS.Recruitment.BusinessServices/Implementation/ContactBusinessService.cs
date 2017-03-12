using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class ContactBusinessService
    {
        protected ContactRepository dataRepository { get; set; }

        public ContactBusinessService()
        {
            dataRepository = new ContactRepository();
        }

        /// <summary>
        /// List of contacts
        /// </summary>
        public List<Contact> List()
        {
            return dataRepository.List();
        }

        /// <summary>
        /// List of candidates
        /// </summary>
        public List<Contact> ListCandidates()
        {
            return dataRepository.ListCandidates();
        }

        /// <summary>
        /// Get contact details by id
        /// </summary>
        public Contact Get(Guid id)
        {
            return dataRepository.Get(id);
        }

        /// <summary>
        /// Add or edit contact details
        /// </summary>
        public bool AddEdit(Contact item)
        {
            return dataRepository.AddEdit(item);
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        public bool Delete(Guid id)
        {
            return dataRepository.Delete(id);
        }
    }
}
