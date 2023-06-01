public class Assignment
{
    public string StudentName { get; private set; }
    public string Topic { get; private set; }

    public Assignment(string studentName, string topic)
    {
        StudentName = studentName;
        Topic = topic;
    }

    protected string GetStudentName()
    {
        return StudentName;
    }

    public string GetSummary()
    {
        return $"{StudentName} - {Topic}";
    }
}
