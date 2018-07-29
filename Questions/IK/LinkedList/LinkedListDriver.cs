using Questions.IK.LinkedList;
using Questions.Models;

namespace Questions.IK
{
    public class LinkedListDriver : IQuestion
    {
        public void Run()
        {
            LinkedListNode intersection = new LinkedListNode()
            {
                val = 4,
                next = new LinkedListNode()
                {
                    val = 5,
                    next = new LinkedListNode()
                    {
                        val = 6
                    }
                }
            };

            LinkedListNode root = new LinkedListNode()
            {
                val = 1,
                next = new LinkedListNode()
                {
                    val = 2,
                    next = new LinkedListNode()
                    {
                        val = 3,
                        next = intersection
                    }
                }
            };

            LinkedListNode root2 = new LinkedListNode()
            {
                val = 7,
                next = new LinkedListNode()
                {
                    val = 8,
                    next = intersection
                }
            };


            int[] query_type = new int[] { 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 };
            int[] key =        new int[] { 5, 4, 1, 2, 2, 2, 3, 2, 5, 4, 4, 2, 4, 3, 5 };
            int[] value =      new int[] { 5, 3, 4, 4, 1, 4, 5, 1, 2, 3, 3, 3, 3, 1, 3 };

            LinkedListNode circular = new LinkedListNode() { val = 16 };

            circular.next = new LinkedListNode()
            {
                val = 8,
                next = new LinkedListNode()
                {
                    val = 4,
                    next = new LinkedListNode()
                    {
                        val = 2,
                        next = circular
                    }
                }
            };

            //LinkedListNode circular = new LinkedListNode() { val = 2 };

            //circular.next = new LinkedListNode()
            //{
            //    val = 2,
            //    next = circular
            //};

            var solution
                // = ReverseLL.reverse(root);
                // = ZipLL.zip_given_linked_list(root);
                // = LRUCache.implement_LRU_cache(3, query_type, key, value);
                //= BalancedParenthesis.find_max_length_of_matching_parentheses("(((())(()");
                // = MaxNumberInSlidingWindow.max_in_sliding_window(new int[] { 0 }, 1);
                // = LLIntersection.find_intersection(root, root2);
                = FindMedian.find_median(circular.next);
        }
    }
}