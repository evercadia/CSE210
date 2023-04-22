using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.WriteLine("Enter your numeric grade:");
int grade = int.Parse(Console.ReadLine());

string letterGrade;
if (grade >= 90) {
    letterGrade = "A";
} else if (grade >= 80) {
    letterGrade = "B";
} else if (grade >= 70) {
    letterGrade = "C";
} else if (grade >= 60) {
    letterGrade = "D";
} else {
    letterGrade = "F";
}

Console.WriteLine("Your letter grade is: " + letterGrade);

    }
}