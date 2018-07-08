using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI
{
    public class ListLoop : IQuestion
    {
        public ListNode Execute(ListNode head)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            var curr = head;

            while (curr != null)
            {
                if (nodes.Contains(curr))
                {
                    return curr;
                }

                nodes.Add(curr);
                curr = curr.next;
            }

            return null;
        }

        public void Run()
        {
            ListNode A = new ListNode(1);
            ListNode B = new ListNode(2);
            ListNode C = new ListNode(3);
            ListNode D = new ListNode(4);
            ListNode E = new ListNode(5);

            ListNode head = A;
            A.next = B;
            B.next = C;
            C.next = D;
            D.next = E;
            E.next = C;

            var node = Execute(head);
        }
    }
}
