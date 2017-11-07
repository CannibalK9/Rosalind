using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class FindingASplicedMotif
    {
        //http://rosalind.info/problems/sseq/

        public FindingASplicedMotif()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();

            int index = 0;

            foreach (char c in dnaStrings[1])
            {
                index = dnaStrings[0].IndexOf(c, index) + 1;
                Console.Write(index + " ");
            }
        }
    }
}
