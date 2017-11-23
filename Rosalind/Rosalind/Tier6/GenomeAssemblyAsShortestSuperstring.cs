using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class GenomeAssemblyAsShortestSuperstring
    {
        //http://rosalind.info/problems/long/

        public GenomeAssemblyAsShortestSuperstring()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            string superstring = dnaStrings[0];
            dnaStrings.RemoveAt(0);

            while (dnaStrings.Any())
            {
                int bestPrefixLength = 0;
                int bestSuffixLength = 0;
                int bestPrefix = -1;
                int bestSuffix = -1;

                for (int i = 0; i < dnaStrings.Count; i++)
                {
                    int overlap = dnaStrings[i].Length;
                    while (overlap > dnaStrings[i].Length / 2 && (overlap > bestPrefixLength || overlap > bestSuffixLength))
                    {
                        if (overlap > bestPrefixLength && superstring.StartsWith(dnaStrings[i].Substring(dnaStrings[i].Length - overlap)))
                        {
                            bestPrefixLength = overlap;
                            bestPrefix = i;
                        }
                        else if (overlap > bestSuffixLength && superstring.EndsWith(dnaStrings[i].Substring(0, overlap)))
                        {
                            bestSuffixLength = overlap;
                            bestSuffix = i;
                        }
                        else
                            overlap--;
                    }
                }

                if (bestPrefix >= 0)
                {
                    superstring = dnaStrings[bestPrefix] + superstring.Substring(bestPrefixLength);
                }

                if (bestSuffix >= 0)
                {
                    superstring = superstring + dnaStrings[bestSuffix].Substring(bestSuffixLength);
                }

                dnaStrings.RemoveAt(Math.Max(bestPrefix, bestSuffix));
                if (Math.Min(bestPrefix, bestSuffix) >= 0)
                    dnaStrings.RemoveAt(Math.Min(bestPrefix, bestSuffix));
            }

            Console.WriteLine(superstring);
        }
    }
}
