using Rosalind.Converters;
using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class LocatingRestrictionSites
    {
        //http://rosalind.info/problems/revp/

        public LocatingRestrictionSites()
        {
            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;
            string reversed = ComplementingAStrandOfDna.ReverseCompliment(input, false);

            for (int i = 0; i < input.Length - 3; i++)
            {
                for (int j = 4; j <= 12; j++)
                {
                    if (i + j > input.Length)
                        break;

                    if (input.Substring(i, j).Equals(reversed.Substring(input.Length - (i + j), j)))
                        Console.WriteLine(i + 1 + " " + j);
                }
            }
        }
    }
}
