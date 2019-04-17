using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class AddTwoNumbers
    {
        public ListNode addTwoNumbers(ListNode a, ListNode b)
        {
            int num1 = 0, num2 = 0;
            int power = 0;

            ListNode curr = a;
            while (curr != null)
            {
                num1 += curr.val * (int)Math.Pow(10, power++);
                curr = curr.next;
            }

            power = 0;
            curr = b;
            while (curr != null)
            {
                num2 += curr.val * (int)Math.Pow(10, power++);
                curr = curr.next;
            }

            int sum = num1 + num2;

            ListNode result = new ListNode();
            curr = result;

            while (true)
            {
                int digit = sum % 10;
                curr.val = digit;

                sum = sum / 10;

                if (sum > 0)
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }
                else
                {
                    break;
                }
            }

            return null;
        }

        public void Run()
        {
            var num1 = new ListNode
            {
                val = 2,
                next = new ListNode
                {
                    val = 4,
                    next = new ListNode
                    {
                        val = 3
                    }
                }
            };

            var num2 = new ListNode
            {
                val = 5,
                next = new ListNode
                {
                    val = 6,
                    next = new ListNode
                    {
                        val = 4
                    }
                }
            };


            var result = addTwoNumbers(num1, num2);
        }
    }
}
