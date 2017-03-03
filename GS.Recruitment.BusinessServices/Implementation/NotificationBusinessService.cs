using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class NotificationBusinessService
    {
        private NotificationRepository repo = new NotificationRepository();

        public NotificationBusinessService()
        {
        }

        /// <summary>
        /// Get notification by id
        /// </summary>
        public Notification Get(Guid id)
        {
            return repo.Get(id);
        }

        /// <summary>
        /// AddEdit notification
        /// </summary>
        /// <param name="task"></param>
        public bool AddEdit(Notification notification)
        {
            return repo.AddEdit(notification);
        }

        /// <summary>
        /// Get notifications list
        /// </summary>
        public List<Notification> List(Guid userId)
        {
            return repo.List(userId, null);
        }

        /// <summary>
        /// Delete notification
        /// </summary>
        /// <param name="task"></param>
        public bool Delete(Notification notification)
        {
            return repo.Delete(notification);
        }

        /// <summary>
        /// Receive notification
        /// </summary>
        /// <param name="task"></param>
        public bool Receive(Notification notification)
        {
            notification.IsReceived = true;
            return repo.AddEdit(notification);
        }

    }
}
