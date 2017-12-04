using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class CreatingACharacterTableFromGeneticStringsActual
    {
        //http://rosalind.info/problems/cstr/

        public CreatingACharacterTableFromGeneticStringsActual()
        {
            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();

            for (int j = 0; j < inputs[0].Length; j++)
            {
                string result = "";
                char c = inputs[0][j];

                for (int i = 0; i < inputs.Count; i++)
                {
                    result += inputs[i][j] == c ? 1 : 0;
                }
                if (result.Count(c2 => c2 == '1') > 1 && result.Count(c2 => c2 == '0') > 1)
                    Console.WriteLine(result);
            }
        }
    }
}