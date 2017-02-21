using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
	public class UserBusinessService
    {
		public UserBusinessService()
		{
		}

        public List<User> List()
        {
            return UserRepository.List();
        }

        public List<User> ListRecruiters()
        {
            return UserRepository.ListRecruiters();
        }

        public User Get(Guid id)
        {
            return UserRepository.Get(id);
        }

        public User Login(string login, string password)
        {
            return UserRepository.Login(login, password);
        }

        public bool AddEdit(User item)
        {
            return UserRepository.AddEdit(item);
        }

        public bool Delete(Guid userId)
        {
            return UserRepository.Delete(userId);
        }

        public bool ChangeStatus(Guid id, int statusID)
        {
            return UserRepository.ChangeStatus(id, statusID);
        }

        public bool ChangePassword(Guid id, string password)
        {
            return UserRepository.ChangePassword(id, password);
        }
    }
}
