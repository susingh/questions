using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class ValidExpression
    {
        private static bool IsOp(char c)
        {
            return c == '+' || c == '-' || c == '*';
        }

        private static bool IsOpenBracket(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        public static bool HasMatchingParantheses(string exp)
        {
            Stack<char> ops = new Stack<char>();
            Stack<int> val = new Stack<int>();

            for (int i = 0; i < exp.Length; i++)
            {
                if (char.IsDigit(exp[i]))
                {
                    val.Push(exp[i] - '0');
                }
                else if (IsOp(exp[i]))
                {
                    ops.Push(exp[i]);
                }
                else if (IsOpenBracket(exp[i]))
                {
                    ops.Push(exp[i]);
                }
                else
                {
                    // closing bracket

                    char open = GetOpenBracket(exp[i]);
                    bool found = false;
                    while (ops.Count > 0)
                    {
                        char op = ops.Pop();
                        if (op == open)
                        {
                            found = true;
                            break;
                        }
                        else if (IsOp(op))
                        {
                            if (val.Count < 2)
                            {
                                return false;
                            }
                            else
                            {
                                val.Pop();
                            }
                        }
                    }

                    if (!found)
                    {
                        return false;
                    }
                }
            }

            while (ops.Count > 0)
            {
                char op = ops.Pop();
                if (!IsOp(op))
                {
                    return false;
                }
                else
                {
                    if (val.Count < 2)
                    {
                        return false;
                    }
                    else
                    {
                        val.Pop();
;                   }
                }
            }

            if (val.Count != 1)
                return false;

            return true;
        }

        private static char GetOpenBracket(char c)
        {
            if (c == '}')
                return '{';
            else if (c == ')')
                return '(';
            else
                return '[';
        }
    }
}
