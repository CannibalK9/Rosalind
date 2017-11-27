using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class ReversalDistanceAlternative
    {
        //http://rosalind.info/problems/rear/

        public ReversalDistanceAlternative()
        {
            //Can do one at a time, but runs out of memory trying to do too many

            string[] lines = File.ReadAllLines(@"C:\code\dataset.txt");

            for (int i = 0; i < lines.Length; i += 3)
            {
                List<int> arr1 = lines[i].Split(' ').Select(c => Convert.ToInt32(c)).ToList();
                List<int> arr2 = lines[i + 1].Split(' ').Select(c => Convert.ToInt32(c)).ToList();
                int result = 0;

                int intDifferences = GetDifferences(arr1, arr2);
                if (intDifferences != 0)
                    result = CalculateReversalDistance(new List<List<int>> { arr1 }, arr2, 0, intDifferences);

                Console.Write(result + " ");
            }
        }

        private int CalculateReversalDistance(List<List<int>> stuff, List<int> arr2, int count, int intDifference)
        {
            List<List<int>> allOfEm = new List<List<int>>();
            count++;
            int thisDiffereces = intDifference;

            foreach (var item in stuff)
            {
                for (int i = 0; i < item.Count - 1; i++)
                {
                    for (int j = i + 1; j < item.Count; j++)
                    {
                        var new1 = Reverse(item, i, j);
                        int differences = GetDifferences(new1, arr2);
                        if (differences == 0)
                            return count;

                        if (differences <= thisDiffereces + 2)
                        {
                            if (differences < thisDiffereces)
                                thisDiffereces = differences;
                            allOfEm.Add(new1);
                        }
                    }
                }
            }
            return CalculateReversalDistance(allOfEm, arr2, count, thisDiffereces);
        }

        private List<int> Reverse(List<int> nums, int indexStart, int indexEnd)
        {
            var rtn = new List<int>();
            if (indexStart > 0)
                rtn.AddRange(nums.GetRange(0, indexStart));
            var middle = nums.GetRange(indexStart, indexEnd - indexStart + 1);
            middle.Reverse();
            rtn.AddRange(middle);
            if (indexEnd != nums.Count - 1)
                rtn.AddRange(nums.GetRange(indexEnd + 1, nums.Count - rtn.Count));

            return rtn;
        }

        private int GetDifferences(List<int> list1, List<int> list2)
        {
            int differences = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                    differences++;
            }

            return differences;
        }
    }
}
