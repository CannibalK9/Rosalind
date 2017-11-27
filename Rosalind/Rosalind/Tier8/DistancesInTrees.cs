using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class DistancesInTrees
    {
        //http://rosalind.info/problems/nwck/

        public DistancesInTrees()
        {
            string[] lines = File.ReadAllLines(@"C:\code\dataset.txt");

            for (int i = 0; i < lines.Length; i += 3)
            {
                string tree = lines[i].Substring(0, lines[i].Length - 1);
                List<string> comparisonNodes = lines[i + 1].Split(' ').ToList();

                string node1 = comparisonNodes[0];
                string node2 = comparisonNodes[1];

                int node1Index = tree.IndexOf(node1);
                int node2Index = tree.IndexOf(node2);

                int minNode = Math.Min(node1Index, node2Index);
                int maxNode = Math.Max(node1Index, node2Index);
                string between = tree.Substring(minNode, maxNode - minNode);

                int stepDifference = 0;
                int highestCommonNode = 0;
                bool parent = false;

                for (int j = 0; j < between.Length; j++)
                {
                    if (between[j] == ')')
                    {
                        stepDifference++;
                        if (stepDifference > highestCommonNode)
                            highestCommonNode = stepDifference;

                        if (j == between.Length - 1)
                            parent = true;
                    }
                    else if (between[j] == '(')
                    {
                        stepDifference--;
                    }
                }

                if (parent == false || stepDifference <= 0 || stepDifference != highestCommonNode)
                    highestCommonNode++;

                Console.Write((highestCommonNode * 2 - stepDifference) + " ");
            }
        }
    }
}
