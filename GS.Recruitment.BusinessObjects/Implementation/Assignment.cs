using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
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
        public string Number { get; set; }

        [DataMember]
        public Guid TaskId { get; set; }

        [DataMember]
        public Task Task { get { return _task; } set { _task = value; } }
        private Task _task = new Task();

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
        public List<AssignmentContact> AssignmentContacts { get { return _assignmentContacts; } set { _assignmentContacts = value; } }
        private List<AssignmentContact> _assignmentContacts = new List<AssignmentContact>();

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.Number = "A" + xml.Attribute("Number").ToType<int>();
            this.TaskId = xml.Attribute("TaskId").ToType<Guid>();
            this.Name = xml.Attribute("Title").ToType<string>();
            this.Title = xml.Attribute("Title").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.UserFromId = xml.Attribute("UserFromId").ToType<Guid>();
            this.UserFromLogin = xml.Attribute("UserFromLogin").ToType<string>();
            this.UserToId = xml.Attribute("UserToId").ToType<Guid>();
            this.UserToLogin = xml.Attribute("UserToLogin").ToType<string>();
            this.AssignmentStatus = xml.Attribute("AssignmentStatus").ToEnum<AssignmentStatus>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.CreatedBy = xml.Attribute("CreatedBy").ToType<Guid>();
            this.ModifiedBy = xml.Attribute("ModifiedBy").ToType<Guid>();

            this.Task.UnpackXML(xml);

            this.AssignmentContacts.UnpackXML<AssignmentContact>(xml.Element("AssignmentContacts"));
        }
    }
}
