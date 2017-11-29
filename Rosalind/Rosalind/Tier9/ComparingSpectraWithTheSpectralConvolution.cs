using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class ComparingSpectraWithTheSpectralConvolution
    {
        //http://rosalind.info/problems/conv/

        public ComparingSpectraWithTheSpectralConvolution()
        {
            string[] inputList = File.ReadAllLines(@"C:\code\dataset.txt");
            List<double> set1 = inputList[0].Split(' ').Select(s => Convert.ToDouble(s)).ToList();
            List<double> set2 = inputList[1].Split(' ').Select(s => Convert.ToDouble(s)).ToList();

            var spectralConvolution = new List<double>();

            foreach (var num in set1)
            {
                foreach (var num2 in set2)
                {
                    spectralConvolution.Add(Math.Round(num - num2, 5));
                }
            }

            var result = spectralConvolution.GroupBy(s => s).OrderByDescending(s => s.Count()).First();
            Console.WriteLine(result.Count());
            Console.WriteLine(result.First());
        }
    }
}
