using Questions.IK.LinkedList;
using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class MergeListsAlternatingly
    {
        public static void MergeList(ListNode l1, ListNode l2)
        {
            if (l2 == null || l1 == null)
                return;

            var p1 = l1;
            var p2 = l2;

            while (p1 != null && p2 != null)
            {
                var temp = p1.next;
                p1.next = p2;
                l2 = p2.next;
                p2.next = temp;
                
                p1 = temp;
                p2 = l2;
            }
        }
    }
}
