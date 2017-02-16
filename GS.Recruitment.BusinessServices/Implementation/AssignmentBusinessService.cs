using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessServices.Implementation
{
	public class AssignmentBusinessService
    {
		public AssignmentBusinessService()
		{
		}

        /// <summary>
        /// Get assignment by id
        /// </summary>
        public Assignment Get(Guid id)
        {
            return AssignmentRepository.Get(id);
        }

        /// <summary>
        /// AddEdit assignment
        /// </summary>
        /// <param name="task"></param>
        public bool AddEdit(Assignment assignment)
        {
            return AssignmentRepository.AddEdit(assignment);
        }
        /// <summary>
        /// Get assignments list by user to id
        /// </summary>
        public List<Assignment> ListUserTo(Guid userId)
        {
            return AssignmentRepository.ListUserTo(userId);
        }
    }
}
