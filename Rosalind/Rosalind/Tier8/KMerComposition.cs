using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class KMerComposition
    {
        //http://rosalind.info/problems/kmer/

        public KMerComposition()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            string symbols = "";

            for (int i = 0; i < dnaStrings[0].Length; i++)
            {
                if (symbols.All(c => c != dnaStrings[0][i]))
                    symbols += dnaStrings[0][i];
            }
            var symbolList = symbols.Select(c => c.ToString()).ToList();
            symbolList.Sort();

            var kmers = new Dictionary<string, int>();
            Solve(kmers, symbolList, "", 4);

            for (int i = 0; i < dnaStrings[0].Length - 3; i++)
            {
                kmers[dnaStrings[0].Substring(i, 4)]++;
            }
            Console.Write(string.Join(" ", kmers.Values));
        }

        private void Solve(Dictionary<string, int> kmers, List<string> symbolList, string output, int length)
        {
            foreach (string symbol in symbolList)
            {
                if (output.Length < length)
                {
                    if (output.Length + 1 == length)
                        kmers.Add(output + symbol, 0);
                    Solve(kmers, symbolList, output + symbol, length);
                }
            }
        }
    }
}
