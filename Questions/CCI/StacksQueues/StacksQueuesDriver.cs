using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.StacksQueues
{
    class StacksQueuesDriver : IQuestion
    {
        public void Run()
        {
            Stack input = new Stack();
            input.Push(5);
            input.Push(10);
            input.Push(3);
            input.Push(1);
            input.Push(4);

            //var sol = SortStack.Sort(input);
            var sol = new MinStack();
            sol.Push(7);
            Console.WriteLine(sol.Min());
            sol.Push(10);
            Console.WriteLine(sol.Min());
            sol.Push(5);
            Console.WriteLine(sol.Min());
            sol.Push(1);
            Console.WriteLine(sol.Min());
            sol.Push(2);
            Console.WriteLine(sol.Min());
        }
    }
}
