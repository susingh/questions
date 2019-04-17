using Questions.Models;

namespace Questions.IK.LinkedList
{
    public class FindMedian
    {
        public static int find_median(ListNode ptr)
        {
            ListNode curr = ptr;
            int count = 1;

            // calculate the number of nodes in the list and find the start of the list
            int ascNodes = 0;
            int descNodes = 0;
            while (curr.next != ptr)
            {
                if (curr.val > curr.next.val)
                {
                    descNodes++;
                }
                else
                {
                    ascNodes++;
                }


                curr = curr.next;
                count++;
            }

            curr = ptr;
            bool isAscending = ascNodes > descNodes;
            ListNode start = curr;
            while (curr.next != ptr)
            {
                if (isAscending && curr.val > curr.next.val)
                {
                    start = curr.next;
                }
                else if (!isAscending && curr.val < curr.next.val)
                {
                    start = curr.next;
                }

                curr = curr.next;
            }

            ListNode slow = start;
            ListNode fast = start;

            while (fast.next != start && fast.next.next != start)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            if (count % 2 == 0)
            {
                // middle two elements
                return slow.val / 2 + slow.next.val / 2;
            }
            else
            {
                return slow.val;
            }
        }
    }
}
