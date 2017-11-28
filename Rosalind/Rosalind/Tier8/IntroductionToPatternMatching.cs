using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class IntroductionToPatternMatching
    {
        //http://rosalind.info/problems/trie/

        public IntroductionToPatternMatching()
        {
            var trie = new Dictionary<KeyValuePair<int, int>, char>();

            IEnumerable<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt");

            foreach (string dna in inputs)
            {
                int nextNode = 1;
                bool newChain = false;
                foreach (char c in dna)
                {
                    if (newChain == false)
                    {
                        if (trie.Any(t => t.Value == c && t.Key.Key == nextNode))
                        {
                            nextNode = trie.Single(t => t.Value == c && t.Key.Key == nextNode).Key.Value;
                        }
                        else
                            newChain = true;
                    }
                    
                    if (newChain)
                    {
                        int lastNode = trie.Count + 2;
                        trie.Add(new KeyValuePair<int, int>(nextNode, lastNode), c);
                        nextNode = lastNode;
                    }
                }
            }

            foreach (var item in trie)
            {
                Console.WriteLine(string.Format("{0} {1} {2}",
                    item.Key.Key,
                    item.Key.Value,
                    item.Value));
            }
        }
    }
}
