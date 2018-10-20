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
}
