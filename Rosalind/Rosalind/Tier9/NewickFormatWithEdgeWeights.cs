using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class NewickFormatWithEdgeWeights
    {
        //http://rosalind.info/problems/nkew/

        public NewickFormatWithEdgeWeights()
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

                Console.Write((GetWeight(tree, minNode, highestCommonNode) + GetWeight(tree, maxNode, highestCommonNode - stepDifference)) + " ");
            }
        }

        private int GetWeight(string tree, int node, int steps)
        {
            if (steps == 0)
                return 0;

            using (var sr = new StringReader(tree))
            {
                for (int i = 0; i < node; i++)
                    sr.Read();

                int weight = 0;
                char next = '\0';

                while (next != ':')
                    next = Convert.ToChar(sr.Read());

                string numbers = "";

                while (next != ',' && next != ')')
                {
                    next = Convert.ToChar(sr.Read());
                    if (next != ',' && next != ')')
                        numbers += next;
                }

                weight += Convert.ToInt32(numbers);


                for (int i = 1; i < steps; i++)
                {
                    bool weightAssigned = false;
                    int bracketDepth = 1;

                    if (next == ':')
                        bracketDepth = 0;

                        while (weightAssigned == false)
                    {
                        if (bracketDepth == 0)
                        {
                            if (next != ':')
                                while (next != ')' && next != '(')
                                    next = Convert.ToChar(sr.Read());

                            if (next == '(')
                                bracketDepth++;
                            else
                            {
                                while (next != ':')
                                    next = Convert.ToChar(sr.Read());

                                numbers = "";

                                while (next != ',' && next != ')')
                                {
                                    next = Convert.ToChar(sr.Read());
                                    if (next != ',' && next != ')')
                                        numbers += next;
                                }

                                weight += Convert.ToInt32(numbers);
                                weightAssigned = true;

                                if (i == steps - 1)
                                    break;
                            }
                        }

                        else
                        {
                            if (next != '(' && next != ')')
                                while (next != ')' && next != '(')
                                    next = Convert.ToChar(sr.Read());

                            if (next == '(')
                                bracketDepth++;
                            else
                                bracketDepth--;
                        }

                        int cInt = sr.Read();
                        next = Convert.ToChar(cInt);
                    }
                }

                return weight;
            }
        }
    }
}
