using Questions.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class StreamMedian
    {
        private class Stream
        {
            public int Next()
            {
                return new Random((int)DateTime.UtcNow.Ticks).Next(-1, 1000);
            }
        }

        static void GetMedian(Stream ip)
        {
            int val;

            MinHeap<int> rHeap = new MinHeap<int>();
            MaxHeap<int> lHeap = new MaxHeap<int>();

            double runningMedian = 0.0;

            while ((val = ip.Next()) != -1)
            {
                if (rHeap.Count == lHeap.Count)
                {
                    if (val < runningMedian)
                    {
                        lHeap.Add(val);
                        runningMedian = lHeap.Peek();
                    }
                    else
                    {
                        rHeap.Add(val);
                        runningMedian = rHeap.Peek();
                    }
                }
                else if (lHeap.Count > rHeap.Count)
                {
                    if (val < runningMedian)
                    {
                        rHeap.Add(lHeap.Delete());
                        lHeap.Add(val);
                    }
                    else
                    {
                        rHeap.Add(val);
                    }

                    runningMedian = (lHeap.Peek() + rHeap.Peek()) / 2.0;
                }
                else
                {
                    if (val < runningMedian)
                    {
                        lHeap.Add(val);
                    }
                    else
                    {
                        lHeap.Add(rHeap.Delete());
                        rHeap.Add(val);
                    }

                    runningMedian = (lHeap.Peek() + rHeap.Peek()) / 2.0;
                }
            }
        }
    }
}
