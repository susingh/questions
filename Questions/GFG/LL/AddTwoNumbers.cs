using Questions.IK.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class AddTwoNumbers
    {
        public static LinkedListNode Sum(LinkedListNode list1, LinkedListNode list2)
        {
            var a = GetNumber(list1);
            var b = GetNumber(list2);
            return BuildList(a + b);
        }
    
        private static int GetNumber(LinkedListNode node)
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

        private static LinkedListNode BuildList(int num)
        {
            Stack<int> stack = new Stack<int>();
            while (num > 0)
            {
                int digit = num % 10;
                stack.Push(digit);
                num = num / 10;
            }

            LinkedListNode head = new LinkedListNode();
            LinkedListNode curr = head;

            while (stack.Count > 0)
            {
                int digit = stack.Pop();
                curr.next = new LinkedListNode()
                {
                    val = digit
                };

                curr = curr.next;
            }

            return head.next;
        }
    }
}
