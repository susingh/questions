using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class SwapKthNode
    {
        public static ListNode swap_nodes(ListNode head, int k)
        {
            if (head == null || k <= 0)
            {
                return head;
            }

            ListNode curr = head;
            ListNode prev1 = null;
            int counter = 1;

            while (curr != null && ++counter <= k)
            {
                prev1 = curr;
                curr = curr.next;
            }

            ListNode a = curr;

            ListNode b = head;
            ListNode prev2 = null;

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

            ListNode temp = a.next;
            a.next = b.next;
            b.next = temp;

            return head;
        }

    }
}
