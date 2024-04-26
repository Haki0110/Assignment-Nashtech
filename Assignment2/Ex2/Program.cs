using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        int minRange = 0;
        Console.Write("Type the maximum number of List (eg: Type 50 -> the List contain all number from 0->50): ");
        int maxRange;
        int.TryParse(Console.ReadLine(), out maxRange);
        int section = (maxRange - minRange + 1) / 100;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<Task<List<int>>> tasks = new List<Task<List<int>>>();

        for (int i = minRange; i <= maxRange; i += section)
        {
            int sectionStart = i;
            int sectionEnd = Math.Min(i + section - 1, maxRange);
            tasks.Add(GetPrime(sectionStart, sectionEnd));
        }

        await Task.WhenAll(tasks);

        List<int> primes = tasks.SelectMany(t => t.Result).ToList();
        primes.Sort();

        stopwatch.Stop();

        Console.WriteLine("Prime numbers from " + minRange + " to " + maxRange + ":");
        foreach (int prime in primes)
        {
            Console.Write(prime + " ");
        }

        Console.WriteLine($"\nExecution time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static async Task<List<int>> GetPrime(int min, int max)
    {
        List<int> result = new List<int>();
        await Task.Run(() =>
        {
            for (int i = min; i <= max; i++)
            {
                if (isPrime(i))
                {
                    result.Add(i);
                }
            }
        });
        return result;
    }
    static bool isPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}