using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier10
{
    public class MatchingASpectrumToAProtein
    {
        //http://rosalind.info/problems/prsm/

        public MatchingASpectrumToAProtein()
        {
            //If you know some of the masses of a spectrum, then removing each mass from every possible mass in each protein
            //and finding the most common resulting masses tells you which protein it most likely relates to

            List<string> inputs = File.ReadAllLines(@"C:\code\dataset.txt").ToList();
            var strings = new Dictionary<string, List<double>>();

            for (int i = 1; i < Convert.ToInt32(inputs[0]); i++)
            {
                strings.Add(inputs[i], new List<double>());
            }

            List<double> masses = new List<double>();

            for (int i = Convert.ToInt32(inputs[0]) + 1; i < inputs.Count; i++)
            {
                masses.Add(Convert.ToDouble(inputs[i]));
            }

            foreach (var s in new List<string>(strings.Keys))
            {
                var thisMasses = GetAllPrefixes(s);
                thisMasses.AddRange(GetAllPrefixes(string.Join("", s.Reverse())));

                strings[s] = thisMasses;
            }

            int maxMultiplicity = 0;
            string result = "";

            foreach (var s in strings)
            {
                var multList = new List<double>();

                foreach (var sMass in s.Value)
                {
                    foreach (var mass in masses)
                    {
                        multList.Add(Math.Round(mass - sMass, 4));
                    }
                }

                foreach (double d in multList)
                {
                    int thisMultiplicity = multList.Count(sc => sc == d);
                    if (maxMultiplicity < thisMultiplicity)
                    {
                        maxMultiplicity = thisMultiplicity;
                        result = s.Key;
                    }
                }
            }

            Console.WriteLine(maxMultiplicity);
            Console.WriteLine(result);
        }

        private List<double> GetAllPrefixes(string s)
        {
            var weights = new List<double>();
            double mass = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                mass += s[i].Monoisotopic();
                weights.Add(Math.Round(mass, 5));
            }

            return weights;
        }
    }
}
