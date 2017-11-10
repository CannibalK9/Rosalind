using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier7
{
    public class FindingASharedSplicedMotifAlternative2
    {
        //http://rosalind.info/problems/lcsq/

        public FindingASharedSplicedMotifAlternative2()
        {
            List<string> dnaStrings = FASTAToDictionary.Convert(File.ReadAllLines(@"C:\code\dataset.txt").ToList()).Values.ToList();
            blu(dnaStrings[0], dnaStrings[1], "ACGT");
            blu(dnaStrings[0], dnaStrings[1], "ACTG");
            blu(dnaStrings[0], dnaStrings[1], "AGCT");
            blu(dnaStrings[0], dnaStrings[1], "AGTC");
            blu(dnaStrings[0], dnaStrings[1], "ATGC");
            blu(dnaStrings[0], dnaStrings[1], "ATCG");
            blu(dnaStrings[0], dnaStrings[1], "CAGT");
            blu(dnaStrings[0], dnaStrings[1], "CATG");
            blu(dnaStrings[0], dnaStrings[1], "CGAT");
            blu(dnaStrings[0], dnaStrings[1], "CGTA");
            blu(dnaStrings[0], dnaStrings[1], "CTAG");
            blu(dnaStrings[0], dnaStrings[1], "CTGA");
            blu(dnaStrings[0], dnaStrings[1], "GCAT");
            blu(dnaStrings[0], dnaStrings[1], "GCTA");
            blu(dnaStrings[0], dnaStrings[1], "GACT");
            blu(dnaStrings[0], dnaStrings[1], "GATC");
            blu(dnaStrings[0], dnaStrings[1], "GTCA");
            blu(dnaStrings[0], dnaStrings[1], "GTAC");
            blu(dnaStrings[0], dnaStrings[1], "TCGA");
            blu(dnaStrings[0], dnaStrings[1], "TCAG");
            blu(dnaStrings[0], dnaStrings[1], "TAGC");
            blu(dnaStrings[0], dnaStrings[1], "TACG");
            blu(dnaStrings[0], dnaStrings[1], "TGAC");
            blu(dnaStrings[0], dnaStrings[1], "TGCA");
        }

        public void blu(string s1, string s2, string n)
        {
            List<char> sequence = new List<char>();

            int s1Count = s1.Count(c => c == n[0]);
            int s2Count = s2.Count(c => c == n[0]);

            for (int i = 0; i < (s1Count < s2Count ? s1Count : s2Count); i++)
            {
                sequence.Add(n[0]);
            }

            AddCharsInOrder(s1, s2, sequence, n);

            string result = string.Join("", sequence);

            if (_result.Length < result.Length)
            {
                _result = result;
                Console.WriteLine(n + ":");
                Console.WriteLine(_result);
            }
        }

        private void AddCharsInOrder(string s1, string s2, List<char> sequence, string order)
        {
            AddChar(s1, s2, sequence, order[1]);
            AddChar(s1, s2, sequence, order[2]);
            AddChar(s1, s2, sequence, order[3]);
        }

        private void AddChar(string s1, string s2, List<char> sequence, char n)
        {
            int num = 0;
            IEnumerator<int> s1Chars = CharsToAdd(s1, string.Join("",sequence), n).GetEnumerator();
            IEnumerator<int> s2Chars = CharsToAdd(s2, string.Join("", sequence), n).GetEnumerator();

            while (num < sequence.Count)
            {
                s1Chars.MoveNext();
                s2Chars.MoveNext();
                int charsToAdd = s1Chars.Current < s2Chars.Current ? s1Chars.Current : s2Chars.Current;

                List<char> chars = new List<char>();

                for (int i = 0; i < charsToAdd; i++)
                {
                    chars.Add(n);
                }

                sequence.InsertRange(num, chars);
                num += charsToAdd + 1;
            }
        }

        private IEnumerable<int> CharsToAdd(string s, string sequence, char n)
        {
            int count = 0;

            using (var reader = new StringReader(sequence))
            {
                char currentChar = Convert.ToChar(reader.Read());

                foreach (char c in s)
                {
                    if (c == n)
                    {
                        count++;
                    }
                    else if (c == currentChar)
                    {
                        int thisCount = count;
                        count = 0;
                        bool noEnd = Char.TryParse(reader.Read().ToString(), out currentChar);
                        if (noEnd)
                            yield return thisCount;
                        else
                            yield break;
                    }
                }
            }
        }

        private string _result = "";
        private int _index;
        private Random rand = new Random();

        public void dod(List<char> s1, List<char> s2, int index, int aNumber)
        {
            int removed = 1;

            try
            {
                switch (aNumber)
                {
                    case 1:
                        s1.RemoveRange(0, index);
                        break;
                    case 2:
                        s2.RemoveRange(0, index);
                        break;
                    case 3:
                        s1.RemoveRange(0, index);
                        s2.RemoveRange(0, index);
                        break;
                }
            }
            catch
            {
                return;
            }
            while (removed > 0 && s1.Count > _result.Length && s2.Count > _result.Length)
            {
                removed = 0;

                for (int i = 0; i < (s1.Count < s2.Count ? s1.Count : s2.Count); i++)
                {
                    int s1Remove = 0;
                    int s2remove = 0;

                    if (s1[i] == s2[i])
                        continue;

                    while (s2.Count > i + s2remove && s1[i] != s2[i + s2remove])
                    {
                        s2remove++;
                    }

                    while (s1.Count > i + s1Remove && s2[i] != s1[i + s1Remove])
                    {
                        s1Remove++;
                    }

                    if (s2remove < s1Remove)
                    {
                        s2.RemoveRange(i, s2remove);
                        removed = s2remove;
                    }
                    else
                    {
                        s1.RemoveRange(i, s1Remove);
                        removed = s1Remove;
                    }

                    //switch(rand.Next(2))
                    //{
                    //    case 0:
                    //        s2.RemoveRange(i, s2remove);
                    //        removed = s2remove;
                    //        break;
                    //    case 1:
                    //        s1.RemoveRange(i, s1Remove);
                    //        removed = s1Remove;
                    //        break;
                    //}
                    break;
                }
            }

            string result = string.Join("", s1.Count < s2.Count ? s1.ToArray() : s2.ToArray());
            if (result.Length > _result.Length)
            {
                _result = result;
                _index = index;

                Console.WriteLine(_index + "(" + _result.Length + ")" + ": ");
                Console.WriteLine(_result);

            }
        }
    }
}
