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

            for (int i = 0; i < lines.Length; i += 3)
            {
                var counts = new List<int>();
                int[] arr1 = lines[i].Split(' ').Select(c => Convert.ToInt32(c)).ToArray();
                int[] arr2 = lines[i + 1].Split(' ').Select(c => Convert.ToInt32(c)).ToArray();

                CalculateReversalDistance(counts, new List<KeyValuePair<int, int>>(), arr1, arr2, 0);

                Console.Write(counts.Min() + " ");
            }
        }

        private void CalculateReversalDistance(List<int> counts, List<KeyValuePair<int, int>> swaps, int[] arr1, int[] arr2, int count)
        {
            int[] newArr1 = (int[])arr1.Clone();

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (i != j && newArr1[i] == arr2[j] && newArr1[j] == arr2[i])
                    {
                        int temp = newArr1[i];
                        newArr1[i] = newArr1[j];
                        newArr1[j] = temp;
                        count++;
                    }
                }
            }

            int differences = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (newArr1[i] != arr2[i])
                    differences++;
            }

            if (differences == 0)
            {
                counts.Add(count);
                return;
            }

            int prediction = count + (differences + 1) / 2;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (newArr1[i] == arr2[i])
                    continue;

                for (int j = 0; j < newArr1.Length; j++)
                {
                    if (prediction >= newArr1.Length || (counts.Any() && prediction >= counts.Min()))
                        return;

                    int[] newerarr1 = (int[])newArr1.Clone();

                    var thisSwap = new KeyValuePair<int, int>(Math.Min(i, j), Math.Max(i, j));
                    if (i == j || (newerarr1[i] != arr2[j] && newerarr1[j] != arr2[i]) || swaps.Contains(thisSwap))
                        continue;

                    swaps.RemoveAll(s => s.Key == thisSwap.Key || s.Key == thisSwap.Value || s.Value == thisSwap.Key || s.Value == thisSwap.Value);
                    swaps.Add(thisSwap);

                    int temp = newerarr1[i];
                    newerarr1[i] = newerarr1[j];
                    newerarr1[j] = temp;
                    CalculateReversalDistance(counts, swaps, newerarr1, arr2, count + 1);
                }
            }

        }
    }
}
