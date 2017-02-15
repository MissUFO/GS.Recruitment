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
    /// Candidate education
    /// </summary>
    [DataContract]
    public class Education : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsGraduated { get; set; }
        public string GraduatedAs { get; set; }
        public DateTime CreatedOn { get; set; }
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
