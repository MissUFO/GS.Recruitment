using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Relationship between assignment and contact
    /// </summary>
    [DataContract]
    public class AssignmentContact : Entity
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid AssignmentId { get; set; }

        [DataMember]
        public Assignment Assignment { get { return _assignment; } set { _assignment = value; } }
        private Assignment _assignment = new Assignment();

        [DataMember]
        public Guid ContactId { get; set; }

        [DataMember]
        public Contact Contact { get { return _contact; } set { _contact = value; } }
        private Contact _contact = new Contact();

        [DataMember]
        public AssignmentContactStatus AssignmentContactStatus { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }
        [DataMember]
        public Guid CreatedBy { get; set; }
        [DataMember]
        public Guid ModifiedBy { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.AssignmentId = xml.Attribute("AssignmentId").ToType<Guid>();
            this.ContactId = xml.Attribute("ContactId").ToType<Guid>();
            this.Comment = xml.Attribute("Comment").ToType<string>();
            this.AssignmentContactStatus = xml.Attribute("AssignmentContactStatus").ToEnum<AssignmentContactStatus>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.CreatedBy = xml.Attribute("CreatedBy").ToType<Guid>();
            this.ModifiedBy = xml.Attribute("ModifiedBy").ToType<Guid>();

            this.Contact.UnpackXML(xml, "Contact");
            this.Assignment.UnpackXML(xml);
        }
    }
}
