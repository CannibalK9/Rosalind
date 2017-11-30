using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class FindingTheLongestMultipleRepeat
    {
        //http://rosalind.info/problems/lrep/

        public FindingTheLongestMultipleRepeat()
        {
            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            var lengthFromNodes = new Dictionary<int, int>();
            var edges = new List<Edge>();
            string dna = inputs[0];
            int repeats = Convert.ToInt32(inputs[1]);

            for (int i = 2; i < inputs.Count; i++)
            {
                edges.Add(new Edge(inputs[i].Replace("node", "").Split(' ').Select(n => Convert.ToInt32(n)).ToArray()));
            }
            var orderedEdges = edges.OrderByDescending(e => e.Child);

            var nodeChildren = new Dictionary<int, int>();

            foreach (var edge in orderedEdges)
            {
                if (edges.Any(e => e.Parent == edge.Child))
                {
                    if (nodeChildren.ContainsKey(edge.Parent))
                        nodeChildren[edge.Parent] += nodeChildren[edge.Child];
                    else
                        nodeChildren.Add(edge.Parent, nodeChildren[edge.Child]);
                }
                else
                {
                    if (nodeChildren.ContainsKey(edge.Parent))
                        nodeChildren[edge.Parent] += 1;
                    else
                        nodeChildren.Add(edge.Parent, 1);
                }
            }

            var repeatedSubstrings = nodeChildren.Where(n => n.Value >= repeats).Select(n => n.Key).ToList();

            foreach (int childNode in repeatedSubstrings)
            {
                int parentNode = childNode;
                int length = 0;
                int location = 0;

                while (parentNode != 1)
                {
                    Edge thisEdge = edges.Single(e => e.Child == parentNode);
                    parentNode = thisEdge.Parent;
                    length += thisEdge.Length;
                    if (location == 0)
                        location = thisEdge.Location + length;
                }

                if (lengthFromNodes.ContainsKey(length) == false)
                    lengthFromNodes.Add(length, location);
            }

            var kvp = lengthFromNodes.OrderByDescending(l => l.Key).First();
            Console.WriteLine(dna.Substring(kvp.Value - kvp.Key - 1, kvp.Key));
        }

        private class Edge
        {
            public int Parent;
            public int Child;
            public int Location;
            public int Length;

            public Edge(int[] nums)
            {
                Parent = nums[0];
                Child = nums[1];
                Location = nums[2];
                Length = nums[3];
            }
        }
    }
}
