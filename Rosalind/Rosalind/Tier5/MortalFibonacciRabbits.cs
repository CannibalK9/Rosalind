using System;

namespace Rosalind.Tier5
{
    public class MortalFibonacciRabbits
    {
        //http://rosalind.info/problems/fibd/

        public MortalFibonacciRabbits()
        {
            string[] input = Console.ReadLine().Split(' ');
            int iterations = Convert.ToInt32(input[0]);
            int longevity = Convert.ToInt32(input[1]);

            long[] monthBirths = new long[iterations + 1];
            long rabbitPairsNonReproducing = 1;
            long rabbitPairsReproducing = 0;

            for (int i = 1; i < iterations; i++)
            {
                monthBirths[i - 1] = rabbitPairsNonReproducing;

                long rabbitPairsReproducingThisMonth = rabbitPairsReproducing;

                rabbitPairsReproducing += rabbitPairsNonReproducing;
                rabbitPairsNonReproducing = rabbitPairsReproducingThisMonth;

                if (i - longevity >= 0)
                    rabbitPairsReproducing -= monthBirths[i - longevity];
            }

            Console.WriteLine(rabbitPairsNonReproducing + rabbitPairsReproducing);
        }
    }
}
