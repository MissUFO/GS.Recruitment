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

        public User Get(int id)
        {
            return UserRepository.Get(id);
        }

        public User Login(string login, string password)
        {
            return UserRepository.Login(login, password);
        }

        public void UserAddEdit(User item)
        {
            UserRepository.UserAddEdit(item);
        }

        public void ChangeStatus(int userID, int statusID)
        {
            UserRepository.ChangeStatus(userID, statusID);
        }

        public void ChangePassword(int userID, string password)
        {
            UserRepository.ChangePassword(userID, password);
        }
    }
}
