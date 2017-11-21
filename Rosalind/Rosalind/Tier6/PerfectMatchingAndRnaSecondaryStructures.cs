using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class PerfectMatchingAndRnaSecondaryStructures
    {
        //http://rosalind.info/problems/pmch/

        public PerfectMatchingAndRnaSecondaryStructures()
        {
            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;
            _perfectLength = input.Length / 2;

            var result = new List<List<KeyValuePair<int, int>>>();
            Matches(input, result, new List<KeyValuePair<int, int>>());
            Console.WriteLine(result.Count);
        }

        private Dictionary<char, char> _validConnections = new Dictionary<char, char> { { 'U', 'A' }, { 'A', 'U' }, { 'C', 'G' }, { 'G', 'C' } };
        private int _perfectLength;

        private void Matches(string input, List<List<KeyValuePair<int, int>>> matchesCollection, List<KeyValuePair<int, int>> currentMatch)
        {
            int i = 0;
            if (currentMatch.Any())
            {
                for (int k = 0; k < input.Length; k++)
                {
                    if (currentMatch.All(c => c.Key != k && c.Value != k))
                    {
                        i = k;
                        break;
                    }
                }
                if (i == 0)
                    return;
            }

            var buildingMatches = new List<List<KeyValuePair<int, int>>>();

            for (int j = i + 1; j < input.Length; j++)
            {
                if (_validConnections[input[i]] != input[j] || currentMatch.Any(c => c.Key == j || c.Value == j))
                    continue;

                var newMatches = new List<KeyValuePair<int, int>>(currentMatch);
                newMatches.Add(new KeyValuePair<int, int>(i, j));

                buildingMatches.Add(newMatches);
            }

            foreach (var item in buildingMatches)
            {
                if (item.Count == _perfectLength)
                    matchesCollection.Add(item);
                else
                    Matches(input, matchesCollection, item);
            }
        }
    }
}
