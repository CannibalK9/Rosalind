using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosalind.Converters;

namespace Rosalind.Tier10
{
    public class UsingTheSpectrumGraphToInferPeptides
    {
        //http://rosalind.info/problems/sgra/

        public UsingTheSpectrumGraphToInferPeptides()
        {
            List<double> masses = File.ReadAllLines(@"C:\code\dataset.txt").Select(l => Convert.ToDouble(l)).ToList();
            var words = new List<string>();
            string word = "";

            for (int i = 1; i < masses.Count; i++)
            {
                if ((masses[i] - masses[i - 1]).GetCharFromMass(out char c))
                {
                    word += c;
                }
                else if (string.IsNullOrEmpty(word) == false)
                {
                    words.Add(word);
                    word = "";
                }
            }
        }
    }
}
