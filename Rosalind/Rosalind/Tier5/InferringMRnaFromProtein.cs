using Rosalind.Converters;
using System;
using System.IO;

namespace Rosalind.Tier5
{
    public class InferringMRnaFromProtein
    {
        //http://rosalind.info/problems/mrna/

        public InferringMRnaFromProtein()
        {
            using (var fileStream = new StreamReader(@"C:\code\dataset.txt"))
            {
                int count = RnaCodontoAA.NumberOfStops();

                while (fileStream.EndOfStream == false)
                {
                    char c = Convert.ToChar(fileStream.Read());
                    count = (count * c.NumberOfProteinSources()) % 1000000;
                }

                Console.WriteLine(count);
            }
        }
    }
}
