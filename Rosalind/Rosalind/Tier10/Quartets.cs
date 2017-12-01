using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class Quartets
    {
        //http://rosalind.info/problems/qrt/

        public Quartets()
        {
            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            List<string> taxa = inputs[0].Split(' ').ToList();

            var quartets = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();

            for (int i = 1; i < inputs.Count; i++)
            {
                var aSplit = new List<int>();
                var bSplit = new List<int>();

                SortSplits(aSplit, bSplit, inputs[i]);

                var aSubsets = new List<KeyValuePair<int, int>>();
                var bSubsets = new List<KeyValuePair<int, int>>();

                CreateSubsets(aSubsets, aSplit);
                CreateSubsets(bSubsets, bSplit);

                MakeQuartets(quartets, aSubsets, bSubsets);
            }

            foreach (var item in quartets)
            {
                Console.WriteLine("{" + taxa[item.Key.Key] + ", " + taxa[item.Key.Value] + "} {" + taxa[item.Value.Key] + ", " + taxa[item.Value.Value] + "}");
            }
        }

        private void SortSplits(List<int> aSplit, List<int> bSplit, string input)
        {
            for (int j = 0; j < input.Length; j++)
            {
                switch (input[j])
                {
                    case '0':
                        aSplit.Add(j);
                        break;
                    case '1':
                        bSplit.Add(j);
                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateSubsets(List<KeyValuePair<int, int>> subsets, List<int> indexes)
        {
            for (int i = 0; i < indexes.Count - 1; i++)
            {
                for (int j = i + 1; j < indexes.Count; j++)
                {
                    subsets.Add(new KeyValuePair<int, int>(indexes[i], indexes[j]));
                }
            }
        }

        private void MakeQuartets(List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> quartets, List<KeyValuePair<int, int>> aSubsets, List<KeyValuePair<int, int>> bSubsets)
        {
            foreach (var aSubset in aSubsets)
            {
                foreach (var bSubset in bSubsets)
                {
                    if (quartets.Contains(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(aSubset, bSubset)) == false && quartets.Contains(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(bSubset, aSubset)) == false)
                    {
                        quartets.Add(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(aSubset, bSubset));
                    }
                }
            }
        }
    }
}
