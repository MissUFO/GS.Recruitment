using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using GS.Recruitment.BusinessObjects.Interface;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// User object. Represents users in different roles
    /// </summary>
    [DataContract]
    public class User : Entity, IUser
    {
        [DataMember]
        public Guid UserId { get; set; }
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
        public UserStatus UserStatus { get; set; }

        [DataMember]
        public List<UserSettings> UserSettings { get { return _userSettings; } set { _userSettings = value; } }
        private List<UserSettings> _userSettings = new List<UserSettings>();

        [DataMember]
        public List<UserRole> Roles { get { return _roles; } set { _roles = value; } }
        private List<UserRole> _roles = new List<UserRole>();
       
        [DataMember]
        public bool IsActive { get; set; }

        public User() { }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.UserId = xml.Attribute("Id").ToType<Guid>();
            this.FirstName = xml.Attribute("FirstName").ToType<string>();
            this.LastName = xml.Attribute("LastName").ToType<string>();
            this.Login = xml.Attribute("Login").ToType<string>();
            this.Password = xml.Attribute("Password").ToType<string>();

            this.Name = (string.IsNullOrEmpty(this.FirstName) == false || string.IsNullOrEmpty(this.LastName) == false) ? this.FirstName + " " + this.LastName : this.Login;

            this.LastLoginOn = xml.Attribute("LastLoginOn").ToType<DateTime>();
            this.LastPasswordChangedOn = xml.Attribute("LastPasswordChangedOn").ToType<DateTime>();
            this.FailedPasswordAttemptCount = xml.Attribute("FailedPasswordAttemptCount").ToType<int>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
            this.UserStatus = xml.Attribute("UserStatus").ToEnum<UserStatus>();

            this.IsActive = (this.UserStatus == UserStatus.Active);

            this.UserSettings.UnpackXML<UserSettings>(xml);

            this.Roles.UnpackXML<UserRole>(xml);

        }

        public void AddRole(UserRole role)
        {
            if (Roles == null)
                Roles = new List<UserRole>();

            if (Roles.Any( r => r.RoleType==role.RoleType ) == false)
                Roles.Add(role);
        }

    }
}
