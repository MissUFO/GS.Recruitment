using System;

namespace GS.Recruitment.Framework.SQLDataAccess.Extensions
{
    public static class TimeSpanExtension
    {
        public static string ToShortString(this TimeSpan timeElapsed)
        {
            if (timeElapsed.Days > 0)
            {
                return string.Format("{0} day{1}", timeElapsed.Days, timeElapsed.Days == 1 ? string.Empty : "s");
            }
            else
            {
                if (timeElapsed.Hours > 0)
                {
                    return string.Format("{0} hour{1}", timeElapsed.Hours, timeElapsed.Hours == 1 ? string.Empty : "s");
                }
                else
                {
                    if (timeElapsed.Minutes > 0)
                    {
                        return string.Format("{0} min{1}", timeElapsed.Minutes, timeElapsed.Minutes == 1 ? string.Empty : "s");
                    }
                    else
                    {
                        if (timeElapsed.Seconds > 0)
                        {
                            return string.Format("{0} sec{1}", timeElapsed.Seconds, timeElapsed.Seconds == 1 ? string.Empty : "s");
                        }
                        else
                        {
                            return string.Format("{0} ms", timeElapsed.Milliseconds);
                        }
                    }
                }
            }
        }
    }
}
