using Questions.IK.LinkedList;
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
            LinkedListNode l1 = new LinkedListNode
            {
                val = 5,
                next = new LinkedListNode
                {
                    val = 6,
                    next = new LinkedListNode
                    {
                        val = 3,
                        next = new LinkedListNode
                        {
                            val = 1,
                            next = new LinkedListNode
                            {
                                val = 2
                            }
                        }
                    }
                }
            };

            LinkedListNode l2 = new LinkedListNode
            {
                val = 8,
                next = new LinkedListNode
                {
                    val = 4,
                    next = new LinkedListNode
                    {
                        val = 2,
                        next = new LinkedListNode
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
