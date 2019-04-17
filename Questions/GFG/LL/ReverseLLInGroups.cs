using Questions.IK.LinkedList;
using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class ReverseLLInGroups
    {
        public static void reverseLL(ListNode root, int k)
        {
            if (root == null || root.next == null)
                return;

            var start = root;
            var curr = root;
            int counter = 0;
            ListNode prev = null;
            var next = curr.next;
            while (curr != null)
            {
                counter++;
                curr.next = prev;
                prev = curr;
                curr = next;

                if (counter == k)
                {
                    // stitch ends
                    start.next = curr;
                    counter = 0;
                }

                curr = curr.next;
            }
        }
    }
}
