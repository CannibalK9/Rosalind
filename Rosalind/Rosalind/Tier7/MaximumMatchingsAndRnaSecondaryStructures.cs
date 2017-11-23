using Rosalind.Converters;
using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class MaximumMatchingsAndRnaSecondaryStructures
    {
        //http://rosalind.info/problems/mmch/

        public MaximumMatchingsAndRnaSecondaryStructures()
        {
            //.NET still can't handle big numbers~

            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;

            UInt64 G = (ulong)input.Count(c => c == 'G');
            UInt64 C = (ulong)input.Count(c => c == 'C');
            UInt64 A = (ulong)input.Count(c => c == 'A');
            UInt64 U = (ulong)input.Count(c => c == 'U');

            UInt64 maxGC = Math.Max(G, C);
            UInt64 minGC = Math.Min(G, C);

            UInt64 maxAU = Math.Max(A, U);
            UInt64 minAU = Math.Min(A, U);

            UInt64 Fg = Factorial(maxGC, maxGC - minGC);
            UInt64 Fa = Factorial(maxAU, maxAU - minAU);
            UInt64 result = Fg * Fa;
            Console.WriteLine(result);
        }

        static UInt64 Factorial(UInt64 n, UInt64 max)
        {
            if (n > max) return n * Factorial(n - 1, max);
            return 1;
        }
    }
}
