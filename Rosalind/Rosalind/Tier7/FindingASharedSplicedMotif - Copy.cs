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
            for (int i = 0; i < dnaStrings[0].Length; i++)
            {
                for (int j = 0; j < 3000; j++)
                {
                    if (dnaStrings[0].Length - i > _result.Length)
                    {
                        dod(new List<char>(dnaStrings[0]), new List<char>(dnaStrings[1]), i, true);
                        dod(new List<char>(dnaStrings[0]), new List<char>(dnaStrings[1]), i, false);
                    }
                }
            }
            Console.WriteLine(_index + "(" + _result.Length + ")" + " done: ");
            Console.WriteLine(_result);
        }

        private string _result = "";
        private int _index;
        private Random rand = new Random();

        public void dod(List<char> s1, List<char> s2, int index, bool one)
        {
            int removed = 1;

            try
            {
                if (one)
                    s1.RemoveRange(0, index);
                else
                    s2.RemoveRange(0, index);
            }
            catch
            {
                return;
            }
            while (removed > 0 && s1.Count > _result.Length && s2.Count > _result.Length)
            {
                removed = 0;

                for (int i = index; i < (s1.Count < s2.Count ? s1.Count : s2.Count); i++)
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

                    if (rand.Next(2) == 1)
                    {
                        s2.RemoveRange(i, s2remove);
                        removed = s2remove;
                    }
                    else
                    {
                        s1.RemoveRange(i, s1Remove);
                        removed = s1Remove;
                    }
                    break;
                }
            }

            string result = string.Join("", s1.Count < s2.Count ? s1.ToArray() : s2.ToArray());
            if (result.Length > _result.Length)
            {
                _result = result;
                _index = index;

                Console.WriteLine(_index + "(" + _result.Length + ")" + ": ");
                Console.WriteLine(_result);

            }
        }
    }
}
