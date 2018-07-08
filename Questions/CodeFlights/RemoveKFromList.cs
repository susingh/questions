using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CodeFlights
{
    class RemoveKFromList
    {
        ListNode<int> removeKFromList(ListNode<int> l, int k)
        {
            while (l != null && l.value == k)
            {
                // remove nodes from beginning
                l = l.next;
            }

            if (l == null)
            {
                return l;
            }

            var current = l;

            while (current != null && current.next != null)
            {
                if (current.next.value == k)
                {
                    // update next
                    current.next = current.next.next;
                }

                current = current.next;
            }

            return l;
        }

        public void Run()
        {
            var root = new ListNode<int>
            {
                value = 123,
                next = new ListNode<int>
                {
                    value = 456,
                    next = new ListNode<int>
                    {
                        value = 789,
                        next = new ListNode<int>
                        {
                            value = 0,
                            //next = new ListNode<int>
                            //{
                            //    value = 4,
                            //    next = new ListNode<int>
                            //    {
                            //        value = 5
                            //    }

                            //}
                        }
                    }
                }
            };

            var result = removeKFromList(root, 0);
        }
    }
}
