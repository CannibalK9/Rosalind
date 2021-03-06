﻿using Rosalind.Converters;
using Rosalind.Tier9;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class CountingOptimalAlignments
    {
        //http://rosalind.info/problems/ctea/

        public CountingOptimalAlignments()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            var pairs = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();
            _s1 = dnaStrings[0];
            _s2 = dnaStrings[1];
            int changeCount = EditDistanceAlignment.GenerateAlignmentPathPairs(_s1, _s2, _s1.Length - 1, _s2.Length - 1, pairs);

            ulong count = CountPaths(pairs, pairs.Last().Key, new Dictionary<KeyValuePair<int, int>, ulong>());
            Console.WriteLine(count);
        }

        private string _s1;
        private string _s2;

        private ulong CountPaths(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs, KeyValuePair<int, int> index, Dictionary<KeyValuePair<int, int>, ulong> morePairs)
        {
            if (index.Key + index.Value <= 1)
            {
                return 1;
            }
            else if (morePairs.ContainsKey(index))
            {
                return morePairs[index];
            }
            else
            {
                ulong count = 0;

                int currentIndex = pairs[index].Key;
                int currentValue = pairs[index].Value;

                var diag = new KeyValuePair<int, int>(index.Key - 1, index.Value - 1);
                var up = new KeyValuePair<int, int>(index.Key, index.Value - 1);
                var left = new KeyValuePair<int, int>(index.Key - 1, index.Value);

                var diagValue = pairs.Keys.Contains(diag) ? pairs[diag] : new KeyValuePair<int, int>(10000, 10000);
                var upValue = pairs.Keys.Contains(up) ? pairs[up] : new KeyValuePair<int, int>(10000, 10000);
                var leftValue = pairs.Keys.Contains(left) ? pairs[left] : new KeyValuePair<int, int>(10000, 10000);

                if ((diagValue.Key == currentIndex - 1 && _s1[index.Key] != _s2[index.Value]) || (diagValue.Key == currentIndex && _s1[index.Key] == _s2[index.Value]))
                    count += CountPaths(pairs, diag, morePairs) % 134217727;

                if (upValue.Key == currentIndex - 1 && currentValue != 0)
                    count += CountPaths(pairs, up, morePairs) % 134217727;

                if (leftValue.Key == currentIndex - 1 && currentValue != 0)
                    count += CountPaths(pairs, left, morePairs) % 134217727;

                morePairs.Add(index, count);

                return count;
            }
        }
    }
}
