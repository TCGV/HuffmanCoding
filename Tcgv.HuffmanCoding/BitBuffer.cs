using System.Collections.Generic;

namespace Tcgv.HuffmanCoding
{
    public class BitBuffer
    {
        public BitBuffer(int capacity)
        {
            this.Length = 0;
            this.bytes = new List<byte>(capacity);
        }

        public int Length { get; private set; }

        public static int Read(byte[] data, int index)
        {
            return (data[index / bits_in_byte] & (1 << (index % bits_in_byte))) == 0 ? 0 : 1;
        }

        public void Insert(uint code, int codeLen)
        {
            while (bytes.Count * bits_in_byte - Length < codeLen)
                bytes.Add(0);

            for (var i = 0; i < codeLen; i++)
            {
                var bit = (code & (1 << codeLen - 1 - i)) == 0 ? 0 : 1;
                bytes[(Length + i) / bits_in_byte] |= (byte)(bit << ((Length + i) % bits_in_byte));
            }

            this.Length += codeLen;
        }

        public byte[] ToByteArray()
        {
            return bytes.ToArray();
        }

        private readonly static int bits_in_byte = 8;

        private List<byte> bytes;
    }
}