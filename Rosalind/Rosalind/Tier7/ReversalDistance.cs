using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class ReversalDistance
    {
        //http://rosalind.info/problems/rear/

        public ReversalDistance()
        {
            string[] lines = File.ReadAllLines(@"C:\code\dataset.txt");

            for (int i = 0; i < lines.Length; i+=3)
            {
                var counts = new List<int>();
                int[] arr1 = lines[i].Split(' ').Select(c=>Convert.ToInt32(c)).ToArray();
                int[] arr2 = lines[i+1].Split(' ').Select(c => Convert.ToInt32(c)).ToArray();

                CalculateReversalDistance(counts, arr1, arr2);

                Console.Write(counts.Min() + " ");
            }
        }

        private int CalculateReversalDistance(List<int> counts, int[] arr1, int[] arr2)
        {
            int count = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                    continue;

                int temp = 0;

                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[j] == arr1[i])
                    {
                        temp = arr1[i];
                        arr1[i] = arr1[j];
                        arr1[j] = temp;
                        count += 1 + CalculateReversalDistance(counts, arr1, arr2);
                        counts.Add(count);
                    }
                }

            }

            return count;
        }
    }
}
