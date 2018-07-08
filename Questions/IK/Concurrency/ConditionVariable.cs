using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Questions.IK.Concurrency
{
    public class ConditionVariable
    {
        SemaphoreSlim sem = new SemaphoreSlim(0, int.MaxValue);

        private int _waiters = 0;
        private Object _waiters_lock = new object();

        public void Wait(object obj)
        {
            try
            {
                lock (_waiters_lock)
                {
                    ++_waiters;
                }

                Monitor.Exit(obj);
                Console.WriteLine($"{Thread.CurrentThread.Name} waiting for CV condition to signalled");
                sem.Wait();
            }
            catch (SynchronizationLockException)
            {
                // don't "reacquire" lock if did not own it in first place!
                //reacquire = false;
                throw;
            }
            finally
            {
                //bool last_waiter;

                lock (_waiters_lock)
                {
                    --_waiters;
                    //last_waiter = _was_pulse_all && _waiters == 0;
                }

                // signal broadcaster if the last waiter
                //if (last_waiter)
                //{
                //    _waiters_done.Set();
                //}

                // reacquire the lock on exit
                Monitor.Enter(obj);
            }

        }

        public void Pulse()
        {
            bool have_waiters = false;
            lock(_waiters_lock)
            {
                have_waiters = _waiters > 0;
            }

            if (have_waiters)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} allow one thread to handle signal from CV");
                sem.Release();
            }
        }
        
    }
}
