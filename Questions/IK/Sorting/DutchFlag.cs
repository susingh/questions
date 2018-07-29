using System.Linq;

namespace Questions.IK.Sorting
{
    public class DutchFlag
    {
        //public static string dutch_flag_sort(string balls)
        //{
        //    char[] arr = balls.ToArray();
        //    int redIndex = 0;
        //    int blueIndex = arr.Length - 1;

        //    while (arr[redIndex] != 'R') redIndex++;
        //    while (arr[blueIndex] != 'B') blueIndex--;

        //    int i = 0;
        //    while (i < arr.Length)
        //    {
        //        if (arr[i] == 'B')
        //        {
        //            Swap(arr, i, blueIndex);
        //            blueIndex--;
        //        }
        //        else if (arr[i] == 'R')
        //        {
        //            Swap(arr, i, redIndex);
        //            redIndex++;
        //        }
        //    }

        //    if (i < redBalls && arr[i] == 'R') i++;
        //    else if (i >= redBalls && i < redBalls + greenBalls && arr[i] == 'G') i++;
        //    else if (i >= redBalls + greenBalls && arr[i] == 'B') i++;
        //}

        public static string dutch_flag_sort(string balls)
        {
            char[] arr = balls.ToArray();

            int redIndex = 0;
            int blueIndex = arr.Length - 1;

            while (arr[redIndex] == 'R' && redIndex + 1 < arr.Length - 1) redIndex++;
            while (arr[blueIndex] == 'B' && blueIndex - 1 >= 0) blueIndex--;

            int i = redIndex;
            while (i <= blueIndex)
            {
                if (arr[i] == 'R')
                {
                    swap(arr, i, redIndex);
                    redIndex++;
                    if (i < redIndex)
                    {
                        i = redIndex;
                    }
                }
                else if (arr[i] == 'B')
                {
                    swap(arr, i, blueIndex);
                    blueIndex--;
                    //i++;
                }
                else
                {
                    i++;
                }
            }

            return new string(arr);
        }

        static void swap(char[] arr, int a, int b)
        {
            char temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }


        public string Sort(string balls)
        {
            char[] arr = balls.ToArray();

            int redIndex = 0;
            int blueIndex = arr.Length - 1;
            int i = 0;

            {
                if (arr[i] == 'R' && arr[redIndex] != 'R')
                {
                    SortingDriver.Swap(arr, i, redIndex);
                    redIndex++;
                }
                else if (arr[i] == 'B' && arr[blueIndex] != 'B')
                {
                    SortingDriver.Swap(arr, i, blueIndex);
                    blueIndex--;
                }
                else
                {
                    i++;
                }
            }

            return new string(arr);
        }
    }
}
