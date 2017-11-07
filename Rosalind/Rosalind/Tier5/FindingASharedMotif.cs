using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class FindingASharedMotif
    {
        //http://rosalind.info/problems/lcsm/

        public FindingASharedMotif()
        {
            List<string> input = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            var dnaStrings = FASTAToDictionary.Convert(input).Values.ToList();

            dnaStrings = dnaStrings.OrderBy(s => s.Length).ToList();

            List<string> subStrings = new List<string>();

            for (int i = 0; i < dnaStrings[0].Length; i++)
            {
                for (int j = 1; j <= dnaStrings[0].Length - i; j++)
                {
                    subStrings.Add(dnaStrings[0].Substring(i, j));
                }
            }

            subStrings = subStrings.OrderByDescending(s => s.Length).ToList();

            foreach (string subString in subStrings)
            {
                if (dnaStrings.All(s => s.Contains(subString)))
                {
                    Console.WriteLine(subString);
                    return;
                }
            }
        }
    }
}
