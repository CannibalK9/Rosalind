using Rosalind.Converters;
using Rosalind.Tier9;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class GlobalAlignmentWithScoringMatrix
    {
        //http://rosalind.info/problems/glob/

        public GlobalAlignmentWithScoringMatrix()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            var pairs = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();
            _s1 = dnaStrings[0];
            _s2 = dnaStrings[1];
            int changeCount = EditDistanceAlignment.GenerateAlignmentPathPairs(_s1, _s2, _s1.Length - 1, _s2.Length - 1, pairs);

            int count = CountPaths(pairs, pairs.Last().Key, new Dictionary<KeyValuePair<int, int>, int>());
            Console.WriteLine(count);
        }

        private string _s1;
        private string _s2;
        private const int _gapPenalty = 5;

        private int CountPaths(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> pairs, KeyValuePair<int, int> index, Dictionary<KeyValuePair<int, int>, int> morePairs)
        {
            if (morePairs.ContainsKey(index))
            {
                return morePairs[index];
            }
            else
            {
                int currentIndex = pairs[index].Key;
                int currentValue = pairs[index].Value;

                var diag = new KeyValuePair<int, int>(index.Key - 1, index.Value - 1);
                var up = new KeyValuePair<int, int>(index.Key, index.Value - 1);
                var left = new KeyValuePair<int, int>(index.Key - 1, index.Value);

                var diagValue = pairs.Keys.Contains(diag) ? pairs[diag] : new KeyValuePair<int, int>(10000, 10000);
                var upValue = pairs.Keys.Contains(up) ? pairs[up] : new KeyValuePair<int, int>(10000, 10000);
                var leftValue = pairs.Keys.Contains(left) ? pairs[left] : new KeyValuePair<int, int>(10000, 10000);

                var list = new List<int>();

                if ((diagValue.Key == currentIndex - 1 && _s1[index.Key] != _s2[index.Value]) || (diagValue.Key == currentIndex && _s1[index.Key] == _s2[index.Value]))
                {
                    list.Add(ScoringMatrices.BLOSUM62(_s1[index.Key], _s2[index.Value]) + CountPaths(pairs, diag, morePairs));
                }
                if (upValue.Key == currentIndex - 1 && currentValue != 0)
                {
                    list.Add(-_gapPenalty + CountPaths(pairs, up, morePairs));
                }
                if (leftValue.Key == currentIndex - 1 && currentValue != 0)
                {
                    list.Add(-_gapPenalty + CountPaths(pairs, left, morePairs));
                }

                int count = 0;
                
                if (index.Key == 0 || index.Value == 0)
                {
                    List<int> list2 = new List<int>();
                    for (int i = 0; i <= index.Key; i++)
                    {
                        for (int j = 0; j <= index.Value; j++)
                        {
                            list2.Add(ScoringMatrices.BLOSUM62(_s1[i], _s2[j]));
                        }
                    }
                    list.Add((Math.Abs(index.Key - index.Value) * -_gapPenalty) + list2.Max());
                }

                if (list.Any())
                {
                    count = list.Max();
                }
                morePairs.Add(index, count);
                return count;
            }
        }
    }
}
