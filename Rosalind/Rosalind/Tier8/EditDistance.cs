using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Tier8
{
    public class EditDistance
    {
        //http://rosalind.info/problems/edit/

        public EditDistance()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            int changeCount = Distance(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1, new Dictionary<KeyValuePair<int, int>, int>());
            Console.WriteLine(changeCount);
        }

        private int Distance(string s1, string s2, int s1Length, int s2Length, Dictionary<KeyValuePair<int,int>,int> pairs)
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
                    int d = Distance(s1, s2, s1Length - 1, s2Length - 1, pairs);
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
                    int s1Count = 1 + Distance(s1, s2, s1Length - 1, s2Length, pairs);
                    int s2Count = 1 + Distance(s1, s2, s1Length, s2Length - 1, pairs);
                    int changeCount = 1 + Distance(s1, s2, s1Length - 1, s2Length - 1, pairs);

                    int d = Math.Min(s1Count, Math.Min(s2Count, changeCount));
                    pairs.Add(pair, d);
                    return d;
                }
            }
        }
    }
}
