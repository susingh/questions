using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Questions.IK.Concurrency
{
    class ObjectPool
    {
        Queue<object> _pool;
        int _allocated = 0;
        int _maxSize = 0;
        
        public ObjectPool(int maxSize)
        {
            _pool = new Queue<object>();
            _maxSize = maxSize;
            _allocated = 0;
        }

        public void Free(object c)
        {
            lock(_pool)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} returning objects back to the pool");
                _pool.Enqueue(c);
                Monitor.Pulse(_pool);
            }
        }

        public object Get()
        {
            lock(_pool)
            {
                while (_pool.Count == 0 && _allocated == _maxSize)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} waiting for pool to be not empty");
                    Monitor.Wait(_pool);
                }

                object o;
                if (_pool.Count > 0)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} picking object from the pool");
                    o = _pool.Dequeue();
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} allocating new objects on the pool");
                    o = new object();
                    _allocated++;
                }

                return o;
            }
        }
    }

    public class ObjectPoolDriver : IQuestion
    {
        public void Run()
        {
            var op = new ObjectPool(5);

            new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    op.Get();
                }
            })
            {
                Name = "T1"
            }.Start();

            new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(1000);
                    op.Free(1);
                }
            })
            {
                Name = "T2"
            }.Start();
        }
    }
}
