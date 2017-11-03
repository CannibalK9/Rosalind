using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind
{
    public class EnumeratingGeneOrders
    {
        //http://rosalind.info/problems/perm/

        public List<List<int>> Output = new List<List<int>>();

        public EnumeratingGeneOrders(int input)
        {
            var list = new List<int>();
            for (int i = 1; i <= input; i++)
            {
                list.Add(i);
            }
            Solve(list, new List<int>());

            File.AppendAllText(@"C:\code\result.txt", Output.Count.ToString() + Environment.NewLine);

            foreach (var item in Output)
            {
                File.AppendAllText(@"C:\code\result.txt", string.Join(" ", item) + Environment.NewLine);
            }
        }

        private void Solve(List<int> input, List<int> output)
        {
            foreach (int i in input)
            {
                var newList = new List<int>(input);
                newList.Remove(i);

                Solve(newList, AddInt(output, i));
                Solve(newList, AddInt(output, -i)); //uncomment for Enumerating Oriented gene Orderings: http://rosalind.info/problems/sign/
            }

            if (input.Any() == false)
                Output.Add(output);
        }

        private List<int> AddInt(List<int> list, int i)
        {
            var newList = new List<int>(list);
            newList.Add(i);
            return newList;
        }
    }
}
