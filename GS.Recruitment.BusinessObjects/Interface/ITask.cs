using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Recruitment.BusinessObjects.Interface
{
    public interface ITask
    {
         Guid Id { get; set; }
        
         string Title { get; set; }
      
         string Description { get; set; }
       
         Guid UserFromId { get; set; }
       
         string UserFromLogin { get; set; }
      
         Guid UserToId { get; set; }
      
         string UserToLogin { get; set; }
       
         TaskStatus TaskStatus { get; set; }
       
         DateTime CreatedOn { get; set; }
      
         DateTime ModifiedOn { get; set; }
       
         Guid CreatedBy { get; set; }
       
         Guid ModifiedBy { get; set; }
        
         List<Assignment> Assignments { get; set; }
    }
}
