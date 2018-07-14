using System.Linq;

namespace Questions.IK.Sorting
{
    public class DutchFlag
    {
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
