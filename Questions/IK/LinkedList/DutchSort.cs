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
            LinkedListNode head = null;
            LinkedListNode tail = null;

            public LinkedListContainer()
            {
                // [Improvement] : Using sentinal nodes to simplify adding a new node.
                head = new LinkedListNode();
                tail = head;
            }

            public void Add(LinkedListNode node)
            {
                tail.next = node;
                tail = node;
            }

            public LinkedListNode GetHead()
            {
                return head.next;
            }

            public LinkedListNode GetTail()
            {
                return tail;
            }
        }

        public static LinkedListNode Sort(LinkedListNode head, int k)
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
