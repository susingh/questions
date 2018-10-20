using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class SwapKthNode
    {
        public static LinkedListNode swap_nodes(LinkedListNode head, int k)
        {
            if (head == null || k <= 0)
            {
                return head;
            }

            LinkedListNode curr = head;
            LinkedListNode prev1 = null;
            int counter = 1;

            while (curr != null && ++counter <= k)
            {
                prev1 = curr;
                curr = curr.next;
            }

            LinkedListNode a = curr;

            LinkedListNode b = head;
            LinkedListNode prev2 = null;

            while (curr != null && curr.next != null)
            {
                prev2 = b;
                b = b.next;
                curr = curr.next;
            }

            if (a == b)
            {
                return head;
            }

            if (prev1 == null)
            {
                head = b;
            }
            else
            {
                prev1.next = b;
            }

            if (prev2 == null)
            {
                head = a;
            }
            else
            {
                prev2.next = a;
            }

            LinkedListNode temp = a.next;
            a.next = b.next;
            b.next = temp;

            return head;
        }

    }
}
