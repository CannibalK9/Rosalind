using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rosalind.Converters
{
    public class NewickTree
    {
        public List<NewickNode> Nodes = new List<NewickNode>();

        public NewickTree(string tree)
        {
            AddNodes(new List<string> { tree.Substring(0, tree.Length - 1) }, -1);
        }

        private void SplitNodes(string rootNode, int nodeValue)
        {
            var children = new List<string>();

            int bracketdepth = 0;
            var sb = new StringBuilder();

            using (var sr = new StringReader(rootNode))
            {
                int i = sr.Read();
                while (i >= 0)
                {
                    char c = Convert.ToChar(i);

                    if (bracketdepth == 0 && c == ',')
                    {
                        children.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                    else
                    {
                        if (c == '(')
                            bracketdepth++;
                        else if (c == ')')
                            bracketdepth--;

                        sb.Append(c);
                    }
                    i = sr.Read();
                }
            }
            children.Add(sb.ToString());
            AddNodes(children, nodeValue);
        }

        private void AddNodes(List<string> neighbours, int parentValue)
        {
            foreach (string neighbour in neighbours)
            {
                int nodeValue = Nodes.Count;
                bool isLeaf = neighbour.Contains(')') == false;
                string name = isLeaf ? neighbour : neighbour.Substring(neighbour.LastIndexOf(')') + 1);
                Nodes.Add(new NewickNode(nodeValue, parentValue, name, isLeaf));
                if (isLeaf == false)
                    SplitNodes(neighbour.Substring(1, neighbour.Length - (2 + name.Length)), nodeValue);
            }
        }
    }

    public struct NewickNode
    {
        public int Value;
        public int ParentValue;
        public string Name;
        public bool HasName;
        public bool IsLeaf;

        public NewickNode(int value, int parentValue, string name, bool isLeaf)
        {
            Value = value;
            ParentValue = parentValue;
            Name = name;
            HasName = string.IsNullOrEmpty(name) == false;
            IsLeaf = isLeaf;
        }
    }
}
