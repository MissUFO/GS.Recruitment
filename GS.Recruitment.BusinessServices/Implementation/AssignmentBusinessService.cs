using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
	public class AssignmentBusinessService
    {
        protected AssignmentRepository dataRepository { get; set; }

        public AssignmentBusinessService()
		{
            dataRepository = new AssignmentRepository();
        }

        /// <summary>
        /// Get assignment by id
        /// </summary>
        public Assignment Get(Guid id)
        {
            return dataRepository.Get(id);
        }

        /// <summary>
        /// AddEdit assignment
        /// </summary>
        public bool AddEdit(Assignment assignment)
        {
            return dataRepository.AddEdit(assignment);
        }


        /// <summary>
        /// AddEdit contact into assignment
        /// </summary>
        public bool AssignmentContact_AddEdit(AssignmentContact assignmentContact)
        {
            return dataRepository.AssignmentContact_AddEdit(assignmentContact);
        }

        /// <summary>
        /// Get assignments list by user to id
        /// </summary>
        public List<Assignment> ListUserTo(Guid userId)
        {
            return dataRepository.ListUserTo(userId);
        }

        /// <summary>
        /// Get assignments list by task id
        /// </summary>
        public List<Assignment> ListTask(Guid taskId)
        {
            return dataRepository.ListTask(taskId);
        }

        /// <summary>
        /// Delete Assignment
        /// </summary>
        public bool Delete(Guid id)
        {
            return dataRepository.Delete(id);
        }
    }
}
