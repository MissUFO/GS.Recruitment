using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessObjects.Interface
{
    public interface IAssignment
    {
         Guid Id { get; set; }
       
         Guid TaskId { get; set; }
        
         string Title { get; set; }
       
         string Description { get; set; }
        
         Guid UserFromId { get; set; }
        
         string UserFromLogin { get; set; }
       
         Guid UserToId { get; set; }
      
         string UserToLogin { get; set; }
        
         AssignmentStatus AssignmentStatus { get; set; }
       
         DateTime CreatedOn { get; set; }
        
         DateTime ModifiedOn { get; set; }
       
         List<Contact> Contacts { get; set; }
    }
}
