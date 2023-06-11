using System;
using System.Threading.Tasks;

// https://www.tutlane.com/tutorial/csharp/csharp-access-modifiers-public-private-protected-internal on protected strings
public abstract class MindfulActivity
{
    protected string _description;
    protected string[] _prompts;

    protected string Description => _description;

    public float Duration { get; set; }

    // The professor gave us hints to use Delta time as an option to have it calculate time according to the rubric

    protected abstract Task UpdateAsync(float deltaTime);

    public virtual async Task StartAsync()
    {
        Console.WriteLine($"Starting {GetType().Name} activity for {Duration} seconds.");
        Console.WriteLine(Description);
        await Task.Delay(2000);
        Console.WriteLine("Get Ready...");
        await Task.Delay(3000);
        Console.WriteLine("Starting Activity.");

        float timeElapsed = 0;
        float deltaTime = GetDeltaTime();

        while (timeElapsed < Duration)
        {
            await UpdateAsync(deltaTime);
            timeElapsed += deltaTime;
        }

        await EndAsync();
    }

    public virtual async Task EndAsync()
    {
        Console.WriteLine("Congratulations on completing the activity!");
        await Task.Delay(2000);
        Console.WriteLine($"You have completed {GetType().Name} activity for {Duration} seconds");
        await Task.Delay(3000);
    }
// https://byui-cse.github.io/cse210-course-2023/unit04/develop.html on refrencing animations i choose > > > because thats the animation I like
    protected async Task PauseWithSpinnerAsync(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(">");
            await Task.Delay(1000);
        }
        Console.WriteLine();
    }

    protected float GetDeltaTime()
    {
        
        return 1000;
    }
}

public class BreathingActivity : MindfulActivity
{
    public BreathingActivity()
    {
        _description = "This activity will help you relax and bring your focus back to center.";
    }

    protected override async Task UpdateAsync(float deltaTime)
    {
        Console.WriteLine("Breathe In..");
        await PauseWithSpinnerAsync(3);
        Console.WriteLine("Exhale Out...");
        await PauseWithSpinnerAsync(3);
    }
}

public class ReflectionActivity : MindfulActivity
{
    public ReflectionActivity()
    {
        _description = "This activity will help bring to your remembrance times when you helped uplift others.\nWhen you waded through tough times.\nHow the Savior is blessing your life on a daily basis.";
        _prompts = new string[]
        {
            "Think of a time when you stood up for someone else.",
            "When was the last time you wrote down in your gratitude journal?",
            "Think back to a time when you placed others above yourself.",
            "Recall a time when you laughed and looked through life as a child."
        };
    }

    protected override async Task UpdateAsync(float deltaTime)
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];
        Console.WriteLine("Prompt: " + prompt);
        await PauseWithSpinnerAsync(5);

        string[] questions = new string[]
        {
            "Has anyone ever given you a meaningful smile?",
            "How did you feel when it was complete?",
            "What was your favorite thing about the experience?",
            "What did you learn about penguins in CSE210?",
            "How can you keep this experience alive?",
            "How can you carry the fire?"
        };

        foreach (string question in questions)
        {
            Console.WriteLine("Question: " + question);
            await PauseWithSpinnerAsync(4);
        }
    }
}

public class ListingActivity : MindfulActivity
{
    public ListingActivity()
    {
        _description = "This activity will help you reflect on the good things in life.";
        _prompts = new string[]
        {
            "What are some things you are grateful for?",
            "What are some of your favorite hobbies?",
            "What are some positive qualities about yourself?",
            "What are your favorite books, movies, or songs?"
        };
    }

    protected override async Task UpdateAsync(float deltaTime)
    {
        Console.WriteLine("Prompt: " + _prompts[0]);
        await PauseWithSpinnerAsync(4);

        for (int i = 1; i < _prompts.Length; i++)
        {
            Console.WriteLine("Prompt: " + _prompts[i]);
            await PauseWithSpinnerAsync(3);
        }
    }
}

public class PoemBuilderActivity : MindfulActivity
{
    private int startingLine = 1;

    public PoemBuilderActivity()
    {
        _description = "This activity will help you express your thoughts and feelings through poetry.";
    }

    protected override async Task UpdateAsync(float deltaTime)
    {
        Console.WriteLine("Start your poem, choose from lines 1 - 10, press ENTER when finished.");
        string poem = GetLine(startingLine);
        int lineNumber = 2;

        while (true)
        {
            Console.Write($"Line {lineNumber}: ");
            string line = Console.ReadLine();

            if (string.IsNullOrEmpty(line))
                break;

            int lineIndex = Convert.ToInt32(line);
            poem += Environment.NewLine + GetLine(lineIndex);
            lineNumber++;
        }

        Console.WriteLine("Your Poem:");
        Console.WriteLine(poem);

        await Task.CompletedTask;
    }
// refrencing myself here. I write poems and have for most of my life. Every line has come from a poem I have written.

//https://stackoverflow.com/questions/3415936/inline-switch-case-statement-in-c-sharp for the switch lineIndex reference
    private string GetLine(int lineIndex)
    {
        switch (lineIndex)
        {
            case 1:
                return "I drift here upon the water's boon";
            case 2:
                return "Dawn Approaches";
            case 3:
                return "Out of the tiles, calls an olive tree";
            case 4:
                return "As reality vanishes from sight";
            case 5:
                return "I shift to the right";
            case 6:
                return "The land of ice and snow";
            case 7:
                return "Look upon the Eastern glow";
            case 8:
                return "An adventure awaits as heaven glistens";
            case 9:
                return "Sit and be still, feel your heart to listen";
            case 10:
                return "As it does much too soon";
            default:
                return "Invalid line number";
        }
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindful Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Poem Builder");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();

                Console.WriteLine("Enter the duration in seconds:");
                breathingActivity.Duration = Convert.ToSingle(Console.ReadLine());
                await breathingActivity.StartAsync();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                Console.WriteLine("Enter the duration in seconds:");
                reflectionActivity.Duration = Convert.ToSingle(Console.ReadLine());
                await reflectionActivity.StartAsync();
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                Console.WriteLine("Enter the duration in seconds:");
                listingActivity.Duration = Convert.ToSingle(Console.ReadLine());
                await listingActivity.StartAsync();
            }
            else if (choice == "4")
            {
                PoemBuilderActivity poemBuilderActivity = new PoemBuilderActivity();
                Console.WriteLine("Enter the duration in seconds:");
                poemBuilderActivity.Duration = Convert.ToSingle(Console.ReadLine());
                await poemBuilderActivity.StartAsync();
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
