using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind
{
    public class OrderingStringsOfVaryingLengthLexicographically
    {
        //http://rosalind.info/problems/lexv/

        private List<string> _output = new List<string>();

        public OrderingStringsOfVaryingLengthLexicographically(string symbols, int length)
        {
            List<string> symbolList = symbols.Split(' ').ToList();
            Solve(symbolList, string.Empty, length);

            File.AppendAllLines(@"C:\code\result.txt", _output);
        }

        private void Solve(List<string> symbolList, string output, int length)
        {
            foreach (string symbol in symbolList)
            {
                if (output.Length < length)
                {
                    _output.Add(output + symbol);
                    Solve(symbolList, output + symbol, length);
                }
            }
        }
    }
}
