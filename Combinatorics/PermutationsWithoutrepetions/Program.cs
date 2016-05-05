namespace PermutationsWithoutrepetions
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int count;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Enumerable.Range(1, n).ToArray();

            Permute(numbers, 0);
            Console.WriteLine("Total number " + count);
        }

        private static void Permute(int[] numbers, int startIndex)
        {
            if (startIndex >= numbers.Length)
            {
                Print(numbers);
                count++;
            }
            else
            {
                for (int i = startIndex; i < numbers.Length; i++)
                {
                    Swap(ref numbers[startIndex], ref numbers[i]);
                    Permute(numbers, startIndex + 1);
                    Swap(ref numbers[startIndex], ref numbers[i]);
                }
            }
        }

        private static void Swap(ref int number1, ref int number2)
        {
            int fist = number1;
            number1 = number2;
            number2 = fist;
        }

        private static void Print(int[] numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}