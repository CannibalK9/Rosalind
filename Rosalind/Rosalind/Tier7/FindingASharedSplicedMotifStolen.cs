using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class FindingASharedSplicedMotifStolen
    {
        //http://rosalind.info/problems/lcsq/

        public FindingASharedSplicedMotifStolen()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            var pairs = new Dictionary<KeyValuePair<int, int>, int>();
            dod(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1, pairs);
            string sequence = reconstruct(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1, pairs);
            sequence = string.Join("", sequence.Reverse());
            Console.WriteLine(sequence.Length);
            Console.WriteLine(sequence);
            //Console.WriteLine(Environment.NewLine);
            //Console.WriteLine(bluh(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1));
        }

        private string bluh(string s1, string s2, int s1Length, int s2Length)
        {
            if (s1Length < 0 || s2Length < 0)
            {
                return "";
            }
            else if (s1[s1Length] == s2[s2Length])
            {
                return bluh(s1, s2, s1Length - 1, s2Length - 1) + s1[s1Length];
            }
            else
            {
                string new1 = bluh(s1, s2, s1Length, s2Length - 1);
                string new2 = bluh(s1, s2, s1Length - 1, s2Length);

                return new1.Length > new2.Length ? new1 : new2;
            }
        }

        private int dod(string s1, string s2, int s1Length, int s2Length, Dictionary<KeyValuePair<int, int>, int> pairs)
        {
            var kvp = new KeyValuePair<int, int>(s1Length, s2Length);

            if (s1Length < 0 || s2Length < 0)
            {
                return 0;
            }
            else if (pairs.ContainsKey(kvp))
            {
                return pairs[kvp];
            }
            else
            {
                int one = dod(s1, s2, s1Length - 1, s2Length, pairs);
                int two = dod(s1, s2, s1Length, s2Length - 1, pairs);
                int three = dod(s1, s2, s1Length - 1, s2Length - 1, pairs);

                if (s1[s1Length] == s2[s2Length])
                    three++;

                pairs[kvp] = Math.Max(one, Math.Max(two, three));
                return pairs[kvp];
            }
        }
        private string reconstruct(string s1, string s2, int s1Length, int s2Length, Dictionary<KeyValuePair<int, int>, int> pairs)
        {
            var sequence = new List<char>();

            while (s1Length >= 0 && s2Length >= 0)
            {
                int diag = 0;
                int left = 0;
                int up = 0;

                pairs.TryGetValue(new KeyValuePair<int, int>(s1Length - 1, s2Length - 1), out diag);
                pairs.TryGetValue(new KeyValuePair<int, int>(s1Length, s2Length - 1), out left);
                pairs.TryGetValue(new KeyValuePair<int, int>(s1Length - 1, s2Length), out up);

                if (s1[s1Length] == s2[s2Length])
                    diag++;

                var options = new List<int> { diag, left, up };
                int curr = 0;

                for (int i = 0; i < options.Count; i++)
                {
                    if (options[i] > options[curr])
                        curr = i;
                }

                if (curr == 0)
                {
                    if (s1[s1Length] == s2[s2Length])
                        sequence.Add(s1[s1Length]);
                    s1Length--;
                    s2Length--;
                }
                else if (curr == 1)
                {
                    s2Length--;
                }
                else
                {
                    s1Length--;
                }
            }

            return string.Join("", sequence);
        }
    }
}
