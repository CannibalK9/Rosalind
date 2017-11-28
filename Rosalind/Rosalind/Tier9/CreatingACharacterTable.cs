using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class CreatingACharacterTable
    {
        //http://rosalind.info/problems/ctbl/

        public CreatingACharacterTable()
        {
            var tree = new NewickTree(File.ReadAllLines(@"C:\code\dataset.txt")[0]);
            var lexList = new List<string>(tree.Nodes.Where(n => n.HasName).Select(n => n.Name));
            lexList.Sort();

            foreach (NewickNode node in tree.Nodes)
            {
                if (node.ParentValue >= 0 && node.IsLeaf == false)
                {
                    var taxaSubset = new List<string>();
                    var includedNodes = new List<int>();

                    AddParents(includedNodes, node.ParentValue, tree);

                    foreach (NewickNode node2 in tree.Nodes)
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

        private void AddParents(List<int> nodes, int node, NewickTree tree)
        {
            int parent = tree.Nodes.Single(n => n.Value == node).ParentValue;
            if (parent >= 0)
            {
                nodes.Add(parent);
                AddParents(nodes, parent, tree);
            }
        }
    }
}
