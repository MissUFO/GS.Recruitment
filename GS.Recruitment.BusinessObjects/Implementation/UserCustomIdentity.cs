using System.Security.Principal;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Implemented from the interface IIdentity. Provides the Identity for the user connected to the system.
    /// </summary>
    public class UserCustomIdentity : IIdentity
    {
        public User User
        {
            get { return _User; }
            private set { _User = value; }
        }
        private User _User;

        public string AuthenticationType
        {
            get { return "Recruitment Form Authentication"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _User == null ? "User Profile" : ((false == string.IsNullOrWhiteSpace(_User.Name)) ? _User.Name : _User.Login); }
        }

        public UserCustomIdentity(User userLogin)
        {
            _User = userLogin;
        }

        public UserCustomIdentity()
        { }

    }
}
