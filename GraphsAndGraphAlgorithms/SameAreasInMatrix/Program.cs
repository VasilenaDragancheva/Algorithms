namespace SameAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static int cols;

        public static char[,] matrix;

        public static Dictionary<char, int> result = new Dictionary<char, int>();

        public static int rows;

        public static bool[,] visited;

        public static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            cols = line.Length;
            matrix = new char[rows, cols];
            visited = new bool[rows, cols];

            for (int c = 0; c < cols; c++)
            {
                matrix[0, c] = line[c];
            }

            for (int r = 1; r < rows; r++)
            {
                line = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var currentChar = matrix[r, c];
                    if (!visited[r, c])
                    {
                        if (!result.ContainsKey(currentChar))
                        {
                            result[currentChar] = 0;
                        }

                        result[currentChar]++;
                        MarkAllNeighbours(r, c, currentChar);
                    }
                }
            }

            Console.WriteLine("Areas {0}", result.Sum(res => res.Value));
            foreach (var res in result)
            {
                Console.WriteLine("Letter '{0}' -> {1}", res.Key, res.Value);
            }
        }

        private static void MarkAllNeighbours(int r, int c, char currentChar)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols)
            {
                return;
            }

            if (visited[r, c] || matrix[r, c] != currentChar)
            {
                return;
            }

            visited[r, c] = true;
            MarkAllNeighbours(r + 1, c, currentChar);
            MarkAllNeighbours(r - 1, c, currentChar);
            MarkAllNeighbours(r, c + 1, currentChar);
            MarkAllNeighbours(r, c - 1, currentChar);

        }
    }
}