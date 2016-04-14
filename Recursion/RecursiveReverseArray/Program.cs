namespace RecursiveReverseArray
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i;
            }

            RecursiveReverse(numbers, 0, n - 1);

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void RecursiveReverse(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var greater = numbers[end];
            numbers[end] = numbers[start];
            numbers[start] = greater;
            RecursiveReverse(numbers, start + 1, end - 1);
        }
    }
}