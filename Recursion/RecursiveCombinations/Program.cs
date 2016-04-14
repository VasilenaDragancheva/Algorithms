namespace RecursiveCombinations
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int start = 4;
            int end = 8;
            int n = 3;
            int[] variant = new int[3];

            GetCombinations(variant, end, start, 0);
        }

        private static void GetCombinations(int[] variant, int end, int start, int index)
        {
            if (index >= variant.Length)
            {
                Console.WriteLine(string.Join(",", variant));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                variant[index] = i;

                GetCombinations(variant, end, i + 1, index + 1);
            }
        }
    }
}