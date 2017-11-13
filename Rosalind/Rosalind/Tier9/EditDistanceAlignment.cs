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

            var s1Chars = new List<char>(dnaStrings[0]);
            var s2Chars = new List<char>(dnaStrings[1]);


            int changeCount = Distance(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1, pairs);

            AddHyphens(s1Chars, s2Chars, pairs, pairs.Last().Key);

            Console.WriteLine(changeCount);
            Console.WriteLine(string.Join("", s1Chars));
            Console.WriteLine(string.Join("", s2Chars));
        }

        private void AddHyphens(List<char> c1, List<char> c2, Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs, KeyValuePair<int, int> index)
        {
            var diag = new KeyValuePair<int, int>(index.Key - 1, index.Value - 1);
            var up = new KeyValuePair<int, int>(index.Key, index.Value - 1);
            var left = new KeyValuePair<int, int>(index.Key - 1, index.Value);

            var diagValue = pairs.Keys.Contains(diag) ? pairs[diag] : new KeyValuePair<int, int>(10000, 10000);
            var upValue = pairs.Keys.Contains(up) ? pairs[up] : new KeyValuePair<int, int>(10000, 10000);
            var leftValue = pairs.Keys.Contains(left) ? pairs[left] : new KeyValuePair<int, int>(10000, 10000);

            if (diagValue.Key != 10000 && diagValue.Key <= upValue.Key && diagValue.Key <= leftValue.Key)
            {
                if (diagValue.Value == 1)
                    c1.Insert(index.Key + 1, '-');
                else if (diagValue.Value == 2)
                    c2.Insert(index.Value + 1, '-');

                AddHyphens(c1, c2, pairs, diag);
            }
            else if (upValue.Key != 10000 && upValue.Key <= leftValue.Key)
            {
                if (upValue.Value == 1)
                    c1.Insert(index.Key + 1, '-');
                else if (upValue.Value == 2)
                    c2.Insert(index.Value + 1, '-');

                AddHyphens(c1, c2, pairs, up);
            }
            else if (leftValue.Key != 10000)
            {
                if (leftValue.Value == 1)
                    c1.Insert(index.Key + 1, '-');
                else if (leftValue.Value == 2)
                    c2.Insert(index.Value + 1, '-');

                AddHyphens(c1, c2, pairs, left);
            }
            else if (index.Key > 0 || index.Value > 0)
            {
                if (index.Value > 0)
                {
                    c1.Insert(index.Key, '-');
                    AddHyphens(c1, c2, pairs, left);
                }
                else if (index.Key > 0)
                {
                    c2.Insert(index.Value, '-');
                    AddHyphens(c1, c2, pairs, up);
                }
            }
        }

        private int Distance(string s1, string s2, int s1Length, int s2Length, Dictionary<KeyValuePair<int,int>,KeyValuePair<int, int>> pairs)
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
                    int value = 0;

                    if (changeCount > s1Count || changeCount > s2Count)
                        value = s1Count > s2Count ? 1 : 2;

                    pairs.Add(pair, new KeyValuePair<int, int>(d, value));
                    return d;
                }
            }
        }
    }
}
