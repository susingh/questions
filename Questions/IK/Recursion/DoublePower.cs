using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class DoublePower
    {
        public static float pow(float dblbase, int ipower)
        {
            bool isNegative = false;
            if (ipower < 0)
            {
                isNegative = true;
                ipower = ipower * -1;
            }

            float result = pow(dblbase, 1, ipower);

            if (isNegative)
            {
                result = 1.0f/ result;
            }

            return result;
        }

        private static float pow(float dblbase, float valueSoFar, int power)
        {
            if (power == 0)
            {
                return 1.0f;
            }

            return pow(dblbase * valueSoFar, power - 1);
        }
    }
}
