using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Questions.IK.Concurrency
{
    public class ProducerConsumerDriver : IQuestion
    {
        public void Run()
        {
            ProduceConsumerQueue pcq = new ProduceConsumerQueue(5);

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    pcq.Produce(i);
                }
            })
            {
                Name = "Producer"
            };

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(2000);
                    var val = pcq.Consume();
                }
            })
            {
                Name = "Consumer"
            };

            t2.Start();
            t1.Start();
            t2.Join();
            t1.Join();
        }
    }

    class ProduceConsumerQueue
    {
        private Queue<object> q;
        private int _maxSize;
        private int _count;

        public ProduceConsumerQueue(int maxSize)
        {
            q = new Queue<object>();
            _maxSize = maxSize;
            _count = 0;
        }

        public void Produce(object o)
        {
            lock(q)
            {
                while (_count == _maxSize)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} waiting for queue to be not full");
                    Monitor.Wait(q);
                }

                q.Enqueue(o);
                _count++;
                Monitor.Pulse(q);
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} adding item");
        }

        public object Consume()
        {
            object o = null;

            lock(q)
            {
                while (_count == 0)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} waiting for queue to be not empty");
                    Monitor.Wait(q);
                }

                o = q.Dequeue();
                _count--;
                Monitor.Pulse(q);
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} removing item");
            return o;
        }
    }
}
