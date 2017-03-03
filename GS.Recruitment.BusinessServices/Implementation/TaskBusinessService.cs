using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class TaskBusinessService
    {
        protected NotificationBusinessService notification { get; set; }
        public TaskBusinessService()
        {
            notification = new NotificationBusinessService();
        }

        /// <summary>
        /// Get task by taskid
        /// </summary>
        public Task Get(Guid id)
        {
            return TaskRepository.Get(id);
        }

        /// <summary>
        /// AddEdit task
        /// </summary>
        /// <param name="task"></param>
        public bool AddEdit(Task task)
        {
            return TaskRepository.AddEdit(task);
        }

        /// <summary>
        /// Get tasks list
        /// </summary>
        public List<Task> List()
        {
            return TaskRepository.List();
        }

        /// <summary>
        /// Get tasks list by user from id
        /// </summary>
        public List<Task> ListUserFrom(Guid userId)
        {
            return TaskRepository.ListUserFrom(userId);
        }

        /// <summary>
        /// Get tasks list by user to id
        /// </summary>
        public List<Task> ListUserTo(Guid userId)
        {
            return TaskRepository.ListUserTo(userId);
        }

    }
}
