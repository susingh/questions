using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class Neighbor
    {
        public int x;
        public int y;
        public double distance;

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ distance.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Neighbor b = (Neighbor)obj;
            if (x == b.x && y == b.y && distance == b.distance) return true;
            return false;
        }
    }

    class NeighbourCompare : IComparer<Neighbor>
    {
        public int Compare(Neighbor a, Neighbor b)
        {
            if (a.distance == b.distance) return 0;
            return (a.distance < b.distance) ? -1 : 1;
        }
    }

    class NearestNeighbors
    {
        public static int[][] find_nearest_neighbours(int px, int py, int[][] n_points, int k)
        {
            Neighbor[] distances = new Neighbor[n_points.GetLength(0)];
            for (int i = 0; i < n_points.GetLength(0); i++)
            {
                distances[i] = new Neighbor
                {
                    x = n_points[i][0],
                    y = n_points[i][1],
                    distance = GetDistance(px, py, n_points[i][0], n_points[i][1])
                };
            }

            // return find_nearest_neighboursQuickSelect(px, py, distances, k);
            return find_nearest_neighboursHeap(px, py, distances, k);
        }

        private static int[][] find_nearest_neighboursHeap(int px, int py, Neighbor[] distances, int k)
        {
            SortedSet<Neighbor> sortedSet = new SortedSet<Neighbor>(new NeighbourCompare());
            foreach (var item in distances)
	        {
               sortedSet.Add(item);
	        }
    
            return GetResult(sortedSet, k);
        }

        private static int[][] GetResult (IEnumerable<Neighbor> distances, int k)
        {
            int[][] result = new int[k][];
            for (int i = 0; i < k; i++)
            {
                result[i] = new int[] { distances.ElementAt(i).x, distances.ElementAt(i).y };
            }

            return result;
        }

        private static int[][] find_nearest_neighboursQuickSelect(int px, int py, Neighbor[] distances, int k)
        {
            // quick select
            QuickSelect(distances, 0, distances.Length - 1, k);
            return GetResult(distances, k);
        }

        private static void QuickSelect(Neighbor[] distances, int start, int end, int k)
        {
            if (start >= end) return;

            int pivot = GetPivot(start, end);
            int partitionIndex = Partition(distances, start, end, pivot);

            if (partitionIndex == k - 1)
            {
                return;
            }
            else if (partitionIndex < k - 1)
            {
                QuickSelect(distances, partitionIndex + 1, end, k);
            }
            else
            {
                QuickSelect(distances, start, partitionIndex - 1, k);
            }
        }

        private static int GetPivot(int start, int end)
        {
            return new Random().Next(start, end);
        }

        private static int Partition(Neighbor[] distances, int start, int end, int pivot)
        {
            double piValue = distances[pivot].distance;
            
            // swap the pivot element with the last element;
            Swap(distances, pivot, end);

            int i = start;
            int j = end - 1;

            while (i < j)
            {
                while (distances[i].distance <= piValue) i++;
                while (distances[j].distance > piValue) j--;

                if (i < j)
                {
                    Swap(distances, i, j);
                    i++;
                    j--;
                }
            }

            // swap the pivot element with the first element of the right array
            Swap(distances, i, end);
            return i;
        }

        private static void Swap(Neighbor[] distances, int a, int b)
        {
            Neighbor temp = distances[a];
            distances[a] = distances[b];
            distances[b] = temp;
        }

       

        private static double GetDistance(int px, int py, int x, int y)
        {
            return Math.Sqrt(Math.Pow((px - x), 2) + Math.Pow((py - y), 2));
        }
    }
}
