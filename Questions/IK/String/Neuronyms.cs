using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class Neuronyms_IK
    {
        public static string[] neuronyms(string word)
        {
            List<string> result = new List<string>();

            if (word.Length > 2)
            {
                int maxWindow = word.Length - 2;
                int currWindow = maxWindow;

                string trimmedWord = word.Substring(1, maxWindow);

                while (currWindow > 1)
                {
                    int windowStart = 0;
                    int windowEnd = windowStart + currWindow - 1;

                    // slide the window, until the right edge hits the max range
                    while (windowEnd < trimmedWord.Length)
                    {
                        StringBuilder build = new StringBuilder();
                        build.Append(word[0]);
                        
                        if (windowStart - 1 >= 0)
                        {
                            string beforeWindow = trimmedWord.Substring(0, windowStart);
                            build.Append(beforeWindow);
                        }

                        build.Append(currWindow);

                        if (windowEnd + 1 < trimmedWord.Length)
                        {
                            string afterWindow = trimmedWord.Substring(windowEnd + 1);
                            build.Append(afterWindow);
                        }

                        build.Append(word[word.Length - 1]);

                        result.Add(build.ToString());

                        windowStart++;
                        windowEnd++;
                    }

                    currWindow--;
                }
            }

            return result.ToArray();
        }
    }
}
