using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Converters
{
    public static class MassTable
    {
        private static Dictionary<char, double> Table = new Dictionary<char, double>
        {
            {'A',  71.03711 },
            {'C', 103.00919 },
            {'D', 115.02694 },
            {'E', 129.04259 },
            {'F', 147.06841 },
            {'G',  57.02146 },
            {'H', 137.05891 },
            {'I', 113.08406 },
            {'K', 128.09496 },
            {'L', 113.08406 },
            {'M', 131.04049 },
            {'N', 114.04293 },
            {'P',  97.05276 },
            {'Q', 128.05858 },
            {'R', 156.10111 },
            {'S',  87.03203 },
            {'T', 101.04768 },
            {'V',  99.06841 },
            {'W', 186.07931 },
            {'Y', 163.06333 },
        };

        public static string Chars = "ACDEFGHIKLMNPQRSTVWY";

        public static double Monoisotopic(this char c)
        {
            return Table.ContainsKey(c)
                ? Table[c]
                : 0;
        }

        public static bool GetCharFromMass(this double mass, out char c)
        {
            mass = Math.Round(mass, 4);
            bool contains = Table.Values.Select(v=> Math.Round(v, 4)).Contains(mass);
            c = contains ? Table.First(t => Math.Round(t.Value, 4) == mass).Key : '\0';
            return contains;
        }
    }
}
