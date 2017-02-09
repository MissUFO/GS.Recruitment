using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// User object
    /// </summary>
    [DataContract]
    public class User : Entity
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime LastLoginOn { get; set; }
        [DataMember]
        public DateTime LastPasswordChangedOn { get; set; }
        [DataMember]
        public int FailedPasswordAttemptCount { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }
        [DataMember]
        public UserStatus StatusID { get; set; }
        [DataMember]
        public List<UserRole> Role { get { return _role; } set { _role = value; } }
        private List<UserRole> _role = new List<UserRole>();
        
        [DataMember]
        public bool IsActive { get; set; }

        public User() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.ID = xml.Attribute("UserID").ToType<int>();
            this.UserID = xml.Attribute("UserID").ToType<int>();
            this.FirstName = xml.Attribute("FirstName").ToType<string>();
            this.LastName = xml.Attribute("LastName").ToType<string>();
            this.Name = this.FirstName + " " + this.LastName;
            this.Login = xml.Attribute("Login").ToType<string>();
            this.Password = xml.Attribute("Password").ToType<string>();
            this.LastLoginOn = xml.Attribute("LastLoginOn").ToType<DateTime>();
            this.LastPasswordChangedOn = xml.Attribute("LastPasswordChangedOn").ToType<DateTime>();
            this.FailedPasswordAttemptCount = xml.Attribute("FailedPasswordAttemptCount").ToType<int>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.StatusID = xml.Attribute("StatusID").ToEnum<UserStatus>();

            this.IsActive = (this.StatusID == UserStatus.Active);

            this.Role.UnpackXML<UserRole>(xml);
        }

        public void AddRole(UserRole role)
        {
            if (Role == null)
                Role = new List<UserRole>();

            if (Role.Contains(role) == false)
                Role.Add(role);
        }

    }
}
