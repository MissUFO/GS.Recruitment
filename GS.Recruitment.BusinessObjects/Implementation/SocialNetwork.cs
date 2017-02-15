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
    /// Candidate social networks info
    /// </summary>
    [DataContract]
    public class SocialNetwork : Entity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string ProfileUrl { get; set; }
        public int SocialNetworkType { get; set; }
        public DateTime CreatedOn { get; set; }
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
