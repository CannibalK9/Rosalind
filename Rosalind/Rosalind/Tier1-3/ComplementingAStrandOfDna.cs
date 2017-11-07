using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public class ComplementingAStrandOfDna
    {
        //http://rosalind.info/problems/revc/

        public ComplementingAStrandOfDna(string input)
        {
            foreach(char c in input.Reverse())
            {
                switch(c)
                {
                    case 'A':
                        Console.Write('T');
                        break;
                    case 'T':
                        Console.Write('A');
                        break;
                    case 'G':
                        Console.Write('C');
                        break;
                    case 'C':
                        Console.Write('G');
                        break;
                }
            }
        }
    }
}
