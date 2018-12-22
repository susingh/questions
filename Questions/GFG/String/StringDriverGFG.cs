using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.String
{
    class StringDriverGFG : IQuestion
    {
        public void Run()
        {
            //var sol = ReverseSpecialString.Reverse("a!!!b.c.d,e'f,ghi");
            // var sol = CountTriplets.Count(new int[] { 5, 1, 3, 4, 7 }, 12);
            //ZigZag.Convert(new int[] { 4, 3, 7, 1, 8, 6, 2 });
            ZigZag.Convert(new int[] { 1, 4, 3, 2});
        }
    }
}
