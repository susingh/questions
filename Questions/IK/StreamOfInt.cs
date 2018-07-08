//using Questions.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Questions.IK
//{

//    ListNode FindKthNodeFromEnd(int k, ListNode head)
//    {
//        ListNode fwd = head;
//        while (k > 0 && fwd != null)
//        {
//            fwd = fwd.next;
//            k--;
//        }

//        if (k > 0)
//        {
//            return null;
//        }

//        ListNode back = head;

//        while(fwd != null)
//        {
//            fwd = fwd.next;
//            back = back.next;
//        }

//        return back;
//    }

//    ListNode FindStartNode(ListNode head, int length)
//    {
//        ListNode curr = head;
//        while (length > 0)
//        {
//            curr = curr.next;
//        }

//        ListNode back = head;

//        while (curr != back)
//        {
//            back = back.next;
//            curr = curr.next;
//        }

//        return curr;
//    }

    

//    bool IsSubset(int[] m, int[] n)
//    {
//        int ptrm = 0;
//        int ptrn = 0;
//        int matches = 0;

//        while (ptrm < m.Length && ptrn < n.Length)
//        {
//            if (m[ptrm] == n[ptrn])
//            {
//                ptrm++;
//                ptrn++;
//                matches++;
//            }
//            else
//            {
//                if (m[ptrm] < n[ptrn])
//                {
//                    //ptrm[];
//                }
//            }
//        }
//    }

//    class StreamOfInt
//    {
//        void Print(object input, int k, int num)
//        {
//            while(input)
//            {
//                if (input == 404)
//                {
//                    Console.WriteLine(printHeap);
//                }
//            }
//        }
//    }
//}