using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class UsingTheSpectrumGraphToInferPeptides
    {
        //http://rosalind.info/problems/sgra/

        public UsingTheSpectrumGraphToInferPeptides()
        {
            List<double> masses = File.ReadAllLines(@"C:\code\dataset.txt").Select(l => Convert.ToDouble(l)).ToList();
            var edges = new Dictionary<KeyValuePair<int, int>, char>();

            for (int i = 0; i < masses.Count; i++)
            {
                for (int j = 0; j < masses.Count; j++)
                {
                    var first = new KeyValuePair<int, int>(j, i);
                    var second = new KeyValuePair<int, int>(i, j);

                    if (edges.ContainsKey(first) == false && edges.ContainsKey(second) == false)
                    {
                        if ((masses[i] - masses[j]).GetCharFromMass(out char c))
                        {
                            edges.Add(first, c);
                        }
                        else if ((masses[j] - masses[i]).GetCharFromMass(out c))
                        {
                            edges.Add(second, c);
                        }
                    }
                }
            }

            var strings = new Dictionary<KeyValuePair<int, int>, string>();
            foreach (var edge in edges)
            {
                CollectStrings(strings, edges, edge);
            }

            Console.WriteLine(strings.Values.OrderByDescending(s => s.Length).First());
        }

        private string CollectStrings(Dictionary<KeyValuePair<int, int>, string> strings, Dictionary<KeyValuePair<int, int>, char> edges, KeyValuePair<KeyValuePair<int, int>, char> edge)
        {
            if (strings.ContainsKey(edge.Key))
                return strings[edge.Key];

            var thisStrings = new List<string> { edge.Value.ToString() };

            foreach (var item in edges.Where(e => e.Key.Key == edge.Key.Value))
            {
                thisStrings.Add(edge.Value + CollectStrings(strings, edges, item));
            }

            string result = thisStrings.OrderByDescending(s => s.Length).First();
            strings.Add(edge.Key, result);
            return result;
        }
    }
}
