using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessObjects.Interface
{
    public interface IContact
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string MiddleName { get; set; }

        string Address { get; set; }

        string PostCode { get; set; }

        Guid? CityId { get; set; }

        string CityName { get; set; }

        Guid? CountryId { get; set; }

        string CountryName { get; set; }

        DateTime? Birthday { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }

        Guid CreatedBy { get; set; }

        Guid ModifiedBy { get; set; }

        List<Email> Emails { get; set; }
        List<Phone> Phones { get; set; }
        List<Attachment> Attachments { get; set; }
        List<Education> Educations { get; set; }
        List<Experience> Experiences { get; set; }
        List<JobPreference> JobPreferences { get; set; }
        List<Skill> Skills { get; set; }
        List<SocialNetwork> SocialNetworks { get; set; }
    }
}
