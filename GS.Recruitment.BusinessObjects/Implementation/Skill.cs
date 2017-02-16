using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate skills
    /// </summary>
    [DataContract]
    public class Skill : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid SkillId { get; set; }
        [DataMember]
        public string SkillName { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.SkillId = xml.Attribute("SkillId").ToType<Guid>();
            this.SkillName = xml.Attribute("SkillName").ToType<string>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
