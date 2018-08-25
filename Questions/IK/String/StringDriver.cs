using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class StringDriver : IQuestion
    {
        public void Run()
        {
            var sol
                 // = LongestSubstring.LRS("MISSISSIPPI");
                 //= LongestSubstring.LRS("abcpqrabpqpq");
                 = PatternMatch.KMP("AABAACAABAA", "AAB");
        }
    }
}
