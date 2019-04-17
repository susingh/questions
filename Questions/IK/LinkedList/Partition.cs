using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class Partition
    {
        public static ListNode PartitionMain(ListNode head, int x)
        {
            ListNode lessHead = new ListNode(0);
            ListNode less = lessHead;

            ListNode moreHead = new ListNode(0);
            ListNode more = moreHead;

            while (head != null)
            {
                var temp = head.next;
                head.next = null;

                if (head.val < x)
                {
                    less.next = head;
                    less = less.next;
                }
                else
                {
                    more.next = head;
                    more = more.next;
                }

                head = temp;
            }

            Console.WriteLine(less.val);
            Console.WriteLine(moreHead.next.val);

            less.next = moreHead.next;
            return lessHead.next;
        }
    }
}
