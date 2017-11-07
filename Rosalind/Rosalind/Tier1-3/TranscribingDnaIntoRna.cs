using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public class TranscribingDnaIntoRna
    {
        //http://rosalind.info/problems/rna/

        public TranscribingDnaIntoRna(string input)
        {
            Console.WriteLine(input.Replace('T', 'U'));
        }
    }
}
