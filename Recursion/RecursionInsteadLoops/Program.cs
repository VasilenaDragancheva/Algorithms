namespace RecursionInsteadLoops
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            GetCombinations(numbers, 0, 1, n);
        }

        private static void GetCombinations(int[] numbers, int index, int start, int end)
        {
            if (index >= numbers.Length)
            {
                Print(numbers);
                return;
            }

            for (int i = start; i <= end; i++)
            {
                numbers[index] = i;
                GetCombinations(numbers, index + 1, start, end);
            }
        }

        private static void Print(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}