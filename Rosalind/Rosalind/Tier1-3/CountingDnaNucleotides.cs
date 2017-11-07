using System;
using System.Linq;

namespace Rosalind
{
    public class CountingDnaNucleotides
    {
        //http://rosalind.info/problems/dna/

        public CountingDnaNucleotides(string input)
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}",
                input.Count(c => c == 'A'),
                input.Count(c => c == 'C'),
                input.Count(c => c == 'G'),
                input.Count(c => c == 'T')));
        }
    }
}
