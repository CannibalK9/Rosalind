using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Converters
{
    public static class Trie
    {
        public static Dictionary<KeyValuePair<int, int>, char> GetTrie(IEnumerable<string> inputs)
        {
            var trie = new Dictionary<KeyValuePair<int, int>, char>();

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

            return trie;
        }
    }
}
