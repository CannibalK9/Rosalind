using Rosalind.Converters;
using System;
using System.IO;


namespace Rosalind.Tier5
{
    public class CalculatingProteinMass
    {
        //http://rosalind.info/problems/prtm/

        public CalculatingProteinMass()
        {
            using (var fileStream = new StreamReader(@"C:\code\dataset.txt"))
            {
                double weight = 0;

                while (fileStream.EndOfStream == false)
                {
                    char c = Convert.ToChar(fileStream.Read());
                    weight += c.Monoisotopic();
                }
                Console.WriteLine(weight);
            }
        }
    }
}
