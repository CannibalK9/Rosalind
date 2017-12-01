using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Converters
{
    public static class CharacterTable
    {
        public static void WriteCharacterTable(List<TrieNode> trieNodes, List<string> lexList)
        {
            foreach (TrieNode node in trieNodes)
            {
                int maxValue = trieNodes.First().Value;
                if (node.ParentValue >= maxValue && node.IsLeaf == false)
                {
                    var taxaSubset = new List<string>();
                    var includedNodes = new List<int>();

                    AddParents(includedNodes, node.ParentValue, trieNodes, maxValue);

                    foreach (TrieNode node2 in trieNodes)
                    {
                        if (node2.Value != node.Value && (node2.Value == node.ParentValue || includedNodes.Contains(node2.ParentValue)))
                        {
                            includedNodes.Add(node2.Value);

                            if (node2.HasName)
                                taxaSubset.Add(node2.Name);
                        }
                    }

                    foreach (var taxon in lexList)
                    {
                        Console.Write(taxaSubset.Contains(taxon) ? 0 : 1);
                    }
                    Console.Write(Environment.NewLine);
                }
            }
        }

        private static void AddParents(List<int> nodes, int node, List<TrieNode> trieNodes, int maxValue)
        {
            int parent = trieNodes.Single(n => n.Value == node).ParentValue;
            if (parent >= maxValue)
            {
                nodes.Add(parent);
                AddParents(nodes, parent, trieNodes, maxValue);
            }
        }
    }
}
