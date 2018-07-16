using Questions.Models;

namespace Questions.IK.LinkedList
{
    class ReverseLL
    {
        public static LinkedListNode reverse(LinkedListNode head)
        {
            if (head == null) return head;

            LinkedListNode prev = null;
            LinkedListNode curr = head;
            LinkedListNode next = curr.next;

            while(next != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;
                next = curr.next;
            }

            curr.next = prev;
            return curr;
        }
    }
}
