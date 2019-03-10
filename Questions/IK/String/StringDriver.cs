using Questions.DataStructures;
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
                 // = PatternMatch.KMP("aaaaaab", "CCCDCCCCCD");
                 // = new PrefixTree();
                 // = SubstringSearch.FindMatch("aaaaaab", "a");
                 // = Neuronyms_IK.neuronyms("nailed");
                 = ShortestSubstringContainingSet.FindSubstring("AYZABOBECODXBANC", new char[] { 'A', 'B', 'C' });

            //sol.Add("CAT");
            //sol.Add("DOLL");
            //sol.Add("DOG");
            //sol.Add("DOGGY");
            //sol.Add("CUT");
            //sol.Add("CAN");

            //var result = sol.Find("DOT");
            //result = sol.Find("DOLL");

            //var arr = sol.PrefixMatch("DOG");
        }
    }
}
