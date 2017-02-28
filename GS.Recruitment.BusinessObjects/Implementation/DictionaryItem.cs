using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    [DataContract]
    public class DictionaryItem: Entity
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid ParentId { get; set; }
       
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
            this.ParentId = xml.Attribute("ParentId").ToType<Guid>();
            this.Name = xml.Attribute("Name").ToType<string>();

            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.CreatedBy = xml.Attribute("CreatedBy").ToType<Guid>();
            this.ModifiedBy = xml.Attribute("ModifiedBy").ToType<Guid>();
        }
    }
}
