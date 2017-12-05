using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class ExpectedNumberOfRestrictionSites
    {
        //http://rosalind.info/problems/eval/

        public ExpectedNumberOfRestrictionSites()
        {
            var inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();

            double events = Convert.ToInt32(inputs[0]) + 1 + (-inputs[1].Length);
            double AT = inputs[1].Count(c => c == 'T' || c == 'A');
            double GC = inputs[1].Count(c => c == 'G' || c == 'C');

            foreach (var item in inputs[2].Split(' ').Select(s=> Convert.ToDouble(s)))
            {
                Console.Write(Math.Pow(((1 - item)/2), AT) * Math.Pow(item/2, GC) * events + " ");
            }
        }
    }
}
