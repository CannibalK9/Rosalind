using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class OpenReadingFrames
    {
        //http://rosalind.info/problems/orf/

        public OpenReadingFrames()
        {
            var proteins = new List<ProteinString>();
            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value.Replace('T', 'U');

            FindProteinOpenFrames(proteins, input);
            FindProteinOpenFrames(proteins, input.Substring(1));
            FindProteinOpenFrames(proteins, input.Substring(2));

            input = ComplementingAStrandOfDna.ReverseCompliment(input, true);

            FindProteinOpenFrames(proteins, input);
            FindProteinOpenFrames(proteins, input.Substring(1));
            FindProteinOpenFrames(proteins, input.Substring(2));

            proteins.Select(p => p.Protein).Distinct().ToList().ForEach(p => Console.WriteLine(p));
        }

        private void FindProteinOpenFrames(List<ProteinString> proteins, string input)
        {
            for (int i = 0; i < input.Length - (input.Length % 3) - 2; i += 3)
            {
                string protein = (input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString()).ConvertCodon();

                if (protein == "Stop")
                {
                    proteins.ForEach(p => p.CanWrite = false);
                }
                else
                {
                    proteins.Where(p => p.CanWrite).ToList().ForEach(p => p.Protein += protein);

                    if (protein == "M")
                        proteins.Add(new ProteinString { Protein = protein, CanWrite = true });
                }
            }
            proteins.RemoveAll(p => p.CanWrite);
        }

        private class ProteinString
        {
            public string Protein;
            public bool CanWrite;
        }
    }
}
