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
    /// Candidate phone
    /// </summary>
    [DataContract]
    public class Phone : Entity
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPreferred { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.PhoneNumber = xml.Attribute("Phone").ToType<string>();
            this.IsPreferred = xml.Attribute("IsPreferred").ToType<bool>();
        }
    }
}
