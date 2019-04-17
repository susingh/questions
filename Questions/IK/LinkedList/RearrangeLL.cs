using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class RearrangeLL
    {
        public static ListNode Rearrange(ListNode head)
        {
            ListNode evenHead = new ListNode();
            ListNode oddHead = new ListNode();

            ListNode currEven = evenHead;
            ListNode currOdd = oddHead;

            while (head != null)
            {
                if (head.val % 2 == 0)
                {
                    currEven.next = head;
                    currEven = currEven.next;
                }
                else
                {
                    currOdd.next = head;
                    currOdd = currOdd.next;
                }

                head = head.next;
            }

            currOdd.next = null;
            currEven.next = oddHead.next;

            return evenHead.next;
        }
    }
}
