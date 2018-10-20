using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class AlternativeNodeSplit
    {
        public static void alternativeSplit(LinkedListNode pList)
        {
            if (pList == null)
            {
                return;
            }
            
            // dummy node
            LinkedListNode head2 = new LinkedListNode();

            LinkedListNode curr1 = pList;
            LinkedListNode curr2 = head2;

            while (curr1 != null && curr1.next != null)
            {
                curr2.next = curr1.next;
                curr1.next = curr1.next.next;

                curr2 = curr2.next;
                curr2.next = null;

                curr1 = curr1.next;
            }

            // remove the dummy node
            head2 = head2.next;

            Print(pList);
            Print(head2);
        }

        static void Print(LinkedListNode head)
        {
            LinkedListNode curr = head;
            List<int> values = new List<int>();
            while (curr != null)
            {
                values.Add(curr.val);
                curr = curr.next;
            }

            Console.WriteLine(string.Join(",", values));
        }
    }
}
