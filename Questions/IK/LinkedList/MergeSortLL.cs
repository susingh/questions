using Questions.Models;

namespace Questions.IK.LinkedList
{
    class MergeSortLL
    {
        // split the LL
        // sort them separately,
        // merge them.
    
        public static ListNode MergeSort(ListNode pList)
        {
            int length = GetLength(pList);
            return mergeSortListRecursive(pList, length);
        }

        private static ListNode mergeSortListRecursive(ListNode head, int length)
        {
            // base case
            if (length == 0 || length == 1)
            {
                return head;
            }

            int mid = length / 2;
            ListNode prev = null;
            ListNode curr = head;

            for (int i = 0; i < mid; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            // break the list;
            prev.next = null;

            var node1 = mergeSortListRecursive(head, mid);
            var node2 = mergeSortListRecursive(curr, length - mid);
            return merge(node1, node2);
        }

        private static ListNode merge(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode curr = head;

            while (l1 != null && l2 != null)
            {
                if (l2.val < l1.val)
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    curr.next = l1;
                    l1 = l1.next;
                }

                curr = curr.next;
            }

            if (l1 != null)
            {
                curr.next = l1;
            }

            if (l2 != null)
            {
                curr.next = l2;
            }

            return head.next;
        }

        private static int GetLength(ListNode head)
        {
            var curr = head;
            int count = 0;
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }

            return count;
        }
    }
}
