using System;
using System.Collections.Generic;
using System.Linq;

namespace Tcgv.HuffmanCoding
{
    public class Heap<T> where T : class
    {
        public Heap(IEnumerable<T> items, Func<T, T, int> comparer)
        {
            this.nodes = items.ToArray();
            this.comparer = comparer;
            this.Count = nodes.Length;
            Heapfy(0);
        }

        public int Count { get; private set; }

        public T Root
        {
            get { return nodes[0]; }
        }

        public void Push(T node, int position)
        {
            if (nodes[position] != null)
                throw new ArgumentException();
            nodes[position] = node;
            this.Count++;
            SiftUp(position);
        }

        public int Pop()
        {
            return SiftDown(0);
        }

        private void Heapfy(int i)
        {
            if (i >= 0)
            {
                var l = GetLeftIndex(i);
                Heapfy(l);
                
                var r = GetRightIndex(i);
                Heapfy(r);

                Rotate(i, l, r);
            }
        }

        private void SiftUp(int i)
        {
            if (i > 0)
            {
                var p = GetParent(i);
                var l = GetLeftIndex(p);
                var r = GetRightIndex(p);

                Rotate(p, l, r);
                SiftUp(p);
            }
        }

        private int SiftDown(int position)
        {
            var l = GetLeftIndex(position);
            var r = GetRightIndex(position);

            if (l >= 0 && r >= 0 && comparer(nodes[l], nodes[r]) < 0 || l >= 0 && r < 0)
            {
                nodes[position] = nodes[l];
                return SiftDown(l);
            }
            else if (r >= 0 && l >= 0 && comparer(nodes[r], nodes[l]) <= 0 || r >= 0 && l < 0)
            {
                nodes[position] = nodes[r];
                return SiftDown(r);
            }
            else
            {
                nodes[position] = null;
                this.Count --;
                return position;
            }
        }

        private void Rotate(int i, int l, int r)
        {
            if (l >= 0 && comparer(nodes[l], nodes[i]) < 0)
                Swap(i, l);
            if (r >= 0 && comparer(nodes[r], nodes[i]) < 0)
                Swap(i, r);
        }

        private void Swap(int i1, int i2)
        {
            var aux = nodes[i1];
            nodes[i1] = nodes[i2];
            nodes[i2] = aux;
        }

        private int GetParent(int i)
        {
            return (i - 1) / 2;
        }

        private int GetLeftIndex(int i)
        {
            var l = i * 2 + 1;
            return l < nodes.Length && nodes[l] != null ? l : -1;
        }

        private int GetRightIndex(int i)
        {
            var r = i * 2 + 2;
            return r < nodes.Length && nodes[r] != null ? r : -1;
        }

        private T[] nodes;
        private Func<T, T, int> comparer;
    }
}