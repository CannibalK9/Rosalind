using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class ErrorCorrectionInReads
    {
        //http://rosalind.info/problems/corr/

        public ErrorCorrectionInReads()
        {
            string[] dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToArray();

            var valid = new List<string>();
            var invalid = new List<string>();

            foreach (string dnaString in dnaStrings)
            {
                bool isValid = false;
                string reverse = ComplementingAStrandOfDna.ReverseCompliment(dnaString, false);

                for (int i = 0; i < valid.Count; i++)
                {
                    if (dnaString.Equals(valid[i]) || reverse.Equals(valid[i]))
                    {
                        isValid = true;
                        break;
                    }
                }

                if (isValid)
                    continue;

                for (int i = 0; i < invalid.Count; i++)
                {
                    if (dnaString.Equals(invalid[i]) || reverse.Equals(invalid[i]))
                    {
                        valid.Add(dnaString);
                        valid.Add(reverse);
                        invalid.RemoveAt(i);
                        isValid = true;
                        break;
                    }
                }

                if (isValid == false)
                    invalid.Add(dnaString);
            }

            foreach (string inv in invalid)
            {
                foreach (var val in valid)
                {
                    if (CountingPointMutations.GetHammingDistance(inv, val) == 1)
                    {
                        Console.WriteLine(inv + "->" + val);
                    }
                }
            }
        }
    }
}
