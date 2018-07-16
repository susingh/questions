namespace Questions.IK.LinkedList
{
    class ZipLL
    {
        public static LinkedListNode zip_given_linked_list(LinkedListNode head)
        {
            if (head == null) return head;
            if (head.next == null) return head;

            // run slow and fast pointers
            LinkedListNode slow = head;
            LinkedListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // break the list after slow
            LinkedListNode head2 = slow.next;
            slow.next = null;

            // reverse the second list
            head2 = ReverseLL.reverse(head2);

            // zip the two lists
            return ZipLists(head, head2);
        }

        private static LinkedListNode ZipLists(LinkedListNode head1, LinkedListNode head2)
        {
            LinkedListNode curr1 = head1;
            LinkedListNode curr2 = head2;

            while (curr1 != null && curr2 != null)
            {
                LinkedListNode temp1 = curr1.next;
                LinkedListNode temp2 = curr2.next;

                curr1.next = curr2;
                curr2.next = temp1;

                curr1 = temp1;
                curr2 = temp2;
            }

            return head1;
        }
    }
}
