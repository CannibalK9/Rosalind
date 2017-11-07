﻿using System;

namespace Rosalind
{
    public class CountingPointMutations
    {
        //http://rosalind.info/problems/hamm/

        public CountingPointMutations(string input1, string input2)
        {
            int hammingDistance = 0;

            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != input2[i])
                    hammingDistance++;
            }

            Console.WriteLine(hammingDistance);
        }
    }
}
