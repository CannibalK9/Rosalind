using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Converters
{
    public static class DisplayPaths
    {
        public static void Display(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs)
        {
            var last = pairs.Last().Key;

            for (int j = 0; j <= last.Value; j++)
            {
                Console.Write("   " + j);
            }
            Console.WriteLine();

            for (int i = 0; i <= last.Key; i++)
            {
                Console.Write(i + " ");

                for (int j = 0; j <= last.Value; j++)
                {
                    var value = pairs[new KeyValuePair<int, int>(i, j)];
                    Console.Write(value.Key + "," + value.Value + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
