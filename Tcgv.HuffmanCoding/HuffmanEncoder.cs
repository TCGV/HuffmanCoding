using System.Collections.Generic;
using System.Text;

namespace Tcgv.HuffmanCoding
{
    public class HuffmanEncoder
    {
        public HuffmanEncoderOutput Encode(string text)
        {
            var freq = GetFrequencies(text);
            var tree = new HuffmanTree(freq);
            var table = tree.GetTable();
            return new HuffmanEncoderOutput(tree, Encode(text, table));
        }

        public string Decode(HuffmanEncoderOutput output)
        {
            var sb = new StringBuilder();
            HuffmanTreeNode n = output.Tree.Root;

            for (var i = 0; i < output.Length; i++)
            {
                var bit = BitBuffer.Read(output.Data, i);
                
                if (bit == 0)
                    n = n.Left;
                else
                    n = n.Right;

                if (n.IsLeaf())
                {
                    sb.Append(n.Symbol);
                    n = output.Tree.Root;
                }
            }

            return sb.ToString();
        }

        private Dictionary<char, int> GetFrequencies(string text)
        {
            var freq = new  Dictionary<char, int>();
            
            foreach (char c in text)
            {
                if (!freq.ContainsKey(c))
                    freq.Add(c,0);
                freq[c]++;
            }

            return freq;
        }

        private BitBuffer Encode(string text, Dictionary<char, HuffmanCode> table)
        {
            var buff = new BitBuffer(text.Length);

            foreach (char c in text)
            {
                buff.Insert(table[c].Code, table[c].BitLength);
            }

            return buff;
        }
    }
}