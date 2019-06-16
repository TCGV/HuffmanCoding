namespace Tcgv.HuffmanCoding
{
    public class HuffmanTreeNode
    {
        public HuffmanTreeNode(char symbol, int freq)
        {
            this.Symbol = symbol;
            this.Frequency = freq;
        }

        public HuffmanTreeNode(HuffmanTreeNode l, HuffmanTreeNode r)
        {
            this.Left = l;
            this.Right = r;
            this.Frequency = l.Frequency + r.Frequency;
        }

        public char Symbol { get; private set; }

        public int Frequency { get; private set; }

        public HuffmanTreeNode Left { get; private set; }

        public HuffmanTreeNode Right { get; private set; }

        internal bool IsLeaf()
        {
            return this.Left == null && this.Right == null;
        }
    }
}