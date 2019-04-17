

using Questions.Models;

namespace Questions.IK.LinkedList
{
    class ReverseInGroups
    {
        public static ListNode reverse_linked_list_in_groups_of_k(ListNode head, int k)
        {
            // create a window of size k (or less)
            // reverse a LL in the window
            // connect the window back to the list

            ListNode prev = null;
            var start = head;
            var stop = head;

            int count = 0;

            while (stop != null)
            {
                count++;

                if (count == k || stop.next == null)
                {
                    var startOfNext = stop.next;
                    stop.next = null;
                    Reverse(start);

                    if (prev == null)
                    {
                        head = stop;
                    }
                    else
                    {
                        prev.next = stop;
                    }

                    start.next = startOfNext;
                    prev = start;
                    start = startOfNext;
                    stop = start;
                    count = 0;
                }
                else
                {
                    stop = stop.next;
                }
            }

            return head;
        }

        static void Reverse(ListNode node)
        {
            ListNode prev = null;
            ListNode curr = node;
            ListNode next = node.next;

            while (curr != null && next != null)
            {
                curr.next = prev;

                prev = curr;
                curr = next;
                next = curr.next;
            }

            curr.next = prev;
        }
    }
}
