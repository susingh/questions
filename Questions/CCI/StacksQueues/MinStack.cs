using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.StacksQueues
{
    class MinStack
    {
        private class StackNode
        {
            public int value;
            public int myMin;
        }

        private Stack<StackNode> stack = new Stack<StackNode>();
        private int _currentMin = int.MaxValue;

        public void Push(int val)
        {
            _currentMin = Math.Min(_currentMin, val);
            var node = new StackNode { value = val, myMin = _currentMin };
            stack.Push(node);
        }

        public int Pop()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var node = stack.Pop();
            if (node.value == _currentMin)
            {
                _currentMin = node.myMin;
            }

            return node.value;
        }

        public int Min()
        {
            return _currentMin;
        }

    }

    class Minstack2
    {
        private class MinNode
        {
            public int minValue;
            public int count;
        }

        Stack<int> stack = new Stack<int>();
        Stack<MinNode> minStack = new Stack<MinNode>();

        void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0)
            {
                minStack.Push(new MinNode() { minValue = val, count = 1 });
            }
            else
            {
                var curr = minStack.Peek();
                if (val == curr.minValue)
                {
                    curr.count++;
                }
                else if (val < curr.minValue)
                {
                    minStack.Push(new MinNode() { minValue = val, count = 1 });
                }
            }
        }

        int Pop()
        {
            int val = stack.Pop();
            var minValue = minStack.Peek();
            if (minValue.minValue == val)
            {
                if (minValue.count == 1)
                {
                    minStack.Pop();
                }
                else
                {
                    minValue.count--;
                }
            }

            return val;
        }

        int Min()
        {
            return minStack.Peek().minValue;
        }

    }
}
