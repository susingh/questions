using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Maths
{
    class MathDriver : IQuestion
    {
        public void Run()
        {
            var sol = Primality.PrimalityCheck(19);
        }
    }
}
