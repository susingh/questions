using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    public class Cycle
    {
        /// <summary>
        /// Check if a LL has a cycle
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool hasCycle(LinkedListNode node)
        {
            LinkedListNode fast = node;
            LinkedListNode slow = node;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Count the number of nodes in the cycle
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int countCycle(LinkedListNode node)
        {
            LinkedListNode fast = node;
            LinkedListNode slow = node;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    break;
                }
            }

            if (slow == fast)
            {
                int count = 0;
                while (slow != null)
                {
                    slow = slow.next;
                    count++;
                    if (slow == fast)
                    {
                        return count;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Find the first element where the cycle starts from
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static LinkedListNode firstNodeCycle(LinkedListNode node)
        {
            LinkedListNode fast = node;
            LinkedListNode slow = node;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    break;
                }
            }

            if (slow != fast)
            {
                return null;
            }

            // move one node to start of the list
            slow = node;

            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;
        }
    }
}
