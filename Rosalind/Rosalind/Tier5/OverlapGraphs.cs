using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class OverlapGraphs
    {
        //http://rosalind.info/problems/grph/

        public OverlapGraphs()
        {
            Dictionary<string, string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList());

            foreach (KeyValuePair<string, string> dnaString in dnaStrings)
            {
                foreach (KeyValuePair<string, string> dnaStringMatch in dnaStrings)
                {
                    if (dnaString.Value.Equals(dnaStringMatch.Value) == false)
                    {
                        if (dnaString.Value.Substring(dnaString.Value.Length - 3, 3).Equals(dnaStringMatch.Value.Substring(0, 3)))
                        {
                            Console.WriteLine(dnaString.Key + " " + dnaStringMatch.Key);
                        }
                    }
                }
            }
        }
    }
}
