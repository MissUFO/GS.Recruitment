using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class NotificationBusinessService
    {
        private NotificationRepository dataRepository { get; set; }

        public NotificationBusinessService()
        {
            dataRepository = new NotificationRepository();
        }

        /// <summary>
        /// Get notification by id
        /// </summary>
        public Notification Get(Guid id)
        {
            return dataRepository.Get(id);
        }

        /// <summary>
        /// AddEdit notification
        /// </summary>
        public bool AddEdit(Notification notification)
        {
            return dataRepository.AddEdit(notification);
        }

        /// <summary>
        /// Get notifications list
        /// </summary>
        public List<Notification> List(Guid userId)
        {
            return dataRepository.List(userId, null);
        }

        /// <summary>
        /// Delete notification
        /// </summary>
        public bool Delete(Guid id)
        {
            return dataRepository.Delete(id);
        }

        /// <summary>
        /// Receive notification
        /// </summary>
        public bool Receive(Notification notification)
        {
            notification.IsReceived = true;
            return dataRepository.AddEdit(notification);
        }

    }
}
