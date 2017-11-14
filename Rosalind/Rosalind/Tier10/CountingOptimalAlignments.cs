using Rosalind.Converters;
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
            int changeCount = EditDistanceAlignment.GenerateAlignmentPathPairs(dnaStrings[0], dnaStrings[1], dnaStrings[0].Length - 1, dnaStrings[1].Length - 1, pairs);

            DisplayPaths.Display(pairs);

            CountPaths(pairs, pairs.Last().Key);
            Console.WriteLine(_count);
        }

        private int _count;

        private void CountPaths(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs, KeyValuePair<int, int> index)
        {
            if ((index.Key == 1 && index.Value == 1) || (index.Key + index.Value == 1))
            {
                _count++;
                return;
            }

            var diag = new KeyValuePair<int, int>(index.Key - 1, index.Value - 1);
            var up = new KeyValuePair<int, int>(index.Key, index.Value - 1);
            var left = new KeyValuePair<int, int>(index.Key - 1, index.Value);

            var diagValue = pairs.Keys.Contains(diag) ? pairs[diag] : new KeyValuePair<int, int>(10000, 10000);
            var upValue = pairs.Keys.Contains(up) ? pairs[up] : new KeyValuePair<int, int>(10000, 10000);
            var leftValue = pairs.Keys.Contains(left) ? pairs[left] : new KeyValuePair<int, int>(10000, 10000);

            int lowest = Math.Min(diagValue.Key, Math.Min(upValue.Key, leftValue.Key));

            if (diagValue.Key == lowest && diagValue.Key != 10000)
                CountPaths(pairs, diag);

            if (upValue.Key == lowest && upValue.Key != 10000)
                CountPaths(pairs, up);

            if (leftValue.Key == lowest && leftValue.Key != 10000)
                CountPaths(pairs, left);
        }
    }
}
