namespace GS.Recruitment.Framework.SQLDataAccess.Extensions
{
    public static class IntExtension
    {
        public static string ToShortFileSizeString(this int fileSize)
        {
            int size = fileSize / (1024 * 1024 * 1024);
            if (size > 0)
            {
                return string.Format("{0} GB", size);
            }
            else
            {
                size = fileSize / (1024 * 1024);
                if (size > 0)
                {
                    return string.Format("{0} MB", size);
                }
                else
                {
                    size = fileSize / 1024;
                    if (size > 0)
                    {
                        return string.Format("{0} KB", size);
                    }
                    else
                    {
                        return string.Format("{0} B", fileSize);
                    }
                }
            }
        }
    }
}
