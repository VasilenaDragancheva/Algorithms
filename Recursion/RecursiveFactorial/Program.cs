namespace RecursiveFactorial
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            long factorial = RecursiveFactorialCalc(5);
            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            int sum = RecursiveSumNumbers(numbers, 0, 0);
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            Gen01Vector(vector, n - 1);
        }

        private static void Gen01Vector(int[] vector, int index)
        {
            if (index == -1)
            {
                PrintVector(vector);
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01Vector(vector, index - 1);
            }
        }

        private static void PrintVector(int[] vector)
        {
            var result = string.Join(" ", vector).Replace(" ", string.Empty);
            Console.WriteLine(result);
        }

        private static int RecursiveSumNumbers(int[] numbers, int index, int sum)
        {
            if (index == numbers.Length)
            {
                return sum;
            }

            sum += numbers[index];
            return RecursiveSumNumbers(numbers, index + 1, sum);
        }

        private static long RecursiveFactorialCalc(int p)
        {
            if (p == 0)
            {
                return 1;
            }

            return p * RecursiveFactorialCalc(p - 1);
        }
    }
}