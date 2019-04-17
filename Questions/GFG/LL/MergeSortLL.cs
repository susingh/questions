using Questions.IK.LinkedList;
using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class MergeSortLL
    {
        public static void Sort(ListNode root)
        {
            Sort(ref root);
        }
        private static void Sort(ref ListNode root)
        {
            if (root == null || root.next == null)
                return;

            ListNode a = null;
            ListNode b = null;
            SplitList(root, ref a, ref b);

            Sort(ref a);
            Sort(ref b);
            root = Merge(a, b);
        }

        private static void SplitList(ListNode root, ref ListNode a, ref ListNode b)
        {
            if (root == null)
                return;

            var slow = root;
            var fast = root;

			while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // break the lists after slow
            a = root;
            b = slow.next;
            slow.next = null;
        }

        private static ListNode Merge(ListNode a, ListNode b)
        {
            if (a == null && b == null)
                return null;

            ListNode result = new ListNode();
            ListNode curr = result;
			while (a != null && b != null)
			{
				if (a.val > b.val)
                {
                    curr.next = new ListNode
                    {
                        val = b.val
                    };

                    b = b.next;
                }
				else
                {
                    curr.next = new ListNode
                    {
                        val = a.val
                    };

                    a = a.next;
                }

                curr = curr.next;
            }

			while (a != null)
            {
                curr.next = new ListNode
                {
                    val = a.val
                };

                a = a.next;
                curr = curr.next;
            }

            while(b != null)
            {
                curr.next = new ListNode
                {
                    val = b.val
                };

                b = b.next;
                curr = curr.next;
            }

            return result.next;
        }
    }
}
