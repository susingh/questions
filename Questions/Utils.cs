using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    public class Utils
    {
        public static void PrintList<T>(ListNode<T> head)
        {
            Console.WriteLine();
            ListNode<T> current = head;

            while (current != null)
            {
                Console.Write(current.value);
                Console.Write("->");

                current = current.next;
            }
        }

        public static void PrintList(ListNode head)
        {
            Console.WriteLine();
            ListNode current = head;

            while (current != null)
            {
                Console.Write(current.val);
                Console.Write("->");

                current = current.next;
            }
        }

        public static void Swap<T>(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static ListNode BuildList(int[] arr)
        {
            ListNode head = new ListNode(-1);
            ListNode curr = head;

            foreach (var item in arr)
            {
                curr.next = new ListNode(item);
                curr = curr.next;
            }
            return head.next;
        }
    }
}
