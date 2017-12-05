using Rosalind.Tier9;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class InterleavingTwoMotifs
    {
        //http://rosalind.info/problems/scsp/

        public InterleavingTwoMotifs()
        {
            List<string> distanceStrings = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            string s0 = distanceStrings[0];
            string s1 = distanceStrings[1];

            Write("", s0, s1, 0, 0);

            if (s0.Length > s1.Length)
            {
                int diff = s0.Length - s1.Length;
                Write(s0.Substring(0, diff), s0, s1, diff, 0);
            }
            else if (s1.Length > s0.Length)
            {
                int diff = s1.Length - s0.Length;
                Write(s1.Substring(0, diff), s0, s1, 0, diff);
            }

            Console.WriteLine();

            //var withhyphens = EditDistanceAlignment.GetDistanceStrings(distanceStrings);

            //for (int i = 0; i < withhyphens[0].Length; i++)
            //{
            //    char c0 = withhyphens[0][i];
            //    char c1 = withhyphens[1][i];
            //    if (c0 != c1)
            //    {
            //        if (c0 == '-' || c1 == '-')
            //            Console.Write(c0 == '-' ? c1 : c0);
            //        else
            //            Console.Write(c0.ToString() + c1.ToString());
            //    }
            //    else
            //        Console.Write(c0);
            //}
        }

        private void Write(string result, string s0, string s1, int i0, int i1)
        {
            while (true)
            {
                if (i0 > s0.Length - 1)
                {
                    result += s1.Substring(i1);
                    break;
                }
                if (i1 > s1.Length - 1)
                {
                    result += s0.Substring(i0);
                    break;
                }

                if (s0[i0] == s1[i1])
                {
                    result += s0[i0];
                    i0++;
                    i1++;
                }
                else
                {
                    if (s0.Length - 2 < i0 || s0[i0 + 1] == s1[i1])
                    {
                        result += s0[i0];
                        i0++;
                    }
                    else if (s1.Length - 2 < i1 || s0[i0] == s1[i1 + 1])
                    {
                        result += s1[i1];
                        i1++;
                    }
                    else
                    {
                        result += s0[i0];
                        result += s1[i1];
                        i0++;
                        i1++;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
