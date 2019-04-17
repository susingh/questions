using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    /// <summary>
    /// Sort a LL wrt to a given number. Lesser values come to the left, 
    /// same values are in the middle, and greater values go to the right
    /// </summary>
    class DutchSort
    {
        private class LinkedListContainer
        {
            ListNode head = null;
            ListNode tail = null;

            public LinkedListContainer()
            {
                // [Improvement] : Using sentinal nodes to simplify adding a new node.
                head = new ListNode();
                tail = head;
            }

            public void Add(ListNode node)
            {
                tail.next = node;
                tail = node;
            }

            public ListNode GetHead()
            {
                return head.next;
            }

            public ListNode GetTail()
            {
                return tail;
            }
        }

        public static ListNode Sort(ListNode head, int k)
        {
            LinkedListContainer smaller = new LinkedListContainer();
            LinkedListContainer same = new LinkedListContainer();
            LinkedListContainer greater = new LinkedListContainer();

            while (head != null)
            {
                var temp = head;
                head = head.next;

                // [Mistake] ensure to clear existing links from removed nodes.
                temp.next = null;

                if (temp.val < k)
                {
                    smaller.Add(temp);
                }
                else if (temp.val == k)
                {
                    same.Add(temp);
                }
                else
                {
                    greater.Add(temp);
                }
            }

            // [Mistake] to set tail to the next LL's head instead of tail.next;
            smaller.GetTail().next = same.GetHead();
            same.GetTail().next = greater.GetHead();

            return smaller.GetHead();
        }
    }
}
