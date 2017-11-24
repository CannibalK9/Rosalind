using Rosalind.Converters;
using System;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class SpeedingUpMotifFinding
    {
        //http://rosalind.info/problems/kmp/

        public SpeedingUpMotifFinding()
        {
            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;

            int sequence = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i != 0 && input[sequence] == input[i])
                    sequence++;
                else if (sequence != 0)
                {
                    for (int j = sequence; j >= 0; j--)
                    {
                        if (input.Substring(0, j).Equals(input.Substring(i - j + 1, j)))
                        {
                            sequence = j;
                            break;
                        }
                    }
                }
                else
                    sequence = 0;

                Console.Write(sequence + " ");
            }
        }
    }
}
