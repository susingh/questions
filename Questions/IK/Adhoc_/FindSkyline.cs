using System;
using System.Collections.Generic;

namespace Questions.IK.Adhoc_
{
    class FindSkyline
    {
        class Building : IComparer<Building>
        {
            public int Left;
            public int Height;
            public int Right;

            public int Compare(Building x, Building y)
            {
                if (x.Left < y.Left)
                {
                    return -1;
                }
                else if (x.Left > y.Left)
                {
                    return 1;
                }
                else
                {
                    if (x.Right < y.Right)
                    {
                        return -1;
                    }
                    else if (x.Right > y.Right)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static int[][] Find_skyline(int[][] buildings)
        {
            int maxSize = 0;
            for (int i = 0; i < buildings.Length; i++)
            {
                maxSize = Math.Max(maxSize, buildings[i][2]);
            }

            int[] arr = new int[maxSize+1];

            for (int i = 0; i < buildings.Length; i++)
            {
                for (int j = buildings[i][0]; j < buildings[i][2]; j++)
                {
                    arr[j] = Math.Max(buildings[i][1], arr[j]);
                }
            }

            int prev = 0;
            List<int[]> points = new List<int[]>();
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] != prev)
                {
                    points.Add(new int[] { k, arr[k] });
                    prev = arr[k];
                }
            }

            return points.ToArray();
        }

        //public static int[][] Find_skyline2(int[][] buildings)
        //{
        //    List<Building> blgs = new List<Building>();
        //    for (int i = 0; i < buildings.Length; i++)
        //    {
        //        blgs.Add(new Building()
        //        {
        //            Left = buildings[i][0],
        //            Right = buildings[i][2],
        //            Height = buildings[i][1]
        //        });
        //    }

        //    // nlogn
        //    blgs.Sort();

        //    foreach(var blg in blgs)
        //    {

        //    }
        //}
    }
}
