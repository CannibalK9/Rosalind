using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class EditDistanceAlignment
    {
        //http://rosalind.info/problems/edta/

        public EditDistanceAlignment()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();

            var s1Hyphens = new List<int>();
            var s2Hyphens = new List<int>();

            int changeCount = Distance(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1,s1Hyphens, s2Hyphens, new Dictionary<KeyValuePair<int, int>, int>());

            var s1Chars = new List<char>(dnaStrings[0]);
            var s2Chars = new List<char>(dnaStrings[1]);

            foreach (int hyphenIndex in s1Hyphens)
                s1Chars.Insert(hyphenIndex, '-');

            foreach (int hyphenIndex in s2Hyphens)
                s2Chars.Insert(hyphenIndex, '-');

            Console.WriteLine(changeCount);
            Console.WriteLine(string.Join("", s1Chars));
            Console.WriteLine(string.Join("", s2Chars));
        }

        private int Distance(string s1, string s2, int s1Length, int s2Length, List<int>s1Hyphens, List<int>s2Hyphens, Dictionary<KeyValuePair<int,int>,int> pairs)
        {
            var pair = new KeyValuePair<int, int>(s1Length, s2Length);

            if (s1Length < 0 || s2Length < 0)
            {
                return Math.Abs(s1Length - s2Length);
            }
            else if (s1[s1Length] == s2[s2Length])
            {
                if (pairs.ContainsKey(pair))
                    return pairs[pair];
                else
                {
                    int d = Distance(s1, s2, s1Length - 1, s2Length - 1, s1Hyphens, s2Hyphens, pairs);
                    pairs.Add(pair, d);
                    return d;
                }
            }
            else
            {
                if (pairs.ContainsKey(pair))
                    return pairs[pair];
                else
                {
                    int s1Count = 1 + Distance(s1, s2, s1Length - 1, s2Length, s1Hyphens, s2Hyphens, pairs);
                    int s2Count = 1 + Distance(s1, s2, s1Length, s2Length - 1, s1Hyphens, s2Hyphens, pairs);
                    int changeCount = 1 + Distance(s1, s2, s1Length - 1, s2Length - 1, s1Hyphens, s2Hyphens, pairs);

                    if (s1Count < changeCount && s2Count < changeCount)
                    {
                        if (s1Count < s2Count)
                            s1Hyphens.Add(s1Length - 1);
                        else
                            s2Hyphens.Add(s2Length - 1);
                    }

                    int d = Math.Min(s1Count, Math.Min(s2Count, changeCount));
                    pairs.Add(pair, d);
                    return d;
                }
            }
        }
    }
}
