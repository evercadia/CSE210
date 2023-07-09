using System;
using System.Collections.Generic;

class PersonalManager
{
    private List<Goal> goals;
    private List<Event> events;
    private List<PlannerEntry> plannerEntries;

    public PersonalManager()
    {
        goals = new List<Goal>();
        events = new List<Event>();
        plannerEntries = new List<PlannerEntry>();
    }

    public void AddGoal(Goal goal)
    {
        //  logic to add a goal
    }

    public void RemoveGoal(Goal goal)
    {
        //  removes a goal
    }

    public List<Goal> GetGoals()
    {
        //  list of goals
        return null;
    }

    public void AddEvent(Event ev)
    {
        // adds an event
    }

    public void RemoveEvent(Event ev)
    {
        // removes an event
    }

    public List<Event> GetEvents()
    {
        //  logic to get the list of events
        return null;
    }

    public void AddPlannerEntry(PlannerEntry entry)
    {
        // Adds a planner entry
    }

    public void RemoveJournalEntry(PlannerEntry entry)
    {
        // Removes a planner entry
    }

    public List<PlannerEntry> GetPlannerEntries()
    {
        // List of Planner Entries
        return null;
    }
}

class Goal
{
    public string Description { get; set; }
}

class Event
{
    public string Description { get; set; }
    public DateTime Date { get; set; }
}

class PlannerEntry
{
    public string Content { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static void Main()
    {
        // TODO: Add sample code to test the PersonalManager class
    }
}
