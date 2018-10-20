using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.StacksQueues
{
    class StackOfPlates
    {
        List<Stack<int>> stacks = new List<Stack<int>>();
        private int _maxCapacity;
        private int _index = 0;

        public StackOfPlates(int capacity)
        {
            _maxCapacity = capacity;
        }

        public void Push(int value)
        {
            if (stacks[_index].Count == _maxCapacity)
            {
                stacks.Add(new Stack<int>());
                _index++;
            }

            stacks[_index].Push(value);
        }

        public int Pop()
        {
            if (stacks[_index].Count == 0)
            {
                throw new InvalidOperationException();
            }

            int value = stacks[_index].Pop();

            if (stacks[_index].Count == 0)
            {
                stacks.RemoveAt(_index);
                _index--;
            }

            return value;
        }

        public bool IsEmpty()
        {
            return stacks[_index].Count == 0;
        }

        public int Peek()
        {
            return stacks[_index].Peek();
        }

        public int PopAt(int index)
        {
            if (_index < index)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (stacks[index].Count == 0)
            {
                throw new InvalidOperationException();
            }

            int val = stacks[index].Pop();

            if (stacks[index].Count == 0)
            {
                stacks.RemoveAt(index);
                _index--;
            }

            return val;
        }
    }
}
