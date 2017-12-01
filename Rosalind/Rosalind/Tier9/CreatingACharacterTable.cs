using Rosalind.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Tier9
{
    public class CreatingACharacterTable
    {
        //http://rosalind.info/problems/ctbl/

        public CreatingACharacterTable()
        {
            var tree = new NewickTree(File.ReadAllLines(@"C:\code\dataset.txt")[0]);
            var lexList = new List<string>(tree.Nodes.Where(n => n.HasName).Select(n => n.Name));
            lexList.Sort();

            CharacterTable.WriteCharacterTable(tree.Nodes, lexList);
        }
    }
}
