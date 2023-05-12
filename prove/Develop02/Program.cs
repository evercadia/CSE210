using System;
using System.Collections.Generic;
using System.IO;

namespace Develop02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<JournalEntry> journalEntries = new List<JournalEntry>();
            List<string> prompts = new List<string>() {
                "How have you seen the hand of the Lord today?",
                "What was your strongest emotion today?",
                "What is something you would like to remember?",
                "Where did you find peace?",
                "What goals are you going to accomplish today?",
                "How do you view penguins  ?"
            };

            while (true)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Quit");

                Console.Write("\nEnter a menu option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        JournalEntry entry = CreateJournalEntry(prompts);
                        journalEntries.Add(entry);
                        Console.WriteLine("Journal entry added.");
                        break;
                    case "2":
                        DisplayJournal(journalEntries);
                        break;
                    case "3":
                        Console.Write("Enter a filename to save the journal to: ");
                        string saveFileName = Console.ReadLine();
                        SaveJournalToFile(journalEntries, saveFileName);
                        break;
                    case "4":
                        Console.Write("Enter a filename to load the journal from: ");
                        string loadFileName = Console.ReadLine();
                        journalEntries = LoadJournalFromFile(loadFileName);
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid menu option. Please try again.");
                        break;
                }
            }
        }

        static JournalEntry CreateJournalEntry(List<string> prompts)
        {
            Random rnd = new Random();
            string prompt = prompts[rnd.Next(prompts.Count)];
            Console.WriteLine($"\nNew journal entry: {prompt}");
            Console.Write("Enter your response: ");
            string response = Console.ReadLine();

            DateTime currentDate = DateTime.Now;

            JournalEntry entry = new JournalEntry(prompt, response, currentDate);
            return entry;
        }

        static void DisplayJournal(List<JournalEntry> entries)
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Journal is empty.");
            }
            else
            {
                foreach (JournalEntry entry in entries)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
        }

        static void SaveJournalToFile(List<JournalEntry> entries, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (JournalEntry entry in entries)
                {
                    file.WriteLine(entry.ToString());
                }
            }

            Console.WriteLine($"Journal saved to {fileName}");
        }

        static List<JournalEntry> LoadJournalFromFile(string fileName)
        {
            List<JournalEntry> entries = new List<JournalEntry>();

            using (StreamReader file = new StreamReader(fileName))
            {
                while (true)
                {
                    string line = file.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string prompt = parts[0];
                        string response = parts[1];
                        DateTime date;
                        if (DateTime.TryParse(parts[2], out date))
                        {
                            JournalEntry entry = new JournalEntry(prompt, response, date);
                            entries.Add(entry);
                        }
                    }
                }
            }

           Console.WriteLine($"\nLoaded {entries.Count} journal entries from file '{fileName}'\n");
            return entries;
        }
    }

    class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public DateTime Date { get; set; }

        public JournalEntry(string prompt, string response, DateTime date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Prompt}|{Response}|{Date}";
        }
    }
}
