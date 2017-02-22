using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Recruiters tasks
    /// </summary>
    [DataContract]
    public class Task : Entity
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Number { get; set; }

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
        public TaskStatus TaskStatus { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }
        [DataMember]
        public Guid CreatedBy { get; set; }
        [DataMember]
        public Guid ModifiedBy { get; set; }
        [DataMember]
        public List<Assignment> Assignments { get { return _assignments; } set { _assignments = value; } }
        private List<Assignment> _assignments = new List<Assignment>();


        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.Number = "T" + xml.Attribute("Number").ToType<int>();
            this.Name = xml.Attribute("Title").ToType<string>();
            this.Title = xml.Attribute("Title").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.UserFromId = xml.Attribute("UserFromId").ToType<Guid>();
            this.UserFromLogin = xml.Attribute("UserFromLogin").ToType<string>();
            this.UserToId = xml.Attribute("UserToId").ToType<Guid>();
            this.UserToLogin = xml.Attribute("UserToLogin").ToType<string>();
            this.TaskStatus = xml.Attribute("TaskStatus").ToEnum<TaskStatus>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.CreatedBy = xml.Attribute("CreatedBy").ToType<Guid>();
            this.ModifiedBy = xml.Attribute("ModifiedBy").ToType<Guid>();

            this.Assignments.UnpackXML<Assignment>(xml);

        }
    }
}
