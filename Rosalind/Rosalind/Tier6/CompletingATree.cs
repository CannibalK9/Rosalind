using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class CompletingATree
    {
        //http://rosalind.info/problems/tree/

        public CompletingATree()
        {
            //The tree has one fewer edges than nodes, so this can be solved in a single line~~

            var connected = new List<List<int>>();
            bool[] nodes = null;

            foreach (string line in File.ReadAllLines(@"C:\code\dataset.txt"))
            {
                if (nodes == null)
                {
                    int nodeCount = Convert.ToInt32(line);
                    nodes = new bool[nodeCount];
                }
                else
                {
                    int node1 = Convert.ToInt32(line.Split(' ')[0]);
                    int node2 = Convert.ToInt32(line.Split(' ')[1]);
                    nodes[node1 - 1] = true;
                    nodes[node2 - 1] = true;

                    var connectionIndeces = new List<int>();

                    for (int i = 0; i < connected.Count; i++)
                    {
                        if (connectionIndeces.Count == 2)
                            break;

                        if (connected[i].Contains(node1))
                            connectionIndeces.Add(i);

                        if (connected[i].Contains(node2))
                            connectionIndeces.Add(i);
                    }

                    var pairedNodes = new List<int> { node1, node2 };

                    if (connectionIndeces.Any() == false)
                        connected.Add(pairedNodes);
                    else if (connectionIndeces.Count == 1 || connectionIndeces[0] == connectionIndeces[1])
                        connected[connectionIndeces[0]].AddRange(pairedNodes);
                    else
                    {
                        connected[connectionIndeces[0]].AddRange(connected[connectionIndeces[1]]);
                        connected[connectionIndeces[0]].AddRange(pairedNodes);
                        connected.RemoveAt(connectionIndeces[1]);
                    }
                }
            }

            int newEdgeCount = connected.Count - 1;
            newEdgeCount += nodes.Count(n => n == false);

            Console.WriteLine(newEdgeCount);
        }
    }
}
