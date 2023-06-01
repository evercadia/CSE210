public class WritingAssignment : Assignment
{
    public string AssignmentTitle { get; private set; }

    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base for base reference

    public WritingAssignment(string studentName, string topic, string assignmentTitle)
        : base(studentName, topic)
    {
        AssignmentTitle = assignmentTitle;
    }

    public string GetWritingInformation()
    {
        return $"{AssignmentTitle} by {base.GetStudentName()}";
    }
}
