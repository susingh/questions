using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class MergeSortLL
    {
        // split the LL
        // sort them separately,
        // merge them.

        public static LinkedListNode mergeSortList(LinkedListNode pList)
        {
            int length = GetLength(pList);
            return mergeSortListRecursive(pList, length);
        }

        private static LinkedListNode mergeSortListRecursive(LinkedListNode head, int length)
        {
            // base case
            if (length == 0 || length == 1)
            {
                return head;
            }

            int mid = length / 2;
            LinkedListNode prev = null;
            LinkedListNode curr = head;

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

        private static LinkedListNode merge(LinkedListNode head1, LinkedListNode head2)
        {
            LinkedListNode curr1 = head1;
            LinkedListNode curr2 = head2;

            while (curr1 != null && curr2 != null)
            {

            }

            while (curr1 != null)
            {

            }

            while(curr2 != null)
            {

            }

            return null;
        }

        private static int GetLength(LinkedListNode head)
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
