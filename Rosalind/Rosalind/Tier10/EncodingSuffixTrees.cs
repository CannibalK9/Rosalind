using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class EncodingSuffixTrees
    {
        //http://rosalind.info/problems/suff/

        public EncodingSuffixTrees()
        {
            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();

            for (int i = 1; i < inputs[0].Length; i++)
            {
                inputs.Add(inputs[0].Substring(i));
            }

            Dictionary<KeyValuePair<int, int>, string> trie = Trie.GetTrie(inputs);

            trie.Values.ToList().ForEach(t => Console.WriteLine(t));
        }
    }
}
