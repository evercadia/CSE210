using System;


class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num;

        do
        {
            Console.Write("Enter a number (or 0 to stop): ");
            num = int.Parse(Console.ReadLine());
            if (num != 0)
            {
                numbers.Add(num);
            }
        } while (num != 0);

        int sum = 0;
        int largest = numbers[0];

        foreach (int n in numbers)
        {
            sum += n;
            if (n > largest)
            {
                largest = n;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine("You entered:");
        foreach (int n in numbers)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Largest number: " + largest);
    }
}
