using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.LL
{
    class StackNode
    {
        public int val;
        public StackNode next;
    }

    class Stack
    {
        StackNode head = null;

        int Pop()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            StackNode curr = head;
            head = curr.next;
            return curr.val;
        }

        void Push (int val)
        {
            var node = new StackNode() { val = val, next = null };

            if (head == null)
            {
                head = node;
            }
            else
            {
                node.next = head;
                head = node;
            }
        }

        bool IsEmpty()
        {
            return head == null;
        }

        int Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.val;
        }
    }
}
