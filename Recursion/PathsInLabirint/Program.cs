namespace PathsInLabirint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static List<char[]> matrix = new List<char[]>
                                                {
                                                    new[] { ' ', ' ', ' ', ' ' }, 
                                                    new[] { ' ', '*', '*', ' ' }, 
                                                    new[] { ' ', '*', '*', ' ' }, 
                                                    new[] { ' ', '*', 'e', ' ' }, 
                                                    new[] { ' ', ' ', ' ', ' ' }
                                                };

        public static void Main(string[] args)
        {
            // matrix = new List<char[]>();
            // while (true)
            // {
            // string line = Console.ReadLine();
            // if (string.IsNullOrEmpty(line))
            // {
            // break;
            // }

            // matrix.Add(line.ToCharArray());
            // }
            List<char> path = new List<char>();
            FindPath(path, 0, 0);
        }

        private static void FindPath(List<char> path, int row, int col, char direction = 'S')
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (matrix[row][col] == 'e')
            {

                PrintPath(path, direction);
                return;
            }

            if (matrix[row][col] != ' ')
            {
                return;
            }

            path.Add(direction);
            matrix[row][col] = direction;
            FindPath(path, row, col + 1, 'R');
            FindPath(path, row + 1, col, 'D');
            FindPath(path, row - 1, col, 'U');

            FindPath(path, row, col - 1, 'L');

            matrix[row][col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath(List<char> path, char direction)
        {
            Console.WriteLine(new string(path.Skip(1).ToArray()) + direction);
        }

        private static bool InRange(int row, int col)
        {
            bool rowInMatrix = row >= 0 && row < matrix.Count;
            bool colInMatrix = col >= 0 && col < matrix[1].Length;

            return colInMatrix && rowInMatrix;
        }
    }
}