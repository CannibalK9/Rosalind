using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind
{
    public class EnumeratingKMersLexicographically
    {
        //http://rosalind.info/problems/lexf/

        private List<string> _output = new List<string>();

        public EnumeratingKMersLexicographically(string symbols, int length)
        {
            List<string> symbolList = symbols.Split(' ').ToList();
            symbolList.Sort();
            Solve(symbolList, string.Empty, length);

            foreach(string s in _output)
            {
                Console.WriteLine(s);
            }
        }

        private void Solve(List<string> symbolList, string output, int length)
        {
            foreach (string symbol in symbolList)
            {
                if (output.Length == length - 1)
                {
                    _output.Add(output + symbol);
                    continue;
                }
                else if (output.Length < length)
                    Solve(symbolList, output + symbol, length);
            }
        }
    }
}
