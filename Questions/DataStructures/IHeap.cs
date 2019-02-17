using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.DataStructures
{
    public interface IHeap<T>
    {
        void Add(T value);
        T Delete();
        T Peek();
        void Heapify();
        int Count { get; }
    }
}
