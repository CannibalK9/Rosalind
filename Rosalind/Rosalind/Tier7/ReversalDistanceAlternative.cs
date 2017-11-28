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
                List<KeyValuePair<int, int>> result = null;

                int intDifferences = GetDifferences(arr1, arr2);
                if (intDifferences != 0)
                    result = CalculateReversalDistance(
                        new List<KeyValuePair<List<int>, List<KeyValuePair<int, int>>>> { new KeyValuePair<List<int>, List<KeyValuePair<int, int>>>(arr1, new List<KeyValuePair<int, int>>()) },
                        arr2,
                        0,
                        intDifferences);

                Console.WriteLine(result.Count);
                foreach (var item in result)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }
        }

        private List<KeyValuePair<int, int>> CalculateReversalDistance(List<KeyValuePair<List<int>, List<KeyValuePair<int, int>>>> stuff, List<int> arr2, int count, int intDifference)
        {
            var allOfEm = new List<KeyValuePair<List<int>, List<KeyValuePair<int, int>>>>();
            count++;
            int thisDifferences = intDifference;

            foreach (var item in stuff)
            {
                for (int i = 0; i < item.Key.Count - 1; i++)
                {
                    for (int j = i + 1; j < item.Key.Count; j++)
                    {
                        var new1 = Reverse(item.Key, i, j);
                        int differences = GetDifferences(new1, arr2);
                        if (differences == 0)
                        {
                            item.Value.Add(new KeyValuePair<int, int>(i + 1, j + 1));
                            return item.Value;
                        }
                        if (differences <= thisDifferences + 2)
                        {
                            if (differences < thisDifferences)
                                thisDifferences = differences;
                            var add = new List<KeyValuePair<int, int>>(item.Value);
                            add.Add(new KeyValuePair<int, int>(i + 1, j + 1));
                            allOfEm.Add(new KeyValuePair<List<int>, List<KeyValuePair<int, int>>>(new1, add));
                        }
                    }
                }
            }
            return CalculateReversalDistance(allOfEm, arr2, count, thisDifferences);
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
