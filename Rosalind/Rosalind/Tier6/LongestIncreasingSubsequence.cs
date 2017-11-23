using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class LongestIncreasingSubsequence
    {
        //http://rosalind.info/problems/lgis/

        public LongestIncreasingSubsequence()
        {
            int[] sequence = File.ReadAllLines(@"C:\code\dataset.txt")[1].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            Run(sequence, true);
            Run(sequence, false);
        }

        private void Run(int[] sequence, bool isAscending)
        {
            var indexCounts = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                int result = Longest(sequence, indexCounts, i, isAscending);
                count = result > count ? result : count;
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (indexCounts[i] == count)
                {
                    Console.Write(sequence[i] + (count == 0 ? Environment.NewLine : " "));
                    count--;
                }
            }
        }

        private int Longest(int[] sequence, Dictionary<int, int> indexCounts, int index, bool isAscending)
        {
            if (indexCounts.ContainsKey(index))
                return indexCounts[index];
            else
            {
                int count = 0;

                for (int i = index + 1; i < sequence.Length; i++)
                {
                    if (isAscending ? sequence[index] < sequence[i] : sequence[index] > sequence[i])
                    {
                        int next = 1 + Longest(sequence, indexCounts, i, isAscending);
                        if (next > count)
                        {
                            count = next;
                        }
                    }
                }
                indexCounts.Add(index, count);
                return count;
            }
        }
    }
}
