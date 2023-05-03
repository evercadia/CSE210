using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("How many penguins would you like to guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Need more penguins");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Too many penguins!!");
            }
            else
            {
                Console.WriteLine("The perfect amount of penguins");
                Console.Write("Would you like to play again? (y/n) ");
                string playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    magicNumber = randomNumber.Next(1, 101);
                    guess = -1;
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                }
            }
        }
    }
}
