using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Assignments in the task
    /// </summary>
    [DataContract]
    public class Assignment : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid TaskId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Guid UserFromId { get; set; }
        [DataMember]
        public string UserFromLogin { get; set; }
        [DataMember]
        public Guid UserToId { get; set; }
        [DataMember]
        public string UserToLogin { get; set; }
        [DataMember]
        public AssignmentStatus AssignmentStatus { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }
        [DataMember]
        public Guid CreatedBy { get; set; }
        [DataMember]
        public Guid ModifiedBy { get; set; }
        [DataMember]
        public List<Contact> Contacts { get { return _contacts; } set { _contacts = value; } }
        private List<Contact> _contacts = new List<Contact>();

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.Name = xml.Attribute("Title").ToType<string>();
            this.Title = xml.Attribute("Title").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.UserFromId = xml.Attribute("UserFromId").ToType<Guid>();
            this.UserFromLogin = xml.Attribute("UserFromLogin").ToType<string>();
            this.UserToId = xml.Attribute("UserToId").ToType<Guid>();
            this.UserToLogin = xml.Attribute("UserToLogin").ToType<string>();
            this.AssignmentStatus = xml.Attribute("TaskStatus").ToEnum<AssignmentStatus>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.CreatedBy = xml.Attribute("CreatedBy").ToType<Guid>();
            this.ModifiedBy = xml.Attribute("ModifiedBy").ToType<Guid>();

            this.Contacts.UnpackXML<Contact>(xml);
        }
    }
}
