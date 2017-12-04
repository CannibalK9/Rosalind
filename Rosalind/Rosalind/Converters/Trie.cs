using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Converters
{
    public static class Trie
    {
        private static int _removed;

        public static Dictionary<KeyValuePair<int, int>, string> GetTrie(IEnumerable<string> inputs)
        {
            _removed = 0;
            var trie = new Dictionary<KeyValuePair<int, int>, string>();

            foreach (string dna in inputs)
                using (var sr = new StringReader(dna))
                    ProcessNode(trie, new KeyValuePair<KeyValuePair<int, int>, string>(new KeyValuePair<int, int>(1, 2), ""), sr, '\0');

            return trie;
        }

        private static void ProcessNode(Dictionary<KeyValuePair<int, int>, string> trie, KeyValuePair<KeyValuePair<int, int>, string> currentNode, StringReader sr, char previousC)
        {
            bool isPreviousC = previousC != '\0';
            char c = previousC;

            for (int i = 0; i < currentNode.Value.Length; i++)
            {
                c = isPreviousC ? c : Convert.ToChar(sr.Read());
                isPreviousC = false;
                if (c != '\0')
                {
                    if (c != currentNode.Value[i])
                    {
                        if (trie.Any(t => t.Key.Key == currentNode.Key.Value))
                        {
                            int newNode = trie.Count + _removed + 2;
                            trie.Add(new KeyValuePair<int, int>(currentNode.Key.Key, newNode), currentNode.Value.Substring(0, i));
                            trie.Add(new KeyValuePair<int, int>(newNode, currentNode.Key.Value), currentNode.Value.Substring(i));
                            trie.Add(new KeyValuePair<int, int>(newNode, trie.Count + _removed + 2), c + sr.ReadToEnd());
                            trie.Remove(currentNode.Key);
                            _removed++;
                        }
                        else
                        {
                            trie.Add(new KeyValuePair<int, int>(currentNode.Key.Value, trie.Count + _removed + 2), currentNode.Value.Substring(i));
                            trie.Add(new KeyValuePair<int, int>(currentNode.Key.Value, trie.Count + _removed + 2), c + sr.ReadToEnd());
                            trie[currentNode.Key] = currentNode.Value.Substring(0, i);
                        }
                        return;
                    }
                }
                else
                    break;
            }

            c = Convert.ToChar(sr.Read());
            var next = trie.SingleOrDefault(t => t.Key.Key == currentNode.Key.Value && t.Value[0] == c);
            if (string.IsNullOrEmpty(next.Value))
                trie.Add(new KeyValuePair<int, int>(currentNode.Key.Value, trie.Count + _removed + 2), c + sr.ReadToEnd());
            else
                ProcessNode(trie, trie.SingleOrDefault(t => t.Key.Key == currentNode.Key.Value && t.Value[0] == c), sr, c);
        }
    }
}