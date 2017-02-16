using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Notifications
    /// </summary>
    [DataContract]
    public class Notification : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Guid EntityId { get; set; }
        [DataMember]
        public NotificationEntityTypes EntityType { get; set; }
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public string UserLogin { get; set; }
        [DataMember]
        public NotificationTypes NotificationType { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public bool IsReceived { get; set; }
        [DataMember]
        public DateTime ReceivedOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.Name = xml.Attribute("Subject").ToType<string>();
            this.Subject = xml.Attribute("Subject").ToType<string>();
            this.Message = xml.Attribute("Message").ToType<string>();
            this.EntityId = xml.Attribute("EntityId").ToType<Guid>();
            this.EntityType = xml.Attribute("EntityType").ToEnum<NotificationEntityTypes>();
            this.UserId = xml.Attribute("UserId").ToType<Guid>();
            this.UserLogin = xml.Attribute("UserLogin").ToType<string>();
            this.NotificationType = xml.Attribute("NotificationType").ToEnum<NotificationTypes>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.IsReceived = xml.Attribute("IsReceived").ToType<bool>();
            this.ReceivedOn = xml.Attribute("ReceivedOn").ToType<DateTime>();
        }
    }
}
