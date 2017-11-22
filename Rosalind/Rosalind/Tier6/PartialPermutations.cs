using System;

namespace Rosalind.Tier6
{
    public class PartialPermutations
    {
        //http://rosalind.info/problems/pper/

        public PartialPermutations(int collection, int partial)
        {
            int count = 1;

            for (int i = 0; i < partial; i++)
                count = (count * collection--) % 1000000;

            Console.WriteLine(count);
        }
    }
}
