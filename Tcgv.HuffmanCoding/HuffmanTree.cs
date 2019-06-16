using System.Collections.Generic;
using System.Linq;

namespace Tcgv.HuffmanCoding
{
    public class HuffmanTree
    {
        public HuffmanTree(Dictionary<char, int> freq)
        {
            var heap = new Heap<HuffmanTreeNode>(
                freq.Select(p => new HuffmanTreeNode(p.Key, p.Value)),
                (a, b) => a.Frequency.CompareTo(b.Frequency)
            );
            
            while (heap.Count > 1)
            {
                var left = heap.Root;
                heap.Pop();

                var right = heap.Root;
                var pos = heap.Pop();

                heap.Push(new HuffmanTreeNode(left, right), pos);
            }

            this.Root = heap.Root;
        }

        public HuffmanTreeNode Root { get; private set; }

        public Dictionary<char, HuffmanCode> GetTable()
        {
            var dict = new Dictionary<char, HuffmanCode>();
            GetTable(this.Root, dict, 0, 0);
            return dict;
        }

        private void GetTable(HuffmanTreeNode node, Dictionary<char, HuffmanCode> dict, uint code, int len)
        {
            if (node.IsLeaf())
            {
                dict.Add(node.Symbol, new HuffmanCode(code, len));
            }
            else
            {
                if (node.Left != null)
                    GetTable(node.Left, dict, code << 1, len + 1);
                if (node.Right != null)
                    GetTable(node.Right, dict, (code << 1) + 1, len + 1);
            }
        }
    }
}
