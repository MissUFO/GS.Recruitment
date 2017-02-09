using GS.Recruitment.BusinessObjects.Enum;
using System.Linq;
using System.Security.Principal;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Implemented from the interface IIdentity. Provides the Principal properties for the user connected to the system.
    /// </summary>
    public class UserCustomPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }
        IIdentity identity;

        public int UserID
        {
            get
            {
                if (userID == 0)
                {
                    UserCustomIdentity _identity = Identity as UserCustomIdentity;
                    if (_identity != null && _identity.User != null)
                        userID = _identity.User.UserID;
                }

                return userID;
            }
            set { userID = value; }
        }
        private int userID = 0;

        public string Login
        {
            get
            {
                if (login == string.Empty)
                {
                    UserCustomIdentity _identity = Identity as UserCustomIdentity;
                    if (_identity != null && _identity.User != null)
                        login = _identity.User.Login;
                }

                return login;
            }
            set { login = value; }
        }
        private string login = string.Empty;


        public bool IsInRole(RoleType role)
        {
            UserCustomIdentity _identity = Identity as UserCustomIdentity;
            if (_identity != null && _identity.User != null && _identity.User.Role.Count(itm => itm.RoleTypeID == role) > 0)
                return true;
            else
                return false;
        }

        public UserCustomPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            return IsInRole((RoleType)System.Enum.Parse(typeof(RoleType), role));
        }
    }
}