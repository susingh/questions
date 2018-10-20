using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.StacksQueues
{
    class SortStack
    {
        public static Stack Sort(Stack input)
        {
            Stack sortedStack = new Stack();

            while(!input.IsEmpty())
            {
                var newValue = input.Pop();

                while (!sortedStack.IsEmpty() && sortedStack.Peek() < newValue)
                {
                    input.Push(sortedStack.Pop());
                }

                sortedStack.Push(newValue);
            }

            return sortedStack;
        }
    }
}
