using System.Collections.Generic;

namespace Rosalind.Converters
{
    public static class FASTAToDictionary
    {
        public static Dictionary<string, string> Convert(List<string> input)
        {
            input.Add(">");
            var dnaStrings = new Dictionary<string, string>();

            string id = "";
            string dnaString = "";

            foreach (string s in input)
            {
                if (s.StartsWith(">"))
                {
                    if (string.IsNullOrEmpty(dnaString) == false)
                    {
                        dnaStrings.Add(id, dnaString);
                        dnaString = "";
                    }
                    id = s.Substring(1);
                }
                else
                {
                    dnaString += s;
                }
            }

            return dnaStrings;
        }
    }
}
