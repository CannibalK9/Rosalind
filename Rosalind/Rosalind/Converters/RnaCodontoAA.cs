using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Converters
{
    public static class RnaCodontoAA
    {
        private static readonly IDictionary<string, string> _codons = new Dictionary<string, string>
        {
            {"UUU", "F"   }, {"CUU", "L"}, {"AUU", "I"}, {"GUU", "V"},
            {"UUC", "F"   }, {"CUC", "L"}, {"AUC", "I"}, {"GUC", "V"},
            {"UUA", "L"   }, {"CUA", "L"}, {"AUA", "I"}, {"GUA", "V"},
            {"UUG", "L"   }, {"CUG", "L"}, {"AUG", "M"}, {"GUG", "V"},
            {"UCU", "S"   }, {"CCU", "P"}, {"ACU", "T"}, {"GCU", "A"},
            {"UCC", "S"   }, {"CCC", "P"}, {"ACC", "T"}, {"GCC", "A"},
            {"UCA", "S"   }, {"CCA", "P"}, {"ACA", "T"}, {"GCA", "A"},
            {"UCG", "S"   }, {"CCG", "P"}, {"ACG", "T"}, {"GCG", "A"},
            {"UAU", "Y"   }, {"CAU", "H"}, {"AAU", "N"}, {"GAU", "D"},
            {"UAC", "Y"   }, {"CAC", "H"}, {"AAC", "N"}, {"GAC", "D"},
            {"UAA", "Stop"}, {"CAA", "Q"}, {"AAA", "K"}, {"GAA", "E"},
            {"UAG", "Stop"}, {"CAG", "Q"}, {"AAG", "K"}, {"GAG", "E"},
            {"UGU", "C"   }, {"CGU", "R"}, {"AGU", "S"}, {"GGU", "G"},
            {"UGC", "C"   }, {"CGC", "R"}, {"AGC", "S"}, {"GGC", "G"},
            {"UGA", "Stop"}, {"CGA", "R"}, {"AGA", "R"}, {"GGA", "G"},
            {"UGG", "W"   }, {"CGG", "R"}, {"AGG", "R"}, {"GGG", "G"}
        };

        public static string ConvertCodon(this string codon)
        {
            return _codons[codon];
        }

        public static int NumberOfProteinSources(this char c)
        {
            int result = _codons.Values.Count(v => v.Equals("Stop") == false && v[0] == c);
            return result == 0 ? 1 : result;
        }

        public static int NumberOfStops()
        {
            return _codons.Values.Count(v => v.Equals("Stop"));
        }
    }
}
