using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Tier4
{
    public class MendelsFirstLaw
    {
        //http://rosalind.info/problems/iprb/

        public MendelsFirstLaw(float dominant, float hetero, float recessive)
        {
            float total = dominant + hetero + recessive;
            float second = total - 1;

            float result =
                (dominant / total) +
                (hetero / (total * 2f)) +
                (hetero / (total * 2f)) * ((hetero - 1) / (second * 2f)) +
                (((hetero / 2) + recessive) / total) * (dominant / second) +
                (recessive / total) * ((hetero) / (second * 2f));

            Console.WriteLine(result);

        }
    }
}
