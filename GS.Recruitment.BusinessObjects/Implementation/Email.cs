using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate email
    /// </summary>
    [DataContract]
    public class Email : Entity
    {
        [DataMember]
        public Guid Id {get;set;}
        [DataMember]
        public string EmailAddress{get;set;}
        [DataMember]
        public bool IsPreferred{get;set;}

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.EmailAddress = xml.Attribute("Email").ToType<string>();
            this.IsPreferred = Convert.ToBoolean(xml.Attribute("IsPreferred").ToType<int>());
        }
    }
}
