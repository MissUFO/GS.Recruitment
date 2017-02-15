using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate job preferences
    /// </summary>
    [DataContract]
    public class JobPreference : Entity
    {
        public Guid Id{ get; set; }
        public decimal SalaryFrom{ get; set; }
        public decimal SalaryTo{ get; set; }
        public Guid JobTitleId{ get; set; }
        public string JobTitle{ get; set; }
        public Guid CityId{ get; set; }
        public string CityName{ get; set; }
        public string CountryName{ get; set; }
        public Guid CountryId{ get; set; }
        public bool IsReadyForRelocation{ get; set; }
        public string Description{ get; set; }
        public DateTime LastContactDate{ get; set; }
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
            this.IsReadyForRelocation = xml.Attribute("IsReadyForRelocation").ToType<bool>();
            this.Description = xml.Attribute("Description").ToType<string>();
            this.LastContactDate = xml.Attribute("LastContactDate").ToType<DateTime>();
            this.LastContactedBy = xml.Attribute("LastContactedBy").ToType<Guid>();
        }
    }
}
