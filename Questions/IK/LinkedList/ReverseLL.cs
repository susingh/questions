using Questions.Models;

namespace Questions.IK.LinkedList
{
    class ReverseLL
    {
        static ListNode _head = null;

        public static ListNode reverse(ListNode node)
        {
            //if (head == null || head.next == null)
            //    return head;

            //LinkedListNode prev = null;
            //LinkedListNode curr = head;
            //LinkedListNode next = curr.next;

            //while(next != null)
            //{
            //    curr.next = prev;

            //    prev = curr;
            //    curr = next;
            //    next = curr.next;
            //}

            //curr.next = prev;
            //return curr;

            ListNode head = node;
            ListNode tail = node;
            //ReverseListRecursive(ref head, node, ref tail);

            ReverseListRecursive(null, node);

            return _head;
        }

        private static void ReverseListRecursive(ref ListNode head, ListNode curr, ref ListNode tail)
        {
            if (curr == null || curr.next == null)
            {
                head = curr;
                tail = curr;

                return;
            }

            var temp = curr.next;
            curr.next = null;
            ReverseListRecursive(ref head, temp, ref tail);
            tail.next = curr;
            tail = tail.next;
        }

        private static void ReverseListRecursive(ListNode prev, ListNode curr)
        {
            if (curr == null)
                return;

            if (curr.next == null)
            {
                curr.next = prev;
                _head = curr;
                return;
            }

            var temp = curr.next;
            curr.next = prev;
            ReverseListRecursive(curr, temp);
        }
    }
}
