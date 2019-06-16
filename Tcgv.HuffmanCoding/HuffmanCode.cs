namespace Tcgv.HuffmanCoding
{
    public class HuffmanCode
    {
        public HuffmanCode(uint code, int len)
        {
            this.Code = code;
            this.BitLength = len;
        }

        public uint Code { get; private set; }

        public int BitLength { get; private set; }
    }
}