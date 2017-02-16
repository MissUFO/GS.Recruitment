using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// User settings
    /// </summary>
    [DataContract]
    public class UserSettings : Entity
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public bool SystemNotifications { get; set; }
        [DataMember]
        public bool EmailNotifications { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }

        public UserSettings() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.UserId = xml.Attribute("UserId").ToType<Guid>();
            this.SystemNotifications = xml.Attribute("SystemNotifications").ToType<bool>();
            this.EmailNotifications = xml.Attribute("EmailNotifications").ToType<bool>();
            
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
        

    }
}
