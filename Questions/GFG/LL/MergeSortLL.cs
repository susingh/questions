using Questions.IK.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class MergeSortLL
    {
        public static void Sort(LinkedListNode root)
        {
            Sort(ref root);
        }
        private static void Sort(ref LinkedListNode root)
        {
            if (root == null || root.next == null)
                return;

            LinkedListNode a = null;
            LinkedListNode b = null;
            SplitList(root, ref a, ref b);

            Sort(ref a);
            Sort(ref b);
            root = Merge(a, b);
        }

        private static void SplitList(LinkedListNode root, ref LinkedListNode a, ref LinkedListNode b)
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

        private static LinkedListNode Merge(LinkedListNode a, LinkedListNode b)
        {
            if (a == null && b == null)
                return null;

            LinkedListNode result = new LinkedListNode();
            LinkedListNode curr = result;
			while (a != null && b != null)
			{
				if (a.val > b.val)
                {
                    curr.next = new LinkedListNode
                    {
                        val = b.val
                    };

                    b = b.next;
                }
				else
                {
                    curr.next = new LinkedListNode
                    {
                        val = a.val
                    };

                    a = a.next;
                }

                curr = curr.next;
            }

			while (a != null)
            {
                curr.next = new LinkedListNode
                {
                    val = a.val
                };

                a = a.next;
                curr = curr.next;
            }

            while(b != null)
            {
                curr.next = new LinkedListNode
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
