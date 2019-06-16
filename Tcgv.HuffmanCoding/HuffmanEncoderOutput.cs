namespace Tcgv.HuffmanCoding
{
    public class HuffmanEncoderOutput
    {
        public HuffmanEncoderOutput(HuffmanTree tree, BitBuffer buffer)
        {
            this.Tree = tree;
            this.Data = buffer.ToByteArray();
            this.Length = buffer.Length;
        }

        public HuffmanTree Tree { get; private set; }
        
        public byte[] Data { get; private set; }
        
        public int Length { get; private set; }
    }
}