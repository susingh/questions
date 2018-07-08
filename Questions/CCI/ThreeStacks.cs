using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI
{
    public class MultiStacks : IQuestion
    {
        private class Node
        {
            public int value;
            public int? nextValue;
        }

        Node[] nodes = null;
        int?[] top = null;
        int globalIndex = 0;
        int[] sizes = null;
        public MultiStacks(int stackCount)
        {
            nodes = new Node[stackCount * 2];
            top = new int?[stackCount];
            sizes = new int[stackCount];
        }

        int Pop(int stackIndex)
        {
            int? topIndex = top[stackIndex];
            if (!topIndex.HasValue)
            {
                throw new Exception();
            }

            Node node = nodes[topIndex.Value];
            nodes[topIndex.Value] = null;
            topIndex = node.nextValue;
            top[stackIndex] = topIndex;
            sizes[stackIndex]--;
            
            return node.value;
        }

        void Push(int stackIndex, int value)
        {
            int? topIndex = top[stackIndex];
            
            Node newNode = new Node
            {
                value = value
            };

            nodes[globalIndex] = newNode;

            if (topIndex.HasValue)
            {
                newNode.nextValue = topIndex;
            }
            
            topIndex = globalIndex;
            top[stackIndex] = topIndex;
            sizes[stackIndex]++;
            globalIndex++;

            ResizeIfNeeded();
        }

        bool IsEmpty(int stackIndex)
        {
            int? topIndex = top[stackIndex];
            return !topIndex.HasValue;
        }

        int Peek(int stackIndex)
        {
            int? topIndex = top[stackIndex];
            if (!topIndex.HasValue)
            {
                throw new Exception();
            }

            return nodes[topIndex.Value].value;
        }

        private void ResizeIfNeeded()
        {
            int sumOfSizes = 0;
            foreach (var size in sizes)
            {
                sumOfSizes += size;
            }

            if (sumOfSizes > nodes.Length * 3 / 4)
            {
                Expand();
            }
            else
            {
                Shrink();
            }
        }

        private void Shrink()
        {

        }

        private void Expand()
        {

        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
