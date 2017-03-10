using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// System exceptions
    /// </summary>
    [DataContract]
    public class SysException : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Exception { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public ExceptionType ExceptionType { get; set; }
        [DataMember]
        public DateTime ExceptionOn { get; set; }
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }

        public SysException() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.Name = xml.Attribute("Message").ToType<string>();
            this.Message = xml.Attribute("Message").ToType<string>();
            this.Exception = xml.Attribute("Exception").ToType<string>();
            this.Location = xml.Attribute("Location").ToType<string>();
            this.ExceptionType = xml.Attribute("ExceptionType").ToEnum<ExceptionType>();

            this.UserId = xml.Attribute("UserId").ToType<Guid>();
            this.UserName = xml.Attribute("UserName").ToType<string>();
            this.ExceptionOn = xml.Attribute("ExceptionOn").ToType<DateTime>();
        }
        

    }
}
