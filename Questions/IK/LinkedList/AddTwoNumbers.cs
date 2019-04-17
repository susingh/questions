using Questions.Models;
using System;

namespace Questions.IK.LinkedList
{
    public class AddTwoNumbers
    {
        public static ListNode AddTwoNumbersMain(ListNode l1, ListNode l2)
        {
            // find the length of each list
            ListNode c1 = l1;
            ListNode c2 = l2;

            while (c1 != null && c2 != null)
            {
                c1 = c1.next;
                c2 = c2.next;
            }

            ListNode longL = c1 == null ? l2 : l1;
            ListNode shortL = c1 == null ? l1 : l2;

            int diff = 0;
            if (c1 == null)
            {
                while (c2 != null)
                {
                    diff++;
                    c2 = c2.next;
                }
            }
            else
            {
                while (c1 != null)
                {
                    diff++;
                    c1 = c1.next;
                }
            }

            
            ListNode curr = longL;

            while (diff > 0 && curr != null)
            {
                curr = curr.next;
                diff--;
            }

            ListNode head = new ListNode(0);
            var tuple = Add(curr, shortL);
            head.next = tuple.Item1;
            head.val = head.val + tuple.Item2;

            return head;
        }

        private static Tuple<ListNode,int> Add(ListNode l1, ListNode l2)
        {
            if (l1.next == null && l2.next == null)
            {
                int sum = l1.val + l2.val;
                int overFlow = sum >= 10 ? 1: 0;
                return Tuple.Create(new ListNode(sum % 10), overFlow);
            }

            var tuple = Add(l1.next, l2.next);
            int sumOuter = l1.val + l2.val + tuple.Item2;
            int overFlowOuter = sumOuter >= 10 ? 1 : 0;

            ListNode newNode = new ListNode(sumOuter % 10);
            newNode.next = tuple.Item1;

            return Tuple.Create(newNode, overFlowOuter);
        }
    }
}