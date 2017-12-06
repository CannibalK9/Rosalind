using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Tier9
{
    public class IndependentSegregationOfChromosomes
    {
        //http://rosalind.info/problems/indc/

        public IndependentSegregationOfChromosomes()
        {
            Console.WriteLine(BinomCoefficient(10, 5));
        }

        public static double BinomCoefficient(double n, double k)
        {
            if (k > n) { return 0; }
            if (n == k) { return 1; } // only one way to chose when n == k
            if (k > n - k) { k = n - k; } // Everything is symmetric around n-k, so it is quicker to iterate over a smaller k than a larger one.
            double c = 1;
            for (double i = 1; i <= k; i++)
            {
                c *= n--;
                c /= i;
            }
            return c;
        }
    }
}
