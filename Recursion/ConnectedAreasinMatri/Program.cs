namespace ConnectedAreasinMatri
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static char[,] matrix;

        public static Dictionary<string, int> results;

        public static void Main(string[] args)
        {
            results = new Dictionary<string, int>();
            matrix = new[,]
                         {
                            
                             {
                                ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' 
                             }, 
                             {
                                ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' 
                             }, 
                             {
                                ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' 
                             }, 
                             {
                                ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' 
                             }
                         };
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    string key = GetKey(r, c);
                    results.Add(key, 0);
                    GetConnectedCell(key, r, c);
                }
            }

            foreach (var result in results)
            {
                Console.WriteLine("{0}  {1}", result.Key, result.Value);
            }
        }

        private static string GetKey(int r, int c)
        {
            return string.Format("({0}, {1})", r, c);
        }

        private static void GetConnectedCell(string key, int r, int c)
        {
            if (Exit(r, c))
            {
                return;
            }

            if (matrix[r, c] != ' ')
            {
                return;
            }

            results[key]++;
            matrix[r, c] = '+';

            GetConnectedCell(key, r + 1, c);
            GetConnectedCell(key, r - 1, c);
            GetConnectedCell(key, r, c + 1);
            GetConnectedCell(key, r, c - 1);
        }

        private static bool Exit(int r, int c)
        {
            bool exitRow = r < 0 || r >=matrix.GetLength(0);
            bool exitCol = c < 0 || c >=matrix.GetLength(1);

            return exitCol || exitRow;
        }
    }
}