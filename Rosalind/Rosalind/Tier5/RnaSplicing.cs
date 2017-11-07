using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier5
{
    public class RnaSplicing
    {
        //http://rosalind.info/problems/splc/

        public RnaSplicing()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            string dnaString = dnaStrings[0];

            for (int i = 1; i < dnaStrings.Count; i++)
            {
                dnaString = dnaString.Replace(dnaStrings[i], "");
            }

            dnaString = dnaString.Replace('T', 'U');

            using (var stringReader = new StringReader(dnaString))
            {
                string aa = "";

                while (aa != "Stop")
                {
                    char[] buffer = new char[3];
                    stringReader.ReadBlock(buffer, 0, 3);

                    aa = string.Join("", buffer).ConvertCodon();

                    if (aa != "Stop")
                        Console.Write(aa);
                }
            }
        }
    }
}
