using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class MotzkinNumbersAndRnaSecondaryStructures
    {
        //http://rosalind.info/problems/motz/

        public MotzkinNumbersAndRnaSecondaryStructures()
        {
            //Add all the most obvious ones as far as you can one at a time, then step back and retread all the way through

            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;
            List<char> nodes = input.ToCharArray().ToList();
            var store = new Dictionary<KeyValuePair<int, int>, long>();

            long result = 0;

            for (int i = 1; i < nodes.Count; i += 2)
            {
                var pair = new KeyValuePair<int, int>(0, i);
                long rtn = MotzkinNumbers(store, nodes, pair, i);
                result = (result + rtn) % 1000000;
            }

            Console.WriteLine(1 + result); //add one for no connections
        }

        private Dictionary<char, char> _validConnections = new Dictionary<char, char> { { 'U', 'A' }, { 'A', 'U' }, { 'C', 'G' }, { 'G', 'C' } };

        private long MotzkinNumbers(Dictionary<KeyValuePair<int, int>, long> store, List<char> nodes, KeyValuePair<int, int> nodePair, int matchingNodeIndex)
        {
            long count = 1; //each new node is +1

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

                var pair1 = new KeyValuePair<int, int>(nodePair.Key + 1, nodePair.Key + matchingNodeIndex + (-1));
                var pair2 = new KeyValuePair<int, int>(nodePair.Key + 1 + matchingNodeIndex, nodePair.Value);

                long count1 = bloop(store, side1, pair1);
                long count2 = bloop(store, side2, pair2);

                count1 = count1 == 0 ? 1 : count1;
                count2 = count2 == 0 ? 1 : count2;

                count += (count1) * (count2);
            }
            return count % 1000000;
        }

        private long bloop(Dictionary<KeyValuePair<int, int>, long> store, List<char> subNodes, KeyValuePair<int, int> pair)
        {
            long count = 0;
            int nodeIndex = 1;

            if (subNodes.Count <= 2)
            {
                count = subNodes.Any() && _validConnections[subNodes[0]] == subNodes[1] ? 2 : 0; //if there are no nodes, there's no combinations wherein they're connected
            }
            else if (store.ContainsKey(pair))
                count = store[pair];
            else
            {
                while (nodeIndex < subNodes.Count)
                {
                    count = (count + MotzkinNumbers(store, subNodes, pair, nodeIndex)) % 1000000; //repeat even for combinations that can't be perfect
                    nodeIndex ++;
                }
                store.Add(pair, count);
            }

            return count;
        }
    }
}