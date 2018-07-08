using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Questions.IK
{

    public class ReaderWriterLockDriver : IQuestion
    {
        ReaderWriterLock rw = new ReaderWriterLock();
        List<string> _items = new List<string>();

        void Write(object value)
        {
            rw.EnterWriterLock();
            _items.Add(value.ToString());
            rw.ExitWriterLock();

            Console.WriteLine(value + " was added");
            Thread.Sleep(100);
        }

        void Read()
        {
            rw.EnterReaderLock();

            foreach (string i in _items)
                Thread.Sleep(100);

            rw.ExitReaderLock();
        }

        public void Run()
        {
            new Thread(Write) { Name = "W1" }.Start("thread a");
            new Thread(Write) { Name = "W2" }.Start("thread b");

            new Thread(Read) { Name = "R1" }.Start();
            new Thread(Read) { Name = "R2" }.Start();
            new Thread(Read) { Name = "R3" }.Start();
            new Thread(Read) { Name = "R4" }.Start();
            new Thread(Read) { Name = "R5" }.Start();
            new Thread(Read) { Name = "R6" }.Start();

            Thread.Sleep(100);

            new Thread(Write) { Name = "W3" }.Start("thread c");
            new Thread(Write) { Name = "W4" }.Start("thread d");
        }
    }

    public class ReaderWriterLock
    {
        int _reader_count;
        //private readonly object _reader_lock = new object();

        SemaphoreSlim _reader_lock = new SemaphoreSlim(1, int.MaxValue);
        SemaphoreSlim _writer_lock = new SemaphoreSlim(1);

        public void EnterReaderLock()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Adding readers");

            _reader_lock.Wait();

            ++_reader_count;
            if (_reader_count == 1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Blocking writers");
                _writer_lock.Wait();
            }

            _reader_lock.Release();
        }

        public void ExitReaderLock()
        {
            _reader_lock.Wait();

            --_reader_count;
            if (_reader_count == 0)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Releasing writers");
                _writer_lock.Release();
            }

            _reader_lock.Release();
            Console.WriteLine($"{Thread.CurrentThread.Name} Removed reader");
        }

        public void EnterWriterLock()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Adding writer");
            _writer_lock.Wait();
            _reader_lock.Wait();
            
        }

        public void ExitWriterLock()
        {
            _writer_lock.Release();
            _reader_lock.Release();
            Console.WriteLine($"{Thread.CurrentThread.Name} Removed writer");
        }
    }
}
