using System;

namespace Rosalind.Tier4
{
    public class RabbitsAndRecurrenceRelations
    {
        //http://rosalind.info/problems/fib/

        public RabbitsAndRecurrenceRelations(int iterations, int additions)
        {
            long rabbitPairsNonReproducing = 1;
            long rabbitPairsReproducing = 0;

            for (int i = 1; i < iterations; i++)
            {
                long rabbitPairsReproducingThisMonth = rabbitPairsReproducing;

                rabbitPairsReproducing += rabbitPairsNonReproducing;
                rabbitPairsNonReproducing = rabbitPairsReproducingThisMonth * additions;
            }

            Console.WriteLine(rabbitPairsNonReproducing + rabbitPairsReproducing);
        }
    }
}
