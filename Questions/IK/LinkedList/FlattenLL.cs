using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class ModifiedLinkedListNode
    {
        public int val;
        public ModifiedLinkedListNode Child;
        public ModifiedLinkedListNode Next;
    }

    class FlattenLL
    {
        public static void Flatten(ModifiedLinkedListNode node)
        {
            Queue<ModifiedLinkedListNode> q = new Queue<ModifiedLinkedListNode>();
            q.Enqueue(node);

            ModifiedLinkedListNode head = new ModifiedLinkedListNode();
            ModifiedLinkedListNode tail = head;

            while (q.Count != 0)
            {
                ModifiedLinkedListNode curr = q.Dequeue();
                tail.Next = curr;

                while (curr != null)
                {
                    if (curr.Child != null)
                    {
                        q.Enqueue(curr);
                    }

                    curr = curr.Next;
                    tail = tail.Next;
                }
            }

            node = head.Next;
        }

        public static void FlattenOptimal(ModifiedLinkedListNode node)
        {
            ModifiedLinkedListNode tail = node;
            GetTail(tail);

            ModifiedLinkedListNode curr = node;

            while (curr != null)
            {
                if (curr.Child != null)
                {
                    tail.Next = curr.Child;
                    GetTail(curr.Child);
                    curr.Child = null;
                }

                curr = curr.Next;
            }
        }

        private static void GetTail(ModifiedLinkedListNode node)
        {
            while (node.Next != null)
            {
                node = node.Next;
            }
        }
    }
}
