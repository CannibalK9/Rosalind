using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace Rosalind.Tier8
{
    public class IntroductionToPatternMatching
    {
        //http://rosalind.info/problems/trie/

        public IntroductionToPatternMatching()
        {
            IEnumerable<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt");

            Dictionary<KeyValuePair<int, int>, string> trie = Trie.GetTrie(inputs);

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
