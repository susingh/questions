using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Concurrency
{
    public class ThreadPoolDriver : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    public class ThreadPool
    {
        private int _threads;
        private ProduceConsumerQueue pcq;

        public ThreadPool(int threads)
        {
            _threads = threads;
            pcq = new ProduceConsumerQueue(threads * 5);
        }

        void ShutDown (bool waitForThreads)
        {
            for (int i = 0; i < _threads; i++)
            {
                pcq.Produce(null);
            }

            //if (waitForThreads)
            
        }

        void Add(Task t)
        {
            pcq.Produce(t);
        }
    }
}
