using GS.Recruitment.BusinessObjects.Enum;
using System;
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

        public Guid UserId
        {
            get
            {
                if (userId == Guid.Empty)
                {
                    UserCustomIdentity _identity = Identity as UserCustomIdentity;
                    if (_identity != null && _identity.User != null)
                        userId = _identity.User.UserId;
                }

                return userId;
            }
            set { userId = value; }
        }
        private Guid userId = Guid.Empty;

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
            if (_identity != null && _identity.User != null && _identity.User.Roles.Count(itm => itm.RoleType == role) > 0)
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