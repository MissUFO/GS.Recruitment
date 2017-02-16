using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate experience
    /// </summary>
    [DataContract]
    public class Experience : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid CompanyId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public Guid JobTitleId { get; set; }
        [DataMember]
        public string JobTitle { get; set; }
        [DataMember]
        public string JobDescription { get; set; }
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
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.CompanyId = xml.Attribute("Id").ToType<Guid>();
            this.CompanyName = xml.Attribute("CompanyName").ToType<string>();
            this.JobTitleId = xml.Attribute("JobTitleId").ToType<Guid>();
            this.JobTitle = xml.Attribute("JobTitle").ToType<string>();
            this.JobDescription = xml.Attribute("JobDescription").ToType<string>();
            this.CityId = xml.Attribute("CityId").ToType<Guid>();
            this.CityName = xml.Attribute("CityName").ToType<string>();
            this.DateFrom = xml.Attribute("DateFrom").ToType<DateTime>();
            this.DateTo = xml.Attribute("DateTo").ToType<DateTime>();
            this.IsCurrent = xml.Attribute("IsCurrent").ToType<bool>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
