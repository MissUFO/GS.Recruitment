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
    /// Candidate experience
    /// </summary>
    [DataContract]
    public class Experience : Entity
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Guid JobTitleId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime CreatedOn { get; set; }
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
