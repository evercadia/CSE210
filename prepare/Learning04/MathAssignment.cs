public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base for base reference
//https://byui-cse.github.io/cse210-course-2023/unit04/prepare.html another example of base reference
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
