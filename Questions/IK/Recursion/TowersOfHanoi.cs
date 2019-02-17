using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class Tower
    {
        public string Name;
        public Stack<int> stack { get; set; }
        public Tower(string name)
        {
            stack = new Stack<int>();
            Name = name;
        }
    }


    class TowersOfHanoi
    {
        public void Move(int n)
        {
            Tower src = new Tower("S");
            Tower dest = new Tower("D");
            Tower temp = new Tower("T");

            Move(n, src, dest, temp);
        }

        private void Move(int m, Tower src, Tower dest, Tower temp)
        {
            // base case
            if (m == 0) return;

            Move(m - 1, src, temp, dest);
            MoveDisk(m, src, dest);
            Move(m - 1, temp, dest, src);
        }

        private void MoveDisk(int m, Tower src, Tower dest)
        {
            Console.Write($"Moving disk {m} from {src.Name} to {dest.Name}");
            dest.stack.Push(src.stack.Pop());
        }
    }
}