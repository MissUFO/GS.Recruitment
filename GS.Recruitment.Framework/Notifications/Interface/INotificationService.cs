using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Recruitment.Framework.Notifications
{
    public interface INotificationService
    {
        void SendEmail(EmailArg emailArg);
    }
}
