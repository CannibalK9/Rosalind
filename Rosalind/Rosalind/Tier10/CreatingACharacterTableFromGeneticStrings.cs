using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Tier10
{
    public class CreatingACharacterTableFromGeneticStrings
    {
        //http://rosalind.info/problems/cstr/

        public CreatingACharacterTableFromGeneticStrings()
        {
            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            Dictionary<KeyValuePair<int, int>, char> trie = Trie.GetTrie(inputs);
            var lexList = new List<string>();

            for (int i = 0; i < inputs.Count; i++)
            {
                lexList.Add(i.ToString());
            }

            var nodes = new List<TrieNode>();

            int name = 0;
            int max = trie.First().Key.Value;
            bool passedFirst = false;

            foreach (var item in trie)
            {
                int neighbours = trie.Count(t => t.Key.Key == item.Key.Value);

                int value = item.Key.Key;
                if (value < max)
                {
                    if (passedFirst)
                        value = max;
                    passedFirst = true;
                }

                if (neighbours == 0)
                {
                    nodes.Add(new TrieNode(item.Key.Value, value, name.ToString(), true));
                    name++;
                }
                else if (neighbours == 2)
                {
                    nodes.Add(new TrieNode(item.Key.Value, value, "", false));
                }
                else
                {
                    nodes.Add(new TrieNode(item.Key.Value, value, "", true));
                }
            }

            CharacterTable.WriteCharacterTable(nodes, lexList);
        }
    }
}
