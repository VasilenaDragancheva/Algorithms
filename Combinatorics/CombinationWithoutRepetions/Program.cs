namespace Combination
{
    using System;

    public class Program
    {
        private static readonly int k = 3;

        private static readonly int[] combination = new int[k];

        private static readonly int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };

        public static void Main(string[] args)
        {
            CombinationsWithRepetion(0, 0);
        }

        private static void CombinationsWithoutRepetion(int index, int start)
        {
            if (index >= combination.Length)
            {
                Print();
                return;
            }

            for (int i = start; i < numbers.Length; i++)
            {
                combination[index] = numbers[i];
                CombinationsWithoutRepetion(index + 1, i + 1);
            }
        }

        private static void CombinationsWithRepetion(int index, int start)
        {
            if (index >= combination.Length)
            {
                Print();
                return;
            }

            for (int i = start; i < numbers.Length; i++)
            {
                combination[index] = numbers[i];
                CombinationsWithoutRepetion(index + 1, i);
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", combination));
        }
    }
}