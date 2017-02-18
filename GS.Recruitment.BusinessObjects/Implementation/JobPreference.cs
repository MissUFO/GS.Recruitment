using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate job preferences
    /// </summary>
    [DataContract]
    public class JobPreference : Entity
    {
        [DataMember]
        public Guid Id{ get; set; }
        [DataMember]
        public decimal SalaryFrom{ get; set; }
        [DataMember]
        public decimal SalaryTo{ get; set; }
        [DataMember]
        public Guid JobTitleId{ get; set; }
        [DataMember]
        public string JobTitle{ get; set; }
        [DataMember]
        public Guid CityId{ get; set; }
        [DataMember]
        public string CityName{ get; set; }
        [DataMember]
        public string CountryName{ get; set; }
        [DataMember]
        public Guid CountryId{ get; set; }
        [DataMember]
        public bool IsReadyForRelocation{ get; set; }
        [DataMember]
        public string Description{ get; set; }
        [DataMember]
        public DateTime LastContactDate{ get; set; }
        [DataMember]
        public Guid LastContactedBy{ get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();

            this.SalaryFrom = xml.Attribute("SalaryFrom").ToType<decimal>();
            this.SalaryTo = xml.Attribute("SalaryTo").ToType<decimal>();
            this.JobTitleId = xml.Attribute("JobTitleId").ToType<Guid>();
            this.JobTitle = xml.Attribute("JobTitle").ToType<string>();
            this.CityId = xml.Attribute("CityId").ToType<Guid>();
            this.CityName = xml.Attribute("CityName").ToType<string>();
            this.CountryName = xml.Attribute("CountryName").ToType<string>();
            this.CountryId = xml.Attribute("CountryId").ToType<Guid>();
            this.IsReadyForRelocation = Convert.ToBoolean(xml.Attribute("IsReadyForRelocation").ToType<int>());
            this.Description = xml.Attribute("Description").ToType<string>();
            this.LastContactDate = xml.Attribute("LastContactDate").ToType<DateTime>();
            this.LastContactedBy = xml.Attribute("LastContactedBy").ToType<Guid>();
        }
    }
}
