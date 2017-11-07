using System;

namespace Rosalind.Tier4
{
    public class FindingAMotifInDna
    {
        //http://rosalind.info/problems/subs/

        public FindingAMotifInDna(string s, string sub)
        {
            for (int i = 0; i < s.Length - sub.Length; i++)
            {
                if (s.Substring(i, sub.Length).Equals(sub))
                    Console.Write(i + 1 + " ");
            }
        }
    }
}
