using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.Sorting
{
    class SortingDriverGFG : IQuestion
    {
        public void Run()
        {
            int[] arr = new int[] { 2, 3, 4, 6, 7, 8, 10, 11 };
            int[] rotatedArr = new int[] { 9, 10, 11, 1, 2, 3, 4, 6, 7, 8};
            int[] randomArr = new int[] { 9, 1, 10, 2, 11, 3, 7, 6, 8 };
            //var sol = BinarySearch.Search(arr, 3);
            //var sol = BinarySearchRotatedArray.Search(rotatedArr, 10);
            //BubbleSort.Sort(randomArr);
            HeapSort.Sort(randomArr);
        }
    }
}
