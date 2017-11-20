using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Rosalind.Tier5
{
    public class FindingAProteinMotif
    {
        //http://rosalind.info/problems/mprt/

        public FindingAProteinMotif()
        {
            var regex = new Regex("[N][^P][ST][^P]");

            using (var client = new WebClient())
            {
                foreach (string line in File.ReadLines(@"C:\code\dataset.txt"))
                {
                    string dnaString = string.Join("", client.DownloadString(string.Format("http://www.uniprot.org/uniprot/{0}.fasta", line))
                        .Split('\n')
                        .Where(s => s.StartsWith(">") == false));

                    var matches = new List<Match>();

                    Match matchObj = regex.Match(dnaString);
                    while (matchObj.Success)
                    {
                        matches.Add(matchObj);
                        matchObj = regex.Match(dnaString, matchObj.Index + 1);
                    }

                    if (matches.Any())
                    {
                        Console.WriteLine(line);
                        Console.WriteLine(string.Join(" ", matches.Select(m => m.Index + 1)));
                    }
                }
            }
        }
    }
}
