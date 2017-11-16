using System;
using System.Collections.Generic;
using System.IO;

namespace Rosalind.Converters
{
    public static class ScoringMatrices
    {
        private const string _chars = "ACDEFGHIKLMNPQRSTVWY";

        private const string _values = "" +
           " 4  0 -2 -1 -2  0 -2 -1 -1 -1 -1 -2 -1 -1 -1  1  0  0 -3 -2 " +
           " 0  9 -3 -4 -2 -3 -3 -1 -3 -1 -1 -3 -3 -3 -3 -1 -1 -1 -2 -2 " +
           "-2 -3  6  2 -3 -1 -1 -3 -1 -4 -3  1 -1  0 -2  0 -1 -3 -4 -3 " +
           "-1 -4  2  5 -3 -2  0 -3  1 -3 -2  0 -1  2  0  0 -1 -2 -3 -2 " +
           "-2 -2 -3 -3  6 -3 -1  0 -3  0  0 -3 -4 -3 -3 -2 -2 -1  1  3 " +
           " 0 -3 -1 -2 -3  6 -2 -4 -2 -4 -3  0 -2 -2 -2  0 -2 -3 -2 -3 " +
           "-2 -3 -1  0 -1 -2  8 -3 -1 -3 -2  1 -2  0  0 -1 -2 -3 -2  2 " +
           "-1 -1 -3 -3  0 -4 -3  4 -3  2  1 -3 -3 -3 -3 -2 -1  3 -3 -1 " +
           "-1 -3 -1  1 -3 -2 -1 -3  5 -2 -1  0 -1  1  2  0 -1 -2 -3 -2 " +
           "-1 -1 -4 -3  0 -4 -3  2 -2  4  2 -3 -3 -2 -2 -2 -1  1 -2 -1 " +
           "-1 -1 -3 -2  0 -3 -2  1 -1  2  5 -2 -2  0 -1 -1 -1  1 -1 -1 " +
           "-2 -3  1  0 -3  0  1 -3  0 -3 -2  6 -2  0  0  1  0 -3 -4 -2 " +
           "-1 -3 -1 -1 -4 -2 -2 -3 -1 -3 -2 -2  7 -1 -2 -1 -1 -2 -4 -3 " +
           "-1 -3  0  2 -3 -2  0 -3  1 -2  0  0 -1  5  1  0 -1 -2 -2 -1 " +
           "-1 -3 -2  0 -3 -2  0 -3  2 -2 -1  0 -2  1  5 -1 -1 -3 -3 -2 " +
           " 1 -1  0  0 -2  0 -1 -2  0 -2 -1  1 -1  0 -1  4  1 -2 -3 -2 " +
           " 0 -1 -1 -1 -2 -2 -2 -1 -1 -1 -1  0 -1 -1 -1  1  5  0 -2 -2 " +
           " 0 -1 -3 -2 -1 -3 -3  3 -2  1  1 -3 -2 -2 -3 -2  0  4 -3 -1 " +
           "-3 -2 -4 -3  1 -2 -2 -3 -3 -2 -1 -4 -4 -2 -3 -3 -2 -3 11  2 " +
           "-2 -2 -3 -2  3 -3  2 -1 -2 -1 -1 -2 -3 -1 -2 -2 -2 -1  2  7 ";

        private static Dictionary<string, string> _matrix = Getmatrix();

        private static Dictionary<string, string> Getmatrix()
        {
            Dictionary<string, string> matrix = new Dictionary<string, string>();

            using (var sr = new StringReader(_values))
            {
                foreach (char c in _chars)
                {
                    foreach (char c2 in _chars)
                    {
                        char[] value = new char[3];
                        sr.Read(value, 0, 3);
                        matrix.Add(c.ToString() + c2.ToString(), string.Join("", value));
                    }
                }
            }

            return matrix;
        }

        public static int BLOSUM62(char a, char b)
        {
            return Convert.ToInt32(_matrix[a.ToString() + b.ToString()]);
        }
    }
}
