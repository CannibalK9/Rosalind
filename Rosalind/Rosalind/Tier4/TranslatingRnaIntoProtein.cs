using Rosalind.Converters;
using System;
using System.IO;

namespace Rosalind.Tier4
{
    public class TranslatingRnaIntoProtein
    {
        //http://rosalind.info/problems/prot/

        public TranslatingRnaIntoProtein()
        {
            using (var fileStream = new StreamReader(@"C:\code\dataset.txt"))
            {
                string aa = "";

                while (aa != "Stop" && fileStream.EndOfStream == false)
                {
                    char[] buffer = new char[3];
                    fileStream.ReadBlock(buffer, 0, 3);

                    aa = string.Join("", buffer).ConvertCodon();

                    if (aa != "Stop")
                        Console.Write(aa);
                }
            }
        }
    }
}
