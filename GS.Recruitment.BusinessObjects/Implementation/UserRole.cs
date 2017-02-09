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
        public int UserRoleID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public RoleType RoleTypeID { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

        public UserRole() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.UserRoleID = xml.Attribute("UserRoleID").ToType<int>();
            this.ID = UserRoleID;
            this.UserID = xml.Attribute("UserID").ToType<int>();
            this.RoleTypeID = xml.Attribute("RoleTypeID").ToEnum<RoleType>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.IsActive = Convert.ToBoolean(xml.Attribute("IsActive").ToType<byte>());
        }
    }
}