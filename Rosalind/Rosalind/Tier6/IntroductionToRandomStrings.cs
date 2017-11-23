using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class IntroductionToRandomStrings
    {
        //http://rosalind.info/problems/prob/

        public IntroductionToRandomStrings()
        {
            //Should log each value and add them together to handle tiny numbers

            string[] lines = File.ReadAllLines(@"C:\code\dataset.txt");
            int GC = lines[0].Count(c => c == 'G' || c == 'C');
            int AT = lines[0].Count(c => c == 'A' || c == 'T');

            foreach (string value in lines[1].Split(' '))
            {
                Console.Write(GetProb(GC, AT, Convert.ToDouble(value)) + " ");
            }
        }

        private double GetProb(int GC, int AT, double content)
        {
            return Math.Log10(Math.Pow((1 - content) / 2, AT) * Math.Pow(content / 2, GC));
        }
    }
}
