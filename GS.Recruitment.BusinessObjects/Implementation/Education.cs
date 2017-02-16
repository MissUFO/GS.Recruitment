using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate education
    /// </summary>
    [DataContract]
    public class Education : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Guid CityId { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public bool IsCurrent { get; set; }
        [DataMember]
        public bool IsGraduated { get; set; }
        [DataMember]
        public string GraduatedAs { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.Name = xml.Attribute("Name").ToType<string>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.CityId = xml.Attribute("CityId").ToType<Guid>();
            this.CityName = xml.Attribute("CityName").ToType<string>();
            this.DateFrom = xml.Attribute("DateFrom").ToType<DateTime>();
            this.DateTo = xml.Attribute("DateTo").ToType<DateTime>();
            this.IsCurrent = xml.Attribute("IsCurrent").ToType<bool>();
            this.IsGraduated = xml.Attribute("IsGraduated").ToType<bool>();
            this.GraduatedAs = xml.Attribute("GraduatedAs").ToType<string>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
