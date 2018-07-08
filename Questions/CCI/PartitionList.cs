using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI
{
    public class PartitionList : IQuestion
    {
        public ListNode<int> Execute(ListNode<int> head, int partition)
        {
            if (head == null) return head;
            if (head.next == null) return head;

            ListNode<int> current = head;

            while (current.next != null)
            {
                if (current.next.value < partition)
                {
                    // move this to the head
                    var temp = current.next;
                    current.next = temp.next;
                    temp.next = head;
                    head = temp;
                }
                else
                {
                    current = current.next;
                }
            }

            return head;
        }

        public void Run()
        {
            var head = new ListNode<int>
            {
                value = 1,
                next = new ListNode<int>
                {
                    value = 5,
                    next = new ListNode<int>
                    {
                        value = 8,
                        next = new ListNode<int>
                        {
                            value = 2,
                            next = new ListNode<int>
                            {
                                value = 2,
                                next = new ListNode<int>
                                {
                                    value = 6
                                }
                            }
                        }
                    }
                }

            };

            Utils.PrintList(head);
            head = Execute(head, 5);
            Utils.PrintList(head);
        }
    }
}
