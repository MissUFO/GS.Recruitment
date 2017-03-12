using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
	public class UserBusinessService
    {
        protected UserRepository repo { get; set; }

        public UserBusinessService()
        {
            repo = new UserRepository();
        }

        /// <summary>
        /// List of users
        /// </summary>
        public List<User> List()
        {
            return repo.List();
        }

        /// <summary>
        /// List of Recruiters
        /// </summary>
        public List<User> ListRecruiters()
        {
            return repo.ListRecruiters();
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        public User Get(Guid id)
        {
            return repo.Get(id);
        }

        /// <summary>
        /// Check the login 
        /// </summary>
        public User Login(string login, string password)
        {
            return repo.Login(login, password);
        }

        /// <summary>
        /// Add or edit user
        /// </summary>
        public bool AddEdit(User item)
        {
            return repo.AddEdit(item);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        public bool Delete(Guid id)
        {
            return repo.Delete(id);
        }

        /// <summary>
        /// Change user status (active, disabled)
        /// </summary>
        public bool ChangeStatus(Guid id, int statusID)
        {
            return repo.ChangeStatus(id, statusID);
        }

        /// <summary>
        /// Change user password
        /// </summary>
        public bool ChangePassword(Guid id, string password)
        {
            return repo.ChangePassword(id, password);
        }
    }
}
