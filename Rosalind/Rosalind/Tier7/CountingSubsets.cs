using System;

namespace Rosalind.Tier7
{
    public class CountingSubsets
    {
        //http://rosalind.info/problems/sset/

        public CountingSubsets()
        {
            //2^n - This took far too long to see the most basic of patters, I forgot all about sub-patterns but this was a rude reminder

            int n = 939;
            int count = 2;

            for (int i = 1; i < n; i++)
            {
                count = (count * 2) % 1000000;
            }

            Console.WriteLine(count);
        }
    }
}
