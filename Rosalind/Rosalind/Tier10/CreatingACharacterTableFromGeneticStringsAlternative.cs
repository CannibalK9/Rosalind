using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class CreatingACharacterTableFromGeneticStringsAlternative
    {
        //http://rosalind.info/problems/cstr/

        public CreatingACharacterTableFromGeneticStringsAlternative()
        {
            //This actually sorts the strings according to how they'd split if they were arranged like a trie

            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();

            string start = "";
            var results = new List<string>();
            Loop(results, inputs, start);

            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        private void Loop(List<string> results, List<string> inputs, string start)
        {
            string chars = "ACGT";
            for (int i = 0; i < chars.Length; i++)
            {
                start += chars[i];
                if (Write(results, inputs, start))
                    Loop(results, inputs, start);
                start = start.Remove(start.Length - 1, 1);
            }
        }

        private bool Write(List<string> results, List<string> inputs, string start)
        {
            string result = "";
            int count = 0;
            foreach (var item in inputs)
            {
                if (item.StartsWith(start))
                {
                    result += 1;
                    count++;
                }
                else
                    result += 0;
            }

            if (count > 1)
                results.Add(result);
            return count > 1;
        }
    }
}
