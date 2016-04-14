namespace CombinationsWithoutRepetitions
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] combination = new int[k];

            GetCombitations(combination, 0, 1, n);
        }

        private static void GetCombitations(int[] combination, int index, int start, int end)
        {
            if (index >= combination.Length)
            {
                Print(combination);
                return;
            }

            for (int i = start; i <= end; i++)
            {
                combination[index] = i;
                GetCombitations(combination, index + 1, start + 1, end);
            }
        }

        private static void Print(int[] combination)
        {
            Console.WriteLine(string.Join(" ", combination));
        }
    }
}