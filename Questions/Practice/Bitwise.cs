using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Practice
{
    public class Bitwise : IQuestion
    {
        public void Execute()
        {
            int i = 1;
            Console.WriteLine(~i);

            i = -1;
            Console.WriteLine(i >> 1);
            Console.WriteLine(i >> 1);

        }

        public void Run()
        {
            Execute();
        }
    }
}
