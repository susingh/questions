using Questions.IK.LinkedList;
using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.LL
{
    class LinkedListDriverGFG : IQuestion
    {
        public void Run()
        {
            ListNode l1 = new ListNode
            {
                val = 5,
                next = new ListNode
                {
                    val = 6,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 1,
                            next = new ListNode
                            {
                                val = 2
                            }
                        }
                    }
                }
            };

            ListNode l2 = new ListNode
            {
                val = 8,
                next = new ListNode
                {
                    val = 4,
                    next = new ListNode
                    {
                        val = 2,
                        next = new ListNode
                        {
                            val = 1
                        }
                    }
                }
            };

            //AddTwoNumbers.Sum(l1, l2);
            //MergeListsAlternatingly.MergeList(l1, l2);
            MergeSortLL.Sort(l1);
        }
    }
}
