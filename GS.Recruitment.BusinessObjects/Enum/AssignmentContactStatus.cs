namespace GS.Recruitment.BusinessObjects.Enum
{
    /// <summary>
    /// Assignment contact status
    /// </summary>
    public enum AssignmentContactStatus : byte
    {
        New = 0,
        InProgress = 1,
        Sucseeded = 2,
        Busy = 3,
        NoAnswer = 4,
        NotExist = 5,
        NotInterested = 6,
        AskLater = 7
    }
}
