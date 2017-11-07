using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class FindingASharedSplicedMotifAlternative
    {
        //http://rosalind.info/problems/lcsq/

        public FindingASharedSplicedMotifAlternative()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            dod(new List<char>(dnaStrings[0]), new List<char>(dnaStrings[1]));
        }

        public void dod(List<char> s1, List<char> s2)
        {
            int removed = 0;

            while (removed > 0)
            {
                for (int i = 0; i < (s1.Count < s2.Count ? s1.Count : s2.Count); i++)
                {
                    int s1Remove = 0;
                    int s2remove = 0;

                    if (s1[i] == s2[i])
                        continue;

                    while (s2.Count > i + s2remove && s1[i] != s2[i + s2remove])
                    {
                        s2remove++;
                    }

                    while (s1.Count > i + s1Remove && s2[i] != s1[i + s1Remove])
                    {
                        s1Remove++;
                    }

                    if (s1Remove > s2remove)
                    {
                        s2.RemoveRange(i, s2remove);
                        removed = s2remove;
                    }
                    else
                    {
                        s1.RemoveRange(i, s1Remove);
                        removed = s1Remove;
                    }
                }
            }

            Console.WriteLine(string.Join("",s1.ToArray()));
            Console.WriteLine(string.Join("", s2.ToArray()));
        }
    }
}
