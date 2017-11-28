using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier8
{
    public class InferringProteinFromSpectrum
    {
        //http://rosalind.info/problems/spec/

        public InferringProteinFromSpectrum()
        {
            IEnumerable<double> inputs = File.ReadAllLines(@"C:\code\dataset.txt").Select(s => Convert.ToDouble(s));
            double current = 0;

            foreach (double input in inputs)
            {
                if (current != 0)
                    Console.Write((input - current).GetCharFromMass());
                current = input;
            }
        }
    }
}
