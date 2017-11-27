using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class IntroductionToSetOperations
    {
        //http://rosalind.info/problems/seto/

        public IntroductionToSetOperations()
        {
            string[] lines = File.ReadAllLines(@"C:\code\dataset.txt");

            var set1 = new List<int>(lines[1].Substring(1, lines[1].Length - 2).Split(',').Select(s => Convert.ToInt32(s.Trim())));
            var set2 = new List<int>(lines[2].Substring(1, lines[2].Length - 2).Split(',').Select(s => Convert.ToInt32(s.Trim())));

            var complement1 = new List<int>();
            var complement2 = new List<int>();

            for (int i = 1; i <= Convert.ToInt32(lines[0]); i++)
            {
                if (set1.Contains(i) == false)
                    complement1.Add(i);
                if (set2.Contains(i) == false)
                    complement2.Add(i);
            }

            Console.WriteLine("{" + string.Join(", ", set1.Union(set2)) + "}");
            Console.WriteLine("{" + string.Join(", ", set1.Intersect(set2)) + "}");
            Console.WriteLine("{" + string.Join(", ", set1.Where(s => set2.Contains(s) == false)) + "}");
            Console.WriteLine("{" + string.Join(", ", set2.Where(s => set1.Contains(s) == false)) + "}");
            Console.WriteLine("{" + string.Join(", ", complement1) + "}");
            Console.WriteLine("{" + string.Join(", ", complement2) + "}");
        }
    }
}
