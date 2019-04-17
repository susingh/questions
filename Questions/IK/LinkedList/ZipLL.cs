using Questions.Models;

namespace Questions.IK.LinkedList
{
    class ZipLL
    {
        public static ListNode zip_given_linked_list(ListNode head)
        {
            if (head == null) return head;
            if (head.next == null) return head;

            // run slow and fast pointers
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // break the list after slow
            ListNode head2 = slow.next;
            slow.next = null;

            // reverse the second list
            head2 = ReverseLL.reverse(head2);

            // zip the two lists
            return ZipLists(head, head2);
        }

        private static ListNode ZipLists(ListNode head1, ListNode head2)
        {
            ListNode curr1 = head1;
            ListNode curr2 = head2;

            while (curr1 != null && curr2 != null)
            {
                ListNode temp1 = curr1.next;
                ListNode temp2 = curr2.next;

                curr1.next = curr2;
                curr2.next = temp1;

                curr1 = temp1;
                curr2 = temp2;
            }

            return head1;
        }
    }
}
