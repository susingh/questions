namespace Questions.IK.Adhoc_
{
    class MinRotatedSortedArray
    {
        public static int FindMin(int[] arr)
        {
            int l = 0;
            int r = arr.Length - 1;
            int min = arr[0];

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] > arr[mid+1])
                {
                    min = arr[min+1];
                    break;
                }
                else if (arr[mid] < arr[mid - 1])
                {
                    min = arr[min];
                    break;
                }
                else
                {
                    if (arr[r] < arr[l])
                    {
                        // in the right section
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }

            return min;
        }
    }
}