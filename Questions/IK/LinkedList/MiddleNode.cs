using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class MiddleNode
    {
        public static LinkedListNode find_middle_node(LinkedListNode head)
        {
            if (head == null)
            {
                return head;
            }

            LinkedListNode slow = head;
            LinkedListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // odd number of nodes
            if (fast.next == null)
            {
                return slow;
            }
            else
            {
                return slow.next;
            }
        }
    }
}
