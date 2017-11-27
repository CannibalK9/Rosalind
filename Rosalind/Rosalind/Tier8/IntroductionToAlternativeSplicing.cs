using System;
using System.Collections.Generic;

namespace Rosalind.Tier8
{
    public class IntroductionToAlternativeSplicing
    {
        //http://rosalind.info/problems/aspc/

        public IntroductionToAlternativeSplicing(int setSize, int subsetSize)
        {
            var set = new List<int>() { 1 };

            for (int i = 0; i < setSize; i++)
            {
                for (int j = 0; j < set.Count - 1; j++)
                {
                    set[j] = (set[j] + set[j + 1]) % 1000000;
                }

                set.Insert(0, 1);
            }

            int count = 0;

            for (int i = subsetSize; i < set.Count; i++)
            {
                count = (count + set[i]) % 1000000;
            }

            Console.WriteLine(count);
        }
    }
}
