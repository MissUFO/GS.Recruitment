using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate phone
    /// </summary>
    [DataContract]
    public class Phone : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public bool IsPreferred { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.PhoneNumber = xml.Attribute("Phone").ToType<string>();
            this.IsPreferred = xml.Attribute("IsPreferred").ToType<bool>();
        }
    }
}
