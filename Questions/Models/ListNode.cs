using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Models
{
    public class ListNode<T>
    {
        public T value { get; set; }
        public ListNode<T> next { get; set; }
    }

    public class ListNode
    {
        public int value;
        public ListNode next;

        public ListNode() { }

        public ListNode(int value) { this.value = value; }

    }
}
