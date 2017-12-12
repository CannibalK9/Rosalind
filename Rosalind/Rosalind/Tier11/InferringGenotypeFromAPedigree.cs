﻿using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier11
{
    public class InferringGenotypeFromAPedigree
    {
        //http://rosalind.info/problems/mend/

        public InferringGenotypeFromAPedigree()
        {
            var tree = new NewickTree(File.ReadAllLines(@"C:\code\dataset.txt")[0]);

            for (int i = tree.Nodes.Count - 1; i > 0; i--)
            {
                TrieNode node = tree.Nodes[i];
                TrieNode parent = tree.Nodes[node.ParentValue];
                if (string.IsNullOrEmpty(parent.Name))
                    parent.Name = node.Name;
                else
                    parent.Name = NewCombined(parent.Name, node.Name);
            }

            List<double> stuff = tree.Nodes[0].Name.Split(' ').Select(s=> Convert.ToDouble(s)).ToList();
            double aa = stuff[2];
            double Aa = stuff[1];
            double AA = stuff[0];
            double count = aa + Aa + AA;

            Console.Write(AA / count + " " + Aa / count + " " + aa / count);
        }

        private string NewCombined(string s1, string s2)
        {
            long[] int1 = s1.ToLower().Contains("a") ? nos(s1) : s1.Split(' ').Select(n => Convert.ToInt64(n)).ToArray();
            long[] int2 = s2.ToLower().Contains("a") ? nos(s2) : s2.Split(' ').Select(n => Convert.ToInt64(n)).ToArray();

            long AA = int1[0] * int2[0] * 4 + int1[0] * int2[1] * 2 + int1[1] * int2[0] * 2 + int1[1] * int2[1];
            long Aa = int1[0] * int2[1] * 2 + int1[1] * int2[0] * 2 + int1[1] * int2[1] * 2 + int1[2] * int2[1] * 2 + int1[1] * int2[2] * 2 + int1[0] * int2[2] * 4;
            long aa = int1[2] * int2[2] * 4 + int1[2] * int2[1] * 2 + int1[1] * int2[2] * 2 + int1[1] * int2[1];

            return AA + " " + Aa + " " + aa;
        }

        private long[] nos(string str)
        {
            List<string> list = str.Split(',').ToList();

            long aa = list.Count(s => s.Equals("aa"));
            long Aa = list.Count(s => s.Equals("Aa"));
            long AA = list.Count(s => s.Equals("AA"));

            return new long[] { AA, Aa, aa };
        }

        //private string Combined(string s1, string s2)
        //{
        //    List<string> list1 = s1.Split(',').ToList();
        //    List<string> list2 = s2.Split(',').ToList();

        //    var result = new List<string>();

        //    for (long i = 0; i < list1.Count; i++)
        //    {
        //        for (long j = 0; j < list2.Count; j++)
        //        {
        //            result.AddRange(SimpleCombine(list1[i], list2[j]));
        //        }
        //    }

        //    return string.Join(",", result);
        //}

        //private List<string> SimpleCombine(string s1, string s2)
        //{
        //    var result = new List<string>();
        //    long As = (s1 + s2).ToList().Count(c => c == 'A');

        //    switch (As)
        //    {
        //        case 0:
        //            return new List<string> { "aa", "aa", "aa", "aa" };
        //        case 1:
        //            return new List<string> { "Aa", "Aa", "aa", "aa" };
        //        case 2:
        //            if (s1[0] == s1[1])
        //                return new List<string> { "Aa", "Aa", "Aa", "Aa" };
        //            else
        //                return new List<string> { "AA", "Aa", "Aa", "aa" };
        //        case 3:
        //            return new List<string> { "AA", "AA", "Aa", "Aa" };
        //        case 4:
        //            return new List<string> { "AA", "AA", "AA", "AA" };
        //        default:
        //            return new List<string>();
        //    }
        //}
    }
}
