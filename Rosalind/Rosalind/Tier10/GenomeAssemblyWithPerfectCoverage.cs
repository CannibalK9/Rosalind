using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class GenomeAssemblyWithPerfectCoverage
    {
        //http://rosalind.info/problems/pcov/

        public GenomeAssemblyWithPerfectCoverage()
        {
            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            string superString = inputs[0];
            inputs.RemoveAt(0);

            int length = 1;
            while (inputs.Count > 0)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    string input = inputs[i];
                    if (superString.Contains(input) == false)
                    {
                        if (superString.StartsWith(input.Substring(length)))
                        {
                            superString = input.Substring(0, length) + superString;
                            inputs.RemoveAt(i);
                            break;
                        }
                        else if (superString.EndsWith(input.Substring(0, input.Length - length)))
                        {
                            superString += input.Substring(input.Length - length);
                            inputs.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            string newString = null;
            for (int i = 1; i < superString.Length; i++)
            {
                if (superString.EndsWith(superString.Substring(0, i)))
                {
                    newString = superString.Substring(i);
                    superString = newString;
                    break;
                }
            }

            Console.WriteLine(superString);
        }
    }
}
