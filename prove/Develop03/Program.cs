using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
  //https://www.w3schools.com/cs/cs_properties.php for example on using private strings to encapsulate certain parts of the code.
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public bool IsHidden
    {
        get { return isHidden; }
        set { isHidden = value; }
    }

    public override string ToString()
    {
        return isHidden ? "_____" : text;
    }
}

public class Reference
{
    private string reference;

    public Reference(string reference)
    {
        this.reference = reference;
    }

    public string GetReferenceString()
    {
        return reference;
    }
}

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.GetReferenceString());
        Console.WriteLine(string.Join(" ", words));
    }
/// The instructor suggest that I could give var a try and informend me of https://learnxinyminutes.com/docs/csharp/ as a reference.
    public bool HideRandomWord()
    {
        var hiddenWords = words.Where(word => word.IsHidden).ToList();
        if (hiddenWords.Count == words.Count)
        {
            return false;
        }

        var random = new Random();
        Word wordToHide;
        do
        {
            wordToHide = words[random.Next(words.Count)];
        } while (wordToHide.IsHidden);

        wordToHide.IsHidden = true;
        return true;
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        var scripture1Reference = new Reference("1 Nephi 3:7");
        var scripture1Text = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord commandeth,\n" +
                              "for I know that the Lord giveth no commandments unto the children of men, \n" +
                              "save He shall prepare a way for them that they may accomplish the thing which He commandeth them.";
        var scripture1 = new Scripture(scripture1Reference, scripture1Text);

        var scripture2Reference = new Reference("Moroni 10: 3-5");
        var scripture2Text = "3.Behold, I would exhort you that when ye shall read these things, if it be wisdom in God that ye should read them, \n" +
                             "that ye would remember how merciful the Lord hath been unto the children of men, from the creation of Adam \n" +
                             "even down until the time that ye shall receive these things, and ponder it in your hearts. \n" +
                             "4. And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, \n" +
                             "if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, \n" +
                             "he will manifest the truth of it unto you, by the power of the Holy Ghost. \n" +
                             "5. And by the power of the Holy Ghost ye may know the truth of all things.";
        var scripture2 = new Scripture(scripture2Reference, scripture2Text);

        bool continueHiding = true;
        while (continueHiding)
        // https://www.tutorialspoint.com/how-to-clear-screen-using-chash as reference on Console.clear
        {
            Console.Clear();
            scripture1.Display();
            Console.WriteLine();
            scripture2.Display();
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
                continueHiding = false;
            else
            {
                continueHiding = scripture1.HideRandomWord() || scripture2.HideRandomWord();
            }

        }

        Console.WriteLine("All words in the scripture are now hidden.");
        Console.WriteLine("Would you like to see the scriptures again? (y/n)");
        var showAgainInput = Console.ReadLine();

        if (showAgainInput.ToLower() == "y")
        {
            Console.Clear();
            scripture1.Display();
            Console.WriteLine();
            scripture2.Display();
        }

        Console.WriteLine("Press enter to quit.");
        Console.ReadLine();
    }
}
