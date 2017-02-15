using GS.Recruitment.BusinessObjects.Interface;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate contacts and details
    /// </summary>
    [DataContract]
    public class Contact : Entity, IContact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }

        public List<Email> Emails { get { return _emails; } set { _emails = value; } }
        private List<Email> _emails = new List<Email>();
        public List<Phone> Phones { get { return _phones; } set { _phones = value; } }
        private List<Phone> _phones = new List<Phone>();
        public List<Attachment> Attachments { get { return _attachments; } set { _attachments = value; } }
        private List<Attachment> _attachments = new List<Attachment>();
        public List<Education> Educations { get { return _educations; } set { _educations = value; } }
        private List<Education> _educations = new List<Education>();
        public List<Experience> Experiences { get { return _experiences; } set { _experiences = value; } }
        private List<Experience> _experiences = new List<Experience>();
        public List<JobPreference> JobPreferences { get { return _jobpreferences; } set { _jobpreferences = value; } }
        private List<JobPreference> _jobpreferences = new List<JobPreference>();
        public List<Skill> Skills { get { return _skills; } set { _skills = value; } }
        private List<Skill> _skills = new List<Skill>();
        public List<SocialNetwork> SocialNetworks { get { return _socialnetwork; } set { _socialnetwork = value; } }
        private List<SocialNetwork> _socialnetwork = new List<SocialNetwork>();

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();

            this.FirstName = xml.Attribute("FirstName").ToType<string>();
            this.LastName = xml.Attribute("LastName").ToType<string>();
            this.MiddleName = xml.Attribute("MiddleName").ToType<string>();

            this.Name = (string.IsNullOrEmpty(this.FirstName) == false || string.IsNullOrEmpty(this.LastName) == false) ? this.FirstName + " " + this.LastName : "";

            this.Address = xml.Attribute("Address").ToType<string>();
            this.PostCode = xml.Attribute("PostCode").ToType<string>();
            this.CityId = xml.Attribute("CityId").ToType<Guid>();
            this.CityName = xml.Attribute("CityName").ToType<string>();
            this.CountryId = xml.Attribute("CountryId").ToType<Guid>();
            this.CountryName = xml.Attribute("CountryName").ToType<string>();
            this.Birthday = xml.Attribute("Birthday").ToType<DateTime>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.CreatedBy = xml.Attribute("CreatedBy").ToType<Guid>();
            this.ModifiedBy = xml.Attribute("ModifiedBy").ToType<Guid>();

            this.Emails.UnpackXML<Email>(xml);
            this.Phones.UnpackXML<Phone>(xml);
            this.Attachments.UnpackXML<Attachment>(xml);
            this.Educations.UnpackXML<Education>(xml);
            this.Experiences.UnpackXML<Experience>(xml);
            this.JobPreferences.UnpackXML<JobPreference>(xml);
            this.Skills.UnpackXML<Skill>(xml);
            this.SocialNetworks.UnpackXML<SocialNetwork>(xml);
            
        }
    }
}
