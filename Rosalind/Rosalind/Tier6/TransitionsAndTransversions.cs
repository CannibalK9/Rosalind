using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class TransitionsAndTransversions
    {
        //http://rosalind.info/problems/tran/

        public TransitionsAndTransversions()
        {
            string [] dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToArray();
            double transitions = 0;
            double transversions = 0;

            for (int i = 0; i < dnaStrings[0].Length; i++)
            {
                char a = dnaStrings[0][i];
                char b = dnaStrings[1][i];

                if (_transitions.ContainsKey(a) && _transitions[a] == b)
                    transitions++;
                else if (a != b)
                    transversions++;
            }

            Console.WriteLine(transitions / transversions);
        }

        private Dictionary<char, char> _transitions = new Dictionary<char, char> { { 'A', 'G' }, { 'G', 'A' }, { 'C', 'T' }, { 'T', 'C' } };
    }
}
