using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class FindingASharedSplicedMotif
    {
        //http://rosalind.info/problems/lcsq/

        public FindingASharedSplicedMotif()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            dod(dnaStrings[0], dnaStrings[1]);
            Console.WriteLine(_subsequence);
            Console.WriteLine("done");
        }

        private string _subsequence = "";

        private void dod(string s1, string s2)
        {
            foreach (string subsequence in FindSubsequence(s1))
            {
                int index = 0;

                if (subsequence.Length < 300 && subsequence.Length > 200)
                {
                    foreach (char c in subsequence)
                    {
                        index = s2.IndexOf(c, index) + 1;

                        if (index == 0)
                            break;
                    }
                }
                if (index != 0 && _subsequence.Length < subsequence.Length)
                {
                    _subsequence = subsequence;
                    Console.WriteLine(_subsequence);
                    break;
                }
                else if (subsequence.Length > _subsequence.Length + 1 && subsequence.Length > 200)
                    dod(subsequence, s2);
            }
        }

        private IEnumerable<string> FindSubsequence(string dnaString)
        {
            if (dnaString.Length - 1 <= _subsequence.Length)
                yield break;

            for (int i = 0; i < dnaString.Length - 1; i++)
            {
                string subString = dnaString.Substring(0, i) + dnaString.Substring(i + 1);
                yield return subString;
            }
        }
    }
}
