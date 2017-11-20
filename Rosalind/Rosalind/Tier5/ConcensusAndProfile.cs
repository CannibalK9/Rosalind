using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class ConcensusAndProfile
    {
        //http://rosalind.info/problems/cons/

        public ConcensusAndProfile()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            int[] A = new int[dnaStrings[0].Length];
            int[] C = new int[dnaStrings[0].Length];
            int[] G = new int[dnaStrings[0].Length];
            int[] T = new int[dnaStrings[0].Length];

            for (int i = 0; i < dnaStrings[0].Length; i++)
            {
                string concensus = "";

                for (int j = 0; j < dnaStrings.Count; j++)
                {
                    concensus += dnaStrings[j][i];
                }

                A[i] = concensus.Count(c => c == 'A');
                C[i] = concensus.Count(c => c == 'C');
                G[i] = concensus.Count(c => c == 'G');
                T[i] = concensus.Count(c => c == 'T');

                char c2 = 'A';
                int max = A[i];
                if (C[i] > max)
                {
                    c2 = 'C';
                    max = C[i];
                }
                if (G[i] > max)
                {
                    c2 = 'G';
                    max = G[i];
                }
                if (T[i] > max)
                    c2 = 'T';
                Console.Write(c2);
            }
            Console.Write(Environment.NewLine);
            WriteCharacterArray(A, 'A');
            WriteCharacterArray(C, 'C');
            WriteCharacterArray(G, 'G');
            WriteCharacterArray(T, 'T');
        }

        private void WriteCharacterArray(int[] arr, char c)
        {
            Console.WriteLine(c.ToString() + ": " + string.Join(" ", arr));
        }
    }
}
