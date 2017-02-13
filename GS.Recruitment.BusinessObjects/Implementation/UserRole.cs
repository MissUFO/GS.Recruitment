using GS.Recruitment.BusinessObjects.Enum;
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
    /// User role
    /// </summary>
    [DataContract]
    public class UserRole : Entity
    {
        [DataMember]
        public Guid RoleId { get; set; }
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public RoleType RoleType { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }

        public UserRole() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.RoleId = xml.Attribute("RoleId").ToType<Guid>();
            this.Id = RoleId;
            this.UserId = xml.Attribute("UserID").ToType<Guid>();
            this.RoleType = xml.Attribute("RoleType").ToEnum<RoleType>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}