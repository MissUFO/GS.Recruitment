using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Globalization;
using System.Web;
using System.Web.Helpers;

namespace GS.Recruitment.Web
{
    public class AntiForgeryAdditionalDataProvider : IAntiForgeryAdditionalDataProvider
    {
        public string GetAdditionalData(HttpContextBase context)
        {  
            Guid userId = Guid.Empty;
            if (context != null)
            {
                var user = (context.User as UserCustomPrincipal);
                if (user != null)
                    userId = user.UserId;
            }

            return Convert.ToString(userId, CultureInfo.InvariantCulture);
        }

        public bool ValidateAdditionalData(HttpContextBase context, string additionalData)
        {
            string data = GetAdditionalData(context);
            return string.Compare(data, additionalData, StringComparison.Ordinal) == 0;
        }
    }
}