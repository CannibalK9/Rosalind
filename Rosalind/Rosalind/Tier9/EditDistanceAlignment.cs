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

            var pairs = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();

            int changeCount = Distance(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1, pairs);

            var s1Chars = new List<char>(dnaStrings[0]);
            var s2Chars = new List<char>(dnaStrings[1]);

            int i = pairs.Last().Key.Key;
            int j = pairs.Last().Key.Value;
            KeyValuePair<int, int> curr = new KeyValuePair<int, int>(i, j);

            AddHyphens(pairs, curr, s1Chars, s2Chars);

            while (s1Chars.Count < s2Chars.Count)
            {
                s1Chars.Insert(0, '-');
            }

            while (s1Chars.Count > s2Chars.Count)
            {
                s2Chars.Insert(0, '-');
            }

            Console.WriteLine(changeCount);
            Console.WriteLine(string.Join("", s1Chars));
            Console.WriteLine(string.Join("", s2Chars));
        }

        private void AddHyphens(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs, KeyValuePair<int, int> pair, List<char> s1Chars, List<char> s2Chars)
        {
            var diag = new KeyValuePair<int, int>(pair.Key - 1, pair.Value - 1);
            var up = new KeyValuePair<int, int>(pair.Key, pair.Value - 1);
            var left = new KeyValuePair<int, int>(pair.Key - 1, pair.Value);

            KeyValuePair<int, int> diagValue = pairs.ContainsKey(diag) ? pairs[diag] : new KeyValuePair<int, int>(-1, -1);
            KeyValuePair<int, int> upValue = pairs.ContainsKey(up) ? pairs[up] : new KeyValuePair<int, int>(-1, -1);
            KeyValuePair<int, int> leftValue = pairs.ContainsKey(left) ? pairs[left] : new KeyValuePair<int, int>(-1, -1);

            if (diagValue.Key >= 0 && diagValue.Key <= upValue.Key && diagValue.Key <= leftValue.Key)
            {
                if (diagValue.Value == 1)
                    s1Chars.Insert(pair.Key, '-');
                else if (diagValue.Value == 2)
                    s2Chars.Insert(pair.Value, '-');
                AddHyphens(pairs, diag, s1Chars, s2Chars);
            }
            else if (upValue.Key >= 0 && upValue.Key <= leftValue.Key)
            {
                if (upValue.Value == 1)
                    s1Chars.Insert(pair.Key, '-');
                else if (upValue.Value == 2)
                    s2Chars.Insert(pair.Value, '-');
                AddHyphens(pairs, up, s1Chars, s2Chars);
            }
            else if (leftValue.Key >= 0)
            {
                if (leftValue.Value == 1)
                    s1Chars.Insert(pair.Key, '-');
                else if (leftValue.Value == 2)
                    s2Chars.Insert(pair.Value, '-');
                AddHyphens(pairs, left, s1Chars, s2Chars);
            }
        }

        private int Distance(string s1, string s2, int s1Length, int s2Length, Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs)
        {
            var pair = new KeyValuePair<int, int>(s1Length, s2Length);

            if (s1Length < 0 || s2Length < 0)
            {
                return Math.Abs(s1Length - s2Length);
            }
            else if (s1[s1Length] == s2[s2Length])
            {
                if (pairs.ContainsKey(pair))
                    return pairs[pair].Key;
                else
                {
                    int d = Distance(s1, s2, s1Length - 1, s2Length - 1, pairs);
                    pairs.Add(pair, new KeyValuePair<int, int>(d, 0));
                    return d;
                }
            }
            else
            {
                if (pairs.ContainsKey(pair))
                    return pairs[pair].Key;
                else
                {
                    int s1Count = 1 + Distance(s1, s2, s1Length - 1, s2Length, pairs);
                    int s2Count = 1 + Distance(s1, s2, s1Length, s2Length - 1, pairs);
                    int changeCount = 1 + Distance(s1, s2, s1Length - 1, s2Length - 1, pairs);

                    int d = Math.Min(s1Count, Math.Min(s2Count, changeCount));
                    pairs.Add(pair, new KeyValuePair<int, int>(d, changeCount <= s1Count && changeCount <= s2Count ? 0 : s1Count < s2Count ? 2 : 1));
                    return d;
                }
            }
        }
    }
}
