namespace Questions.IK.String
{
    class Atoi
    {
        public static int MyAtoi(string s)
        {
            bool sign = false;
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    continue;
                }
                else if (s[i] == '+')
                {
                    continue;
                }
                else if (s[i] == '-')
                {
                    sign = true;
                }
                else if (char.IsDigit(s[i]))
                {
                    int digit = s[i] - '0';

                    if (result > int.MaxValue / 10 ||
                        (result == int.MaxValue / 10 && digit > 7))
                    {
                        return sign ? int.MinValue : int.MaxValue;
                    }

                    result = 10 * result + digit;
                }
            }

            return sign ? result * -1 : result;
        }
    }
}
