using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an array of assignments
        Assignment[] assignments = new Assignment[3];

        // Create a base "Assignment" object
        assignments[0] = new Assignment("Penguina Roberts", "Multiplication");

        // Now create the derived class assignments
        assignments[1] = new MathAssignment("Celes Chavez", "Fractions", "3.14", "7-14");
        assignments[2] = new WritingAssignment("Nate Jellerson", "Evercadia", "Threading the Elements");

        // Print the summary for each assignment
        foreach (Assignment assignment in assignments)
        {
            Console.WriteLine(assignment.GetSummary());

            if (assignment is MathAssignment mathAssignment)
            {
                Console.WriteLine(mathAssignment.GetHomeworkList());
            }
            else if (assignment is WritingAssignment writingAssignment)
            {
                Console.WriteLine(writingAssignment.GetWritingInformation());
            }
        }
    }
}
