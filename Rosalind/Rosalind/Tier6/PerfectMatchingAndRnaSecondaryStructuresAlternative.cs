using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier6
{
    public class PerfectMatchingAndRnaSecondaryStructuresAlternative
    {
        //http://rosalind.info/problems/pmch/

        public PerfectMatchingAndRnaSecondaryStructuresAlternative()
        {
            string input = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).First().Value;

            _perfectLength = input.Length / 2;

            List<List<int>> validConnections = ValidConnections(input);
            List<List<int>> perfectMatchings = new List<List<int>>();
            //PerfectMatchings(validConnections, new List<int>(), 0);
            UInt64 G = (ulong)input.Count(c => c == 'G');
            UInt64 A = (ulong)input.Count(c => c == 'A');
            ulong d = 121645100408832;
            ulong e = 20922789888;

            ulong f = e * d;

            Console.WriteLine( );


            //UInt64 Fg = Factorial(G);
            //UInt64 Fa = Factorial(A);
            //UInt64 result = Fg * Fa;
            //Console.WriteLine(result);
            ////Console.WriteLine(_count);
        }

        static UInt64 Factorial(UInt64 n)
        {
            if (n >= 2) return n * Factorial(n - 1);
            return 1;
        }

        private Dictionary<char, char> _validConnections = new Dictionary<char, char> { { 'U', 'A' }, { 'A', 'U' }, { 'C', 'G' }, { 'G', 'C' } };
        private int _perfectLength;

        private List<List<int>> ValidConnections(string input)
        {
            var validConnectionsList = new List<List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                var validConnectionList = new List<int>();

                for (int j = i + 1; j < input.Length; j++)
                {
                    char c2 = input[j];

                    if (_validConnections[c] == c2)
                        validConnectionList.Add(j);
                }
                validConnectionsList.Add(validConnectionList);
            }

            return validConnectionsList;
        }

        private void PerfectMatchings(List<List<int>> perfectMatchings, List<List<int>> validConnections, List<int> current, int column)
        {
            if (validConnections[column].Contains(column))
            {
                PerfectMatchings(perfectMatchings, validConnections, current, column + 1);
                return;
            }

            for (int j = 0; j < validConnections[column].Count; j++)
            {
                int validConnection = validConnections[column][j];
                if (current.Contains(validConnection) == false)
                {
                    var next = new List<int>(current) { validConnection };
                    if (next.Count == _perfectLength)
                    {
                        _count++;
                        perfectMatchings.Add(next);
                        return;
                    }
                    PerfectMatchings(perfectMatchings, validConnections, next, column + 1);
                }
            }
        }
        private void PerfectMatchings(List<List<int>> validConnections, List<int> current, int column)
        {
            if (current.Contains(column))
            {
                PerfectMatchings(validConnections, current, column + 1);
                return;
            }
            for (int j = 0; j < validConnections[column].Count; j++)
            {
                int validConnection = validConnections[column][j];
                if (current.Contains(validConnection) == false)
                {
                    var next = new List<int>(current) { validConnection };
                    if (next.Count == _perfectLength)
                    {
                        _count++;
                        return;
                    }
                    PerfectMatchings(validConnections, next, column + 1);
                }
            }
        }

        private int PerfectMatchings(List<List<int>> validConnections, Dictionary<KeyValuePair<int, int>, int> cache, List<int> current, int column)
        {
            int count = 0;

            if (validConnections[column].Contains(column))
            {
                return PerfectMatchings(validConnections, cache, current, column + 1);
            }
            for (int j = 0; j < validConnections[column].Count; j++)
            {
                var kvp = new KeyValuePair<int, int>(column, j);
                if (cache.ContainsKey(kvp))
                    return cache[kvp];

                int validConnection = validConnections[column][j];
                if (current.Contains(validConnection) == false)
                {
                    var next = new List<int>(current) { validConnection };
                    if (next.Count == _perfectLength)
                    {
                        return 1;
                    }
                    count += PerfectMatchings(validConnections, cache, next, column + 1);
                    cache.Add(kvp, count);
                }
            }

            return count;
        }

        private int _count = 0;

        
    }
}
