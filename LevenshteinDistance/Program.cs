using System;

namespace LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Levenshtein("alohomora", "klohomor"));
        }

        public static int Levenshtein(string s1, string s2)
        {
            int n = s1.Length + 1;
            int m = s2.Length + 1;

            int[,] matrix = new int[n, m]; 

            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = i;
            }

            for (int j = 0; j < m; j++)
            {
                matrix[0, j] = j;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int compare = 0;
                    if (s1[i - 1] != s2[j - 1]) compare = 1;
                    matrix[i, j] = Math.Min(matrix[i - 1, j] + 1,
                        Math.Min(matrix[i, j - 1] + 1, matrix[i - 1, j - 1] + compare));
                }
            }

            return matrix[n - 1, m - 1];
        }
    }
}
