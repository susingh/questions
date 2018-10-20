using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class MinStackNode
    {
        public int val;
        public int minVal;
        public MinStackNode next;
    }

    class MinStack
    {
        private MinStackNode head = null;
        private int currMin = int.MaxValue;

        public void Pop()
        {
            if (head == null)
            {
                return;
            }

            head = head.next;
        }

        public int Min()
        {
            if (head == null)
            {
                return -1;
            }

            return head.minVal;
        }

        public void Push(int val)
        {
            currMin = Math.Min(currMin, val);
            MinStackNode node = new MinStackNode() { val = val, minVal = currMin, next = head };
            head = node;
        }

        public static int[] min_stack(int[] operations)
        {
            MinStack stack = new MinStack();
            List<int> result = new List<int>();

            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == -1)
                {
                    stack.Pop();
                }
                else if (operations[i] == 0)
                {
                    result.Add(stack.Min());
                }
                else
                {
                    stack.Push(operations[i]);
                }
            }

            return result.ToArray();
        }
    }
}
