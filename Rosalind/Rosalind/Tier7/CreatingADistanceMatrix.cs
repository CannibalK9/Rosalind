using Rosalind.Converters;
using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class CreatingADistanceMatrix
    {
        //http://rosalind.info/problems/pdst/

        public CreatingADistanceMatrix()
        {
            string[] dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToArray();
            double stringLength = dnaStrings[0].Length;

            for (int i = 0; i < dnaStrings.Length; i++)
            {
                for (int j = 0; j < dnaStrings.Length; j++)
                {
                    double pDistance = 0; 

                    if (i != j)
                    {
                        for (int k = 0; k < stringLength; k++)
                        {
                            if (dnaStrings[i][k] != dnaStrings[j][k])
                                pDistance++;
                        }
                    }

                    Console.Write((pDistance / stringLength).ToString("0.00000") + " ");
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
