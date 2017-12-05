using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class IndependentAlleles
    {
        //http://rosalind.info/problems/lia/

        public IndependentAlleles()
        {
            //Works until binomial coefficients come into play, at which point do it all manually!!

            int[] inputs = File.ReadAllLines(@"C:\code\dataset.txt")[0].Split(' ').Select(s=>Convert.ToInt32(s)).ToArray();

            int children = (int)Math.Pow(2, inputs[0]);
            double baseProb = Math.Pow(0.25, inputs[1]);

            double result = 0;

            for (int i = 0; i <= children - inputs[1]; i++)
            {
                result += baseProb * Math.Pow(0.75, i);
            }

            Console.WriteLine(result);
        }
    }
}
