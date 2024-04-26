using System;
using System.Text;
class GetPrimeNumber
{
    static async void Main(string[] args)
    {
        int minRange = 1;
        System.Console.Write("Type the maximum number of List (eg: Type 50 -> the List contain all number from 0->50): ");
        int maxRange;
        int.TryParse(Console.ReadLine(), out maxRange);
        List<int> list = await GetPrime(minRange, maxRange);

        System.Console.WriteLine($"The prime number list from {minRange} to {maxRange} is: ");
        foreach (int i in list){
            System.Console.WriteLine("i ");
        }
    }

    static async Task<List<int>> GetPrime(int min, int max){
        List<int> result = new List<int>();
        await Task.Run(() => {
            for (int i = min; i <= max; i++){
                if(isPrime(i)){
                    result.Add(i);
                }
            }
        }
        );
        return result;
    }
    static bool isPrime(int number)
    {
        for (int i = 2; i < Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }

        }
    return true;
    }
}