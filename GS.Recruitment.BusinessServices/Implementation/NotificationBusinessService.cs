using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class NotificationBusinessService
    {
        public NotificationBusinessService()
        {
        }

        /// <summary>
        /// Get notification by id
        /// </summary>
        public Notification Get(Guid id)
        {
            return NotificationRepository.Get(id);
        }

        /// <summary>
        /// AddEdit notification
        /// </summary>
        /// <param name="task"></param>
        public bool AddEdit(Notification notification)
        {
            return NotificationRepository.AddEdit(notification);
        }

        /// <summary>
        /// Get notifications list
        /// </summary>
        public List<Notification> List(Guid userId)
        {
            return NotificationRepository.List(userId);
        }
        

    }
}
