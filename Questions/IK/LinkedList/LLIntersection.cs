using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    public class LLIntersection
    {
        public static int find_intersection(LinkedListNode l1, LinkedListNode l2)
        {
            LinkedListNode l1Curr = l1;
            LinkedListNode l2Curr = l2;

            if (l1Curr == null || l2Curr == null)
            {
                return -1;
            }

            int l1Length = 0;
            while (l1Curr.next != null)
            {
                l1Length++;
                l1Curr = l1Curr.next;
            }

            l1Length++;

            int l2Length = 0;
            while (l2Curr.next != null)
            {
                l2Length++;
                l2Curr = l2Curr.next;
            }

            l2Length++;

            // lists do not intersect
            if (l1Curr != l2Curr)
            {
                return -1;
            }

            l1Curr = l1;
            l2Curr = l2;

            if (l1Length < l2Length)
            {
                // move l2 list fwd
                int diff = l2Length - l1Length;
                for (int i = 0; i < diff; i++)
                {
                    l2Curr = l2Curr.next;
                } 
            }
            else
            {
                int diff = l1Length - l2Length;
                for (int i = 0; i < diff; i++)
                {
                    l1Curr = l1Curr.next;
                }
            }

            // now walk the two lists, where they meet return that intersection

            while (l1Curr.next != null && l2Curr.next != null)
            {
                if (l1Curr == l2Curr)
                {
                    return l1Curr.val;
                }

                l1Curr = l1Curr.next;
                l2Curr = l2Curr.next;
            }

            return -1;

        }
    }
}
