using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Dashboard
    /// </summary>
    [DataContract]
    public class Dashboard : Entity
    {
        [DataMember]
        public DashboardTasks Tasks { get { return _tasks; } set { _tasks = value; } }
        private DashboardTasks _tasks = new DashboardTasks();

        [DataMember]
        public DashboardAssignments Assignments { get { return _assignments; } set { _assignments = value; } }
        private DashboardAssignments _assignments = new DashboardAssignments();

        [DataMember]
        public DashboardContacts Contacts { get { return _contacts; } set { _contacts = value; } }
        private DashboardContacts _contacts = new DashboardContacts();

        [DataMember]
        public DashboardUsers Users { get { return _users; } set { _users = value; } }
        private DashboardUsers _users = new DashboardUsers();

        [DataMember]
        public DashboardNotifications Notifications { get { return _notifications; } set { _notifications = value; } }
        private DashboardNotifications _notifications = new DashboardNotifications();

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Tasks.UnpackXML(xml, "DashboardTasks");
            this.Assignments.UnpackXML(xml, "DashboardAssignments");
            this.Contacts.UnpackXML(xml, "DashboardContacts");
            this.Users.UnpackXML(xml, "DashboardUsers");
            this.Notifications.UnpackXML(xml, "DashboardNotifications");
        }
    }

    public class DashboardTasks : Entity
    {
        public int Total { get; set; }
        public int New { get; set; }
        public int InProg { get; set; }
        public int Completed { get; set; }
        public int Closed { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Total = xml.Attribute("Total").ToType<int>();
            this.New = xml.Attribute("New").ToType<int>();
            this.InProg = xml.Attribute("InProg").ToType<int>();
            this.Completed = xml.Attribute("Completed").ToType<int>();
            this.Closed = xml.Attribute("Closed").ToType<int>();
        }
    }

    public class DashboardAssignments : Entity
    {
        public int Total { get; set; }
        public int New { get; set; }
        public int InProg { get; set; }
        public int Completed { get; set; }
        public int Closed { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Total = xml.Attribute("Total").ToType<int>();
            this.New = xml.Attribute("New").ToType<int>();
            this.InProg = xml.Attribute("InProg").ToType<int>();
            this.Completed = xml.Attribute("Completed").ToType<int>();
            this.Closed = xml.Attribute("Closed").ToType<int>();
        }
    }

    public class DashboardContacts : Entity
    {
        public int Total { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Total = xml.Attribute("Total").ToType<int>();
        }
    }

    public class DashboardUsers : Entity
    {
        public int Total { get; set; }
        public int Active { get; set; }
        public int Locked { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Total = xml.Attribute("Total").ToType<int>();
            this.Active = xml.Attribute("Active").ToType<int>();
            this.Locked = xml.Attribute("Locked").ToType<int>();
        }
    }

    public class DashboardNotifications : Entity
    {
        public int Total { get; set; }
        public int My { get; set; }
        public int TotalReceived { get; set; }
        public int TotalNotReceived { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Total = xml.Attribute("Total").ToType<int>();
            this.My = xml.Attribute("My").ToType<int>();
            this.TotalReceived = xml.Attribute("TotalReceived").ToType<int>();
            this.TotalNotReceived = xml.Attribute("TotalNotReceived").ToType<int>();
        }
    }
}
