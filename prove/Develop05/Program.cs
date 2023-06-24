using System;
using System.Collections.Generic;

// https://github.com/evercadia/CSE210/blob/main/prove/Develop04/Program.cs This was pretty similar to, or reminded me of Develop 04, so I used this as a general layout

class Goal
{
    private string _name;
    private int _value;

    public Goal(string name, int value)
    {
        _name = name;
        _value = value;
    }

    public virtual void Complete()
    {
        Console.WriteLine($"Good job on completing your {_name}!! You have leveled up and have acquired {_value} points. ");
    }
    public string GetName()
    { 
        return _name;
    }
    public int GetValue()
    {
        return _value;
    }
}
class EasyGoal : Goal
//  Easy Goals have fixed point value to them that they will receive when the user marks it as complete
{
    public EasyGoal(string name, int value) : base(name, value) {}
    public override void Complete()
    {
        Console.WriteLine($" You have completed {GetName()} You have leveled up and have earned {GetValue()} points");
    }
}    
class EternalGoal : Goal
// Goals are never marked as being completed, but can be recoreded many times. 
// Each time an eternal goal is recorded, a fixed number of points is assigned
{
    public EternalGoal(string name, int value) : base(name, value){}
}
class ChecklistGoal : Goal
// This will have a target number of completions and a point value to go along with each completion
// Bonus points are rewarded when the checklist goal reaches the target number of completions
{
    private int _target;
    private int _completed;

    public ChecklistGoal(string name, int value, int target) : base(name, value)
    {
        _target = target;
        _completed = 0;
    }
    public override void Complete()
    {
        _completed++;
        Console.WriteLine($"Goal {GetName()} has been finished ({_completed}/{_target})! You have raised your level and have earned {GetValue()} points.");
        if (_completed == _target)
        {
            Console.WriteLine($"Good job on achieving the bonus for completing {GetName()} You have earned more level {GetValue() * 5} worth of points!");
        }
    }
    public int GetCompleted()
    {
        return _completed;
    }
    public int GetTarget()
    {
        return _target;
    }
}
class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to your Eternal Quest Program");
            Console.WriteLine("!. Please choose from the following options:");
            Console.WriteLine("1. Would you like to create a new goal?");
            Console.WriteLine("2. Record progress on your current goal");
            Console.WriteLine("3. View your current goals");
            Console.WriteLine("4. Perharps You would like to View your score");
            Console.WriteLine("5. Or perhaps You would like to EXIT");
            Console.WriteLine("Enter your Selection here:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordProgress();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    ViewScore();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Please choose a vaild option");
                    break;

            }

            Console.WriteLine();
        }
    }
    private static void CreateGoal()
    {
        Console.WriteLine("Enter your goal details");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Value");
        int value = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Select your goal:");
        Console.WriteLine("1. Easy goal");
        Console.WriteLine("2. Eternal Goal ");
        Console.WriteLine("3. Checklist");
        Console.WriteLine("Enter your choice: ");
        string typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new EasyGoal(name, value));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, value));
                break;
            case "3":
                Console.Write("Target ");
                int target = Convert.ToInt32(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, value, target));
                break;
            default:
                Console.WriteLine("Not a valid choice, your goal has been canceled");
                break;
    }
    Console.WriteLine("You have created a valid goal");

    }
    private static void RecordProgress()
    {
        Console.WriteLine("Please select a goal to record your progress: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($" {i + 0 }. {_goals[i].GetName()}");
        }
        Console.WriteLine("Enter goal number: ");
        int goalNumber = Convert.ToInt32(Console.ReadLine());

        if (goalNumber >= 1 && goalNumber <= _goals.Count)
        {
            _goals[goalNumber - 1].Complete();
            _score += _goals[goalNumber - 1].GetValue();
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please choose a valid one");
        }
    }
    private static void ViewGoals()
    {
        Console.WriteLine("Current goals");
        for (int i = 0 ; i < _goals.Count; i++)
        {
            string status;
            if (_goals[i] is ChecklistGoal checklistGoal)
            {
                status = $"Completed {checklistGoal.GetCompleted()}/ {checklistGoal.GetTarget()} times";

            }
            else
            {
                status = "[]";
            }
            Console.WriteLine($"{ i + 1}. {status} {_goals[i].GetName()}");

        }
    }
    private static void ViewScore()
    {
        Console.WriteLine($"Your current score : {_score} points");
    }
}    