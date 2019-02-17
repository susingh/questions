//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Questions.IK.Recursion
//{
//    class NQueens
//    {
//        public bool N_Queens(int n)
//        {
//            if (n < 4) return false;

//            int[] placement = new int[n];
//            var value = NQueens(placement, 0, n);
//            if (value)
//            {
//                Print(placement);
//            }

//            return value;
//        }

//        private void Print(int[] placement)
//        {
//            throw new NotImplementedException();
//        }

//        private bool N_Queens(int[] placement, int r, int n)
//        {
//            if (r == n) return true;

//            for (int i = 0; i < n; i++)
//            {
//                placement[r] = i;
//                if (IsSafe(placement, r))
//                {
//                    return NQueens(placement, r + 1, n);
//                }
//            }

//            return false;
//        }

//        private bool IsSafe(int[] placement, int r)
//        {
//            for (int i = 0; i < r; i++)
//            {
//                if (IsSafe(i, placement[i], r, placement[r]))
//                {
//                    return false;
//                }
//            }

//            return true;
//        }

//        private bool IsSafe(int row1, int col1, int row2, int col2)
//        {
//            if (row1 == row2) return false;
//            if (col1 == col2) return false;
//            if (Math.Abs(col1 - col2) == Math.Abs(row1 - row2)) return false;
//            return true;
//        }
//    }
//}