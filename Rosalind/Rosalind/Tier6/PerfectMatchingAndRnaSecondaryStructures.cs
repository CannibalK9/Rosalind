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

            var result = new List<List<int>>();
            Matches(input, result, new List<int>());
        }

        private Dictionary<char, char> _validConnections = new Dictionary<char, char> { { 'U', 'A' }, { 'A', 'U' }, { 'C', 'G' }, { 'G', 'C' } };
        private int _perfectLength;

        private void Matches(string input, List<List<int>> matchesCollection, List<int> matches)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (Math.Abs(i - j) <= 1 || _validConnections[input[i]] != input[j] || matches.Any(m => m / input.Length == i || m % input.Length == j || m / input.Length == j || m % input.Length == i))
                        continue;

                    var newMatches = new List<int>(matches);
                    if (i < j)
                        newMatches.Add(i * input.Length + j);
                    else
                        newMatches.Add(j * input.Length + i);

                    if (newMatches.Count == _perfectLength)
                    {
                        newMatches.Sort();

                        if (matchesCollection.Any())
                        {
                            foreach (var match in matchesCollection)
                            {
                                bool same = true;
                                for (int k = 0; k < _perfectLength; k++)
                                {
                                    if (match[k] != newMatches[k])
                                        same = false;
                                }

                                if (same)
                                    return;
                            }
                        }
                        matchesCollection.Add(newMatches);
                        return;
                    }
                    Matches(input, matchesCollection, newMatches);
                }
            }
        }
    }
}
