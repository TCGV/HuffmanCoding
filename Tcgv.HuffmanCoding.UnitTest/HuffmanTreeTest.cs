using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tcgv.HuffmanCoding.UnitTest
{
    [TestClass]
    public class HuffmanTreeTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            freq = new Dictionary<char, int>();
            freq.Add('a', 5);
            freq.Add('b', 9);
            freq.Add('c', 12);
            freq.Add('d', 13);
            freq.Add('e', 16);
            freq.Add('f', 45);
        }

        [TestMethod]
        public void BuildTreeFromCharFrequenciesTest()
        {
            var tree = new HuffmanTree(freq);

            Assert.AreEqual(100, tree.Root.Frequency);
            Assert.AreEqual('f', tree.Root.Left.Symbol);
            Assert.AreEqual(45, tree.Root.Left.Frequency);
            Assert.AreEqual(55, tree.Root.Right.Frequency);
            Assert.AreEqual(25, tree.Root.Right.Left.Frequency);
            Assert.AreEqual(30, tree.Root.Right.Right.Frequency);
            Assert.AreEqual('c', tree.Root.Right.Left.Left.Symbol);
            Assert.AreEqual(12, tree.Root.Right.Left.Left.Frequency);
            Assert.AreEqual('d', tree.Root.Right.Left.Right.Symbol);
            Assert.AreEqual(13, tree.Root.Right.Left.Right.Frequency);
            Assert.AreEqual(14, tree.Root.Right.Right.Left.Frequency);
            Assert.AreEqual('e', tree.Root.Right.Right.Right.Symbol);
            Assert.AreEqual(16, tree.Root.Right.Right.Right.Frequency);
            Assert.AreEqual('a', tree.Root.Right.Right.Left.Left.Symbol);
            Assert.AreEqual(5, tree.Root.Right.Right.Left.Left.Frequency);
            Assert.AreEqual('b', tree.Root.Right.Right.Left.Right.Symbol);
            Assert.AreEqual(9, tree.Root.Right.Right.Left.Right.Frequency);
        }

        [TestMethod]
        public void ConvertTreeToDicitonaryTest()
        {
            var tree = new HuffmanTree(freq);
            var dict = tree.GetTable();

            Assert.AreEqual(dict['a'].Code, (uint)12);
            Assert.AreEqual(dict['b'].Code, (uint)13);
            Assert.AreEqual(dict['c'].Code, (uint)4);
            Assert.AreEqual(dict['d'].Code, (uint)5);
            Assert.AreEqual(dict['e'].Code, (uint)7);
            Assert.AreEqual(dict['f'].Code, (uint)0);
        }

        private Dictionary<char, int> freq;
    }
}
