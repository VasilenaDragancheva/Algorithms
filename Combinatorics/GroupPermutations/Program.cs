namespace GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static readonly Dictionary<char, int> letterCount = new Dictionary<char, int>();
        private static StringBuilder result = new StringBuilder();
        private static char[] letters;

        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            letters = line.ToCharArray().Distinct().ToArray();

            Array.Sort(letters);
            foreach (var letter in letters)
            {
                letterCount.Add(letter, line.Count(l => l == letter));
            }

            GetPermutations(0);
        }

        private static void GetPermutations(int index)
        {
            if (index >= letters.Length)
            {
                PrintPermutation();
                result.Clear();
            }
            else
            {
                for (int i = index; i < letters.Length; i++)
                {
                    Swap(index, i);
                    GetPermutations(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            char c = letters[index];
            letters[index] = letters[i];
            letters[i] = c;
        }

        private static void PrintPermutation()
        {
         
            foreach (var letter in letters)
            {
                result.Append(letter, letterCount[letter]);
            }

            Console.WriteLine(result.ToString());
        }
    }
}