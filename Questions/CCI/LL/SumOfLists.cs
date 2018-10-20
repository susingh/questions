using Questions.LeetCode;
using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI
{
    public class SumOfLists : IQuestion
    {
        public ListNode ReverseSum(ListNode a, ListNode b)
        {
            int num1 = GetNumberReverse(a);
            int num2 = GetNumberReverse(b);

            int sum = num1 + num2;
            return GetListReverse(sum);
        }

        private ListNode GetListReverse(int num)
        {
            ListNode head = new ListNode();
            ListNode curr = head;

            while (true)
            {
                int value = num % 10;
                curr.value = value;
                num = num / 10;

                if (num > 0)
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }
                else
                {
                    break;
                }
            }

            return head;
        }

        private ListNode GetListForward(int num)
        {
            Stack<int> stack = new Stack<int>();
            while (num > 0)
            {
                int value = num % 10;
                stack.Push(value);
                num = num / 10;
            }

            ListNode head = new ListNode();
            ListNode curr = head;

            while (true)
            {
                int value = stack.Pop();
                curr.value = value;

                if (stack.Any())
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }
                else
                {
                    break;
                }
            }

            return head;
        }

        private int GetNumberReverse(ListNode head)
        {
            int num = 0;
            int power = 0;
            var curr = head;

            while (curr != null)
            {
                num += curr.value * (int)Math.Pow(10, power);
                curr = curr.next;
                power++;
            }

            return num;
        }

        private int GetNumberForward(ListNode head)
        {
            int num = 0;
            int power = 0;
            var curr = head;

            Stack<int> stack = new Stack<int>();
            while (curr != null)
            {
                stack.Push(curr.value);
                curr = curr.next;
            }

            while(stack.Count > 0)
            {
                int value = stack.Pop();
                num += value * (int)Math.Pow(10, power);
                power++;
            }

            return num;
        }

        public ListNode ForwardSum(ListNode a, ListNode b)
        {
            int num1 = GetNumberForward(a);
            int num2 = GetNumberForward(b);

            int sum = num1 + num2;
            return GetListForward(sum);
        }

        public void Run()
        {
            var a = new ListNode(7)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(6)
                }
            };


            var b = new ListNode(5)
            {
                next = new ListNode(9)
                {
                    next = new ListNode(2)
                }
            };

            Utils.PrintList(a);
            Utils.PrintList(b);
            var head = ReverseSum(a, b);
            Utils.PrintList(head);

            a = new ListNode(6)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(7)
                }
            };


            b = new ListNode(2)
            {
                next = new ListNode(9)
                {
                    next = new ListNode(5)
                }
            };

            Utils.PrintList(a);
            Utils.PrintList(b);
            head = ForwardSum(a, b);
            Utils.PrintList(head);
        }
    }
}
