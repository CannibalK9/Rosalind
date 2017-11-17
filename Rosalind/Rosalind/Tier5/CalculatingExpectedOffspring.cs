using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Tier5
{
    public class CalculatingExpectedOffspring
    {
        //http://rosalind.info/problems/iev/

        public CalculatingExpectedOffspring()
        {
            IEnumerable<int> values = Console.ReadLine().Split(' ').ToList().Select(s => Convert.ToInt32(s));
            IEnumerator<float> prob = new List<float> { 1, 1, 1, 0.75f, 0.5f, 0 }.GetEnumerator();

            float count = 0;

            foreach (int value in values)
            {
                prob.MoveNext();
                count += value * 2 * prob.Current;
            }

            Console.WriteLine(count);
        }
    }
}
