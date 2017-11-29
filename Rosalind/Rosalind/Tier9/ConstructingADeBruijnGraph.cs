using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class ConstructingADeBruijnGraph
    {
        //http://rosalind.info/problems/dbru/

        public ConstructingADeBruijnGraph()
        {
            string[] inputList = File.ReadAllLines(@"C:\code\dataset.txt");
            var dnaList = new List<string>(inputList);
            foreach (var item in inputList)
            {
                dnaList.Add(ComplementingAStrandOfDna.ReverseCompliment(item, false));
            }

            dnaList = dnaList.Distinct().ToList();

            foreach (var item in dnaList)
            {
                Console.WriteLine(string.Format("({0}, {1})", item.Substring(0, item.Length - 1), item.Substring(1, item.Length - 1)));
            }
        }
    }
}
