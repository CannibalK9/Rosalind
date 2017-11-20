using System;
using System.Linq;
using System.Text;

namespace Rosalind
{
    public class ComplementingAStrandOfDna
    {
        //http://rosalind.info/problems/revc/

        public ComplementingAStrandOfDna(string input)
        {
            Console.WriteLine(ReverseCompliment(input, false));
        }

        public static string ReverseCompliment(string input, bool isRna)
        {
            var sb = new StringBuilder();

            foreach (char c in input.Reverse())
            {
                switch (c)
                {
                    case 'A':
                        if (isRna)
                            sb.Append('U');
                        else
                            sb.Append('T');
                        break;
                    case 'T':
                    case 'U':
                        sb.Append('A');
                        break;
                    case 'G':
                        sb.Append('C');
                        break;
                    case 'C':
                        sb.Append('G');
                        break;
                }
            }

            return sb.ToString();
        }
    }
}
