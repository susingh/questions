using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.StacksQueues
{
    class Queue
    {
        private StackNode head;
        private StackNode tail;

        int Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            StackNode curr = head;
            
            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = curr.next;
            }

            return curr.val;
        }

        void Enqueue(int val)
        {
            var node = new StackNode() { val = val };
            if (tail == null)
            {
                head = tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
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
