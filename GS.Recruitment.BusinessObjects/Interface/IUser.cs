using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Collections.Generic;

namespace GS.Recruitment.BusinessObjects.Interface
{
    public interface IUser
    {
        Guid UserId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        DateTime LastLoginOn { get; set; }

        DateTime LastPasswordChangedOn { get; set; }

        int FailedPasswordAttemptCount { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }

        UserStatus UserStatus { get; set; }

        List<UserSettings> UserSettings { get; set; }

        List<UserRole> Roles { get; set; }

        bool IsActive { get; set; }
    }
}
