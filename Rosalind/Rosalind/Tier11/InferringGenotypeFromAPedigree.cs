using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Tier11
{
    public class InferringGenotypeFromAPedigree
    {
        //http://rosalind.info/problems/mend/

        public InferringGenotypeFromAPedigree()
        {
            var tree = new NewickTree(File.ReadAllLines(@"C:\code\dataset.txt")[0]);

            for (int i = tree.Nodes.Count - 1; i > 0; i--)
            {
                TrieNode node = tree.Nodes[i];
                TrieNode parent = tree.Nodes[node.ParentValue];
                if (string.IsNullOrEmpty(parent.Name))
                    parent.Name = node.Name;
                else
                    parent.Name = Combined(parent.Name, node.Name);
            }

            List<string> stuff = tree.Nodes[0].Name.Split(',').ToList();
            float count = stuff.Count;
            float aa = stuff.Count(s => s.Equals("aa"));
            float Aa = stuff.Count(s => s.Equals("Aa"));
            float AA = stuff.Count(s => s.Equals("AA"));

            Console.Write(aa / count + " " + Aa / count + " " + AA / count);
        }

        private string Combined(string s1, string s2)
        {
            List<string> list1 = s1.Split(',').ToList();
            List<string> list2 = s2.Split(',').ToList();

            var result = new List<string>();

            for (int i = 0; i < list1.Count; i++)
            {
                if (string.IsNullOrEmpty(list1[i]))
                    continue;

                for (int j = 0; j < list2.Count; j++)
                {
                    if (string.IsNullOrEmpty(list2[j]))
                        continue;

                    result.AddRange(SimpleCombine(list1[i], list2[j]));
                }
            }

            return string.Join(",", result);
        }

        private List<string> SimpleCombine(string s1, string s2)
        {
            var result = new List<string>();
            int As = (s1 + s2).ToList().Count(c => c == 'A');

            switch (As)
            {
                case 0:
                    return new List<string> { "aa" };
                case 1:
                    return new List<string> { "Aa", "aa", "aa", "aa" };
                case 2:
                    if (s1[0] == s1[1])
                        return new List<string> { "Aa" };
                    else
                        return new List<string> { "AA", "Aa", "Aa", "aa" };
                case 3:
                    return new List<string> { "AA", "AA", "AA", "Aa" };
                case 4:
                    return new List<string> { "AA" };
                default:
                    return new List<string>();
            }
        }
    }
}
