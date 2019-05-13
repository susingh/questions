using System.Collections.Generic;

namespace Questions.IK.LinkedList
{
    class EvaluateExpression
    {
        /*
         *  string example_one = "1 + 2 * 3";
            string example_two = "-1.2 + 3.6";
            string example_three = "((2 + 3) * 2 / 10)";
        */

        private static float Eval(char op, float a, float b)
        {
            switch(op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }

            return 0;
        }

        /// <summary>
        /// Is right operator of higher or same precedence?
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool IsRightHigherPrecedence(char a, char b)
        {
            if (b == '(')
            {
                return false;
            }
            else if ((a == '*' || a == '/') && (b == '+' || b == '-'))
            {
                return false;
            }

            return true;
        }

        public static float Evaluate(string str)
        {
            // tokenize the string
            char[] arr = str.ToCharArray();

            Stack<char> ops = new Stack<char>();
            Stack<float> vals = new Stack<float>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ' ')
                {
                    continue;
                }
                else if (char.IsDigit(arr[i]) || arr[i] == '-' || arr[i] == '.')
                {
                    int k = i;
                    while (k < arr.Length && (char.IsDigit(arr[k]) || arr[k] == '-' || arr[k]== '.'))
                    {
                        k++;
                    }

                    k--;

                    float val = float.Parse(new string(arr, i, k - i + 1));
                    vals.Push(val);
                    i = k;
                }
                else if (arr[i] == '(')
                {
                    ops.Push(arr[i]);
                }
                else if (arr[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        float a = vals.Pop();
                        float b = vals.Pop();
                        char op = ops.Pop();

                        vals.Push(Eval(op, a, b));
                    }

                    ops.Pop();
                }
                else
                {
                    while (ops.Count > 0 && IsRightHigherPrecedence(arr[i], ops.Peek()))
                    {
                        float a = vals.Pop();
                        float b = vals.Pop();
                        char op = ops.Pop();

                        vals.Push(Eval(op, a, b));
                    }

                    ops.Push(arr[i]);
                }
            }

            while (ops.Count != 0)
            {
                float a = vals.Pop();
                float b = vals.Pop();
                var op = ops.Pop();

                vals.Push(Eval(op, a, b));
            }

            return vals.Pop();
        }
    }
}