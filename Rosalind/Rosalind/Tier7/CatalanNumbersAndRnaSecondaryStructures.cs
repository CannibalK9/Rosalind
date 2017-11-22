using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class CatalanNumbersAndRnaSecondaryStructures
    {
        //http://rosalind.info/problems/cat/

        public CatalanNumbersAndRnaSecondaryStructures()
        {
            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;
            List<char> nodes = input.ToCharArray().ToList();
            var store = new Dictionary<KeyValuePair<int, int>, long>();

            long result = 0;

            for (int i = 1; i < nodes.Count; i += 2)
            {
                var pair = new KeyValuePair<int, int>(0, i);
                long rtn = CatalanNumbers(store, nodes, pair, i);
                result = (result + rtn) % 1000000;
            }

            Console.WriteLine(result);
        }

        private Dictionary<char, char> _validConnections = new Dictionary<char, char> { { 'U', 'A' }, { 'A', 'U' }, { 'C', 'G' }, { 'G', 'C' } };

        private long CatalanNumbers(Dictionary<KeyValuePair<int, int>, long> store, List<char> nodes, KeyValuePair<int, int> nodePair, int matchingNodeIndex)
        {
            long count = 0;

            if (_validConnections[nodes[0]] == nodes[matchingNodeIndex])
            {
                var side1 = new List<char>();
                var side2 = new List<char>();

                for (int i = 1; i < matchingNodeIndex; i++)
                {
                    side1.Add(nodes[i]);
                }

                for (int i = matchingNodeIndex + 1; i < nodes.Count; i++)
                {
                    side2.Add(nodes[i]);
                }

                int nodeIndex = 1;
                long count1 = 0;
                long count2 = 0;
                var pair1 = new KeyValuePair<int, int>(nodePair.Key + 1, nodePair.Key + matchingNodeIndex + (-1));
                var pair2 = new KeyValuePair<int, int>(nodePair.Key + 1 + matchingNodeIndex, nodePair.Value);

                if (side1.Count <= 2)
                {
                    count1 = side1.Any() && _validConnections[side1[0]] != side1[1] ? 0 : 1;
                }
                else if (store.ContainsKey(pair1))
                    count1 = store[pair1];
                else
                {
                    while (nodeIndex < side1.Count)
                    {
                        count1 = (count1 + CatalanNumbers(store, side1, pair1, nodeIndex)) % 1000000;
                        nodeIndex += 2;
                    }
                    store.Add(pair1, count1);
                }

                nodeIndex = 1;
                if (side2.Count <= 2)
                {
                    count2 = side2.Any() && _validConnections[side2[0]] != side2[1] ? 0 : 1;
                }
                else if (store.ContainsKey(pair2))
                    count2 = store[pair2];
                else
                {
                    while (nodeIndex < side2.Count)
                    {
                        count2 = (count2 + CatalanNumbers(store, side2, pair2, nodeIndex)) % 1000000;
                        nodeIndex += 2;
                    }
                    store.Add(pair2, count2);
                }

                count = (count1) * (count2);
            }
            return count % 1000000;
        }
    }
}
