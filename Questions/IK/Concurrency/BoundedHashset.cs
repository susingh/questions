using System;
using System.Collections.Generic;
using System.Threading;

namespace Questions.IK.Concurrency
{
    public class BoundedHashSetDriver : IQuestion
    {
        public void Run()
        {
            BoundedHashset bhs = new BoundedHashset(5);

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    bhs.Put(i);
                }
            })
            {
                Name = "T1"
            }.Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    bhs.Erase(i);
                }
            })
            {
                Name = "T2"
            }.Start();
        }
    }

    public class BoundedHashset
    {
        private HashSet<object> _set;
        private int _maxSize;
        SemaphoreSlim sem;

        public BoundedHashset(int maxSize)
        {
            _maxSize = maxSize;
            _set = new HashSet<object>();
            sem = new SemaphoreSlim(maxSize);
        }

        public void Put(object o)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to add {o} to the set");

            /*
             * Caution: Need to wait on the sem BEFORE taking the lock on the shared resource. If the sem is waited inside the critical section
             * it would result in a deadlock.
             */
            sem.Wait();

            lock (_set)
            {
                if (!_set.Add(o))
                {
                    sem.Release();
                }

                Console.WriteLine($"{Thread.CurrentThread.Name} adding {o} to the set");
            }
        }

        public void Erase(object o)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to remove {o} from the set");

            lock (_set)
            {
                if (_set.Remove(o))
                {
                    sem.Release();
                    Console.WriteLine($"{Thread.CurrentThread.Name} removed {o} from the set");
                }
            }
        }
    }
}
