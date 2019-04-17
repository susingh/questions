using Questions.IK.LinkedList;
using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class AddTwoNumbers
    {
        public static ListNode Sum(ListNode list1, ListNode list2)
        {
            var a = GetNumber(list1);
            var b = GetNumber(list2);
            return BuildList(a + b);
        }
    
        private static int GetNumber(ListNode node)
        {
            var curr = node;
            int result = 0;

            while (curr != null)
            {
                result = curr.val + (result * 10);
                curr = curr.next;
            }

            return result;
        }

        private static ListNode BuildList(int num)
        {
            Stack<int> stack = new Stack<int>();
            while (num > 0)
            {
                int digit = num % 10;
                stack.Push(digit);
                num = num / 10;
            }

            ListNode head = new ListNode();
            ListNode curr = head;

            while (stack.Count > 0)
            {
                int digit = stack.Pop();
                curr.next = new ListNode()
                {
                    val = digit
                };

                curr = curr.next;
            }

            return head.next;
        }
    }
}
