using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class InferringPeptideFromFullSpectrum
    {
        //http://rosalind.info/problems/full/

        public InferringPeptideFromFullSpectrum()
        {
            //requires a bit of manual work~!

            List<double> masses = File.ReadAllLines(@"C:\code\dataset.txt").Select(l => Convert.ToDouble(l)).ToList();

            var bIon = new KeyValuePair<string, double>("", masses[1]);
            var yIon = new KeyValuePair<string, double>("", masses[1]);

            for (int i = 2; i < masses.Count; i++)
            {
                if ((masses[i] - bIon.Value).GetCharFromMass(out char c))
                    bIon = new KeyValuePair<string, double>(bIon.Key + c, masses[i]);
                else if ((masses[i] - yIon.Value).GetCharFromMass(out c))
                    yIon = new KeyValuePair<string, double>(yIon.Key + c, masses[i]);
            }

            Console.WriteLine((masses.Count - 3) / 2);
            Console.WriteLine(bIon.Key.Length + ": " + bIon.Key);
            Console.WriteLine(yIon.Key.Length + ":  " + string.Join("",yIon.Key.Reverse()));
        }
    }
}
