using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Candidate social networks info
    /// </summary>
    [DataContract]
    public class SocialNetwork : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ProfileUrl { get; set; }
        [DataMember]
        public int SocialNetworkType { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }
        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();

            this.UserName = xml.Attribute("UserName").ToType<string>();
            this.ProfileUrl = xml.Attribute("ProfileUrl").ToType<string>();
            this.SocialNetworkType = xml.Attribute("SocialNetworkType").ToType<int>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
