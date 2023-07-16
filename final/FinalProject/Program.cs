using System;
using System.Collections.Generic;

// ProgramManager class manages a collection of goals, events, and planner entries. Has the ability to add, remove, or retrieve such entries. 
// In the Main method., a personalManager object is created thus presenting the user with a main menu interface
// https://learnxinyminutes.com/ has been a lifesaver in all codes I have used

class PersonalManager
{
    private List<Goal> _goals;
    private List<Event> _events;
    private List<PlannerEntry> _plannerEntries;

    public PersonalManager()
    {
        _goals = new List<Goal>();
        _events = new List<Event>();
        _plannerEntries = new List<PlannerEntry>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RemoveGoal(Goal goal)
    {
        _goals.Remove(goal);
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void AddEvent(Event ev)
    {
        _events.Add(ev);
    }

    public void RemoveEvent(Event ev)
    {
        _events.Remove(ev);
    }

    public List<Event> GetEvents()
    {
        return _events;
    }

    public void AddPlannerEntry(PlannerEntry entry)
    {
        _plannerEntries.Add(entry);
    }

    public void RemovePlannerEntry(PlannerEntry entry)
    {
        _plannerEntries.Remove(entry);
    }

    public List<PlannerEntry> GetPlannerEntries()
    {
        return _plannerEntries;
    }
}

class Goal
{
    public string Description { get; set; }

    public virtual void Display()
    {
        Console.WriteLine("Goal");
    }
}

class Event : Goal
{
    public DateTime Date { get; set; }

    public override void Display()
    {
        Console.WriteLine($"Event - Description: {Description}, Date: {Date}");
    }
}

class PlannerEntry : Goal
{
    public DateTime Date { get; set; }

    public override void Display()
    {
        Console.WriteLine($"Planner Entry - Description: {Description}, Date: {Date}");
    }
}

class Program
{
    static void Main()
    {
        PersonalManager manager = new PersonalManager();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Add Event");
            Console.WriteLine("3. Add Planner Entry");
            Console.WriteLine("4. Remove Goal");
            Console.WriteLine("5. Remove Event");
            Console.WriteLine("6. Remove Planner Entry");
            Console.WriteLine("7. Retrieve Goals");
            Console.WriteLine("8. Retrieve Events");
            Console.WriteLine("9. Retrieve Planner Entries");
            Console.WriteLine("10. Exit");
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal description: ");
                    string goalDescription = Console.ReadLine();
                    Goal goal = new Goal { Description = goalDescription };
                    manager.AddGoal(goal);
                    Console.WriteLine("Goal added successfully.");
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Write("Enter event description: ");
                    string eventDescription = Console.ReadLine();
                    Console.Write("Enter event date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
                    {
                        Event ev = new Event { Description = eventDescription, Date = eventDate };
                        manager.AddEvent(ev);
                        Console.WriteLine("Event added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Event not added.");
                    }
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Write("Enter planner entry description: ");
                    string entryDescription = Console.ReadLine();
                    Console.Write("Enter entry date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime entryDate))
                    {
                        PlannerEntry entry = new PlannerEntry { Description = entryDescription, Date = entryDate };
                        manager.AddPlannerEntry(entry);
                        Console.WriteLine("Planner entry added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Planner entry not added.");
                    }
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine("Goals:");
                    List<Goal> goals = manager.GetGoals();
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].Description}");
                    }
                    Console.WriteLine("Enter the number of the goal to remove:");
                    if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= goals.Count)
                    {
                        Goal goalToRemove = goals[goalIndex - 1];
                        manager.RemoveGoal(goalToRemove);
                        Console.WriteLine("Goal removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Goal not removed.");
                    }
                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine("Events:");
                    List<Event> events = manager.GetEvents();
                    for (int i = 0; i < events.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {events[i].Description} - {events[i].Date}");
                    }
                    Console.WriteLine("Enter the number of the event to remove:");
                    if (int.TryParse(Console.ReadLine(), out int eventIndex) && eventIndex >= 1 && eventIndex <= events.Count)
                    {
                        Event eventToRemove = events[eventIndex - 1];
                        manager.RemoveEvent(eventToRemove);
                        Console.WriteLine("Event removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Event not removed.");
                    }
                    Console.WriteLine();
                    break;

                case "6":
                    Console.WriteLine("Planner Entries:");
                    List<PlannerEntry> plannerEntries = manager.GetPlannerEntries();
                    for (int i = 0; i < plannerEntries.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {plannerEntries[i].Description} - {plannerEntries[i].Date}");
                    }
                    Console.WriteLine("Enter the number of the planner entry to remove:");
                    if (int.TryParse(Console.ReadLine(), out int entryIndex) && entryIndex >= 1 && entryIndex <= plannerEntries.Count)
                    {
                        PlannerEntry entryToRemove = plannerEntries[entryIndex - 1];
                        manager.RemovePlannerEntry(entryToRemove);
                        Console.WriteLine("Planner entry removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Planner entry not removed.");
                    }
                    Console.WriteLine();
                    break;

                case "7":
                    Console.WriteLine("Retrieved Goals:");
                    List<Goal> retrievedGoals = manager.GetGoals();
                    foreach (Goal retrievedGoal in retrievedGoals)
                    {
                        retrievedGoal.Display();
                    }
                    Console.WriteLine();
                    break;

                case "8":
                    Console.WriteLine("Retrieved Events:");
                    List<Event> retrievedEvents = manager.GetEvents();
                    foreach (Event retrievedEvent in retrievedEvents)
                    {
                        retrievedEvent.Display();
                    }
                    Console.WriteLine();
                    break;

                case "9":
                    Console.WriteLine("Retrieved Planner Entries:");
                    List<PlannerEntry> retrievedPlannerEntries = manager.GetPlannerEntries();
                    foreach (PlannerEntry retrievedEntry in retrievedPlannerEntries)
                    {
                        retrievedEntry.Display();
                    }
                    Console.WriteLine();
                    break;

                case "10":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
