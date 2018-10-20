using Questions.Models;

namespace Questions.CCI
{
    public class DeleteMiddleNode : IQuestion
    {
        public void Execute(ListNode<int> head)
        {
            // 2 runners, slow and fast
            // test this with even and odd 

            if (head == null)
            {
                return;
            }

            ListNode<int> current = head;
            ListNode<int> runner = current;

            if (runner.next == null || runner.next.next == null)
            {
                return;
            }

            while (runner.next != null && runner.next.next != null)
            {
                current = current.next;
                runner = runner.next.next;
            }

            // current is the middle node.

            // copy value from next node.
            current.value = current.next.value;

            // delete the next node.
            current.next = current.next.next;
        }

        public void Run()
        {
            // even
            Execute(new ListNode<int>
            {
                value = 1,
                next = new ListNode<int>
                {
                    value = 2,
                    next = new ListNode<int>
                    {
                        value = 3,
                        next = new ListNode<int>
                        {
                            value = 4
                        }
                    }
                }
            });

            // odd
            Execute(new ListNode<int>
            {
                value = 1,
                next = new ListNode<int>
                {
                    value = 2,
                    next = new ListNode<int>
                    {
                        value = 3,
                        next = new ListNode<int>
                        {
                            value = 4,
                            next = new ListNode<int>
                            {
                                value = 5
                            }
                            
                        }
                    }
                }
            });

            // 3 itens
            Execute(new ListNode<int>
            {
                value = 1,
                next = new ListNode<int>
                {
                    value = 2,
                    next = new ListNode<int>
                    {
                        value = 3,
                    }
                }
            });

            // 2 itens
            Execute(new ListNode<int>
            {
                value = 1,
                next = new ListNode<int>
                {
                    value = 2,
                }
            });

            // 1 itens
            Execute(new ListNode<int>
            {
                value = 1,
            });


            // null
            Execute(null);
        }
    }
}
