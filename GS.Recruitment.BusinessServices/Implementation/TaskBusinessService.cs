using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
    public class TaskBusinessService
    {
        protected TaskRepository dataRepository { get; set; }

        public TaskBusinessService()
        {
            dataRepository = new TaskRepository();
        }

        /// <summary>
        /// Get task by taskid
        /// </summary>
        public Task Get(Guid id)
        {
            return dataRepository.Get(id);
        }

        /// <summary>
        /// AddEdit task
        /// </summary>
        /// <param name="task"></param>
        public bool AddEdit(Task task)
        {
            return dataRepository.AddEdit(task);
        }

        /// <summary>
        /// Get tasks list
        /// </summary>
        public List<Task> List()
        {
            return dataRepository.List();
        }

        /// <summary>
        /// Get tasks list by user from id
        /// </summary>
        public List<Task> ListUserFrom(Guid userId)
        {
            return dataRepository.ListUserFrom(userId);
        }

        /// <summary>
        /// Get tasks list by user to id
        /// </summary>
        public List<Task> ListUserTo(Guid userId)
        {
            return dataRepository.ListUserTo(userId);
        }

        /// <summary>
        /// Delete task
        /// </summary>
        public bool Delete(Guid id)
        {
            return dataRepository.Delete(id);
        }

    }
}
