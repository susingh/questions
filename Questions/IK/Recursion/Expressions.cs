using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Questions.IK.Recursion
{
    class Expressions
    {
        private class ExpressionItemNode
        {
            public long? val;
            public char? operand;
            public ExpressionItemNode next;
            public ExpressionItemNode prev;
        }

        public static string[] generate_all_expressions(string s, long target)
        {
            List<string> result = new List<string>();
            char[] arr = new char[s.Length * 2 - 1];
            generate_all_expressions(s, 0, arr, 0, target, result);
            return result.ToArray();
        }

        private static void generate_all_expressions(string s, int i, char[] arr, int j, long target, List<string> result)
        {
            arr[j] = s[i];

            if (i == s.Length - 1)
            {
                long currVal = Evaluate(arr, j);

                if (currVal == target)
                {
                    result.Add(GetString(arr, j));
                }

                return;
            }
            else
            {
                j++;

                arr[j] = '"';
                generate_all_expressions(s, i + 1, arr, j + 1, target, result);

                arr[j] = '*';
                generate_all_expressions(s, i + 1, arr, j + 1, target, result);

                arr[j] = '+';
                generate_all_expressions(s, i + 1, arr, j + 1, target, result);

            }
        }

        private static ExpressionItemNode BuildList(char[] arr, int j)
        {
            ExpressionItemNode curr = null;

            for (int i = 0; i <= j; i++)
            {
                var node = new ExpressionItemNode
                {
                    prev = curr,
                    next = null,
                    val = char.IsDigit(arr[i]) ? (int)char.GetNumericValue(arr[i]) : (long?)null,
                    operand = !char.IsDigit(arr[i]) ? arr[i] : (char?)null
                };

                if (curr != null)
                {
                    curr.next = node;
                }

                curr = node;
            }

            // move to head
            while (curr.prev != null)
            {
                curr = curr.prev;
            }

            return curr;
        }

        private static long Evaluate(char[] arr, int j)
        {
            ExpressionItemNode head = BuildList(arr, j);

            char[] operands = new char[] { '"', '*', '+' };

            ExpressionItemNode curr = head;
            for (int i = 0; i < operands.Length; i++)
            {
                curr = head;
                while (curr != null)
                {
                    if (curr.operand.HasValue && curr.operand == operands[i])
                    {
                        // merge the previous and the next nodes
                        var prev = curr.prev;
                        var next = curr.next;
                        long finalValue = 0;

                        if (operands[i] == '"')
                        {
                            string concated = $"{prev.val}{next.val}";
                            finalValue = long.Parse(concated);
                        }
                        else if (operands[i] == '*')
                        {
                            finalValue = prev.val.Value * next.val.Value;
                        }
                        else
                        {
                            finalValue = prev.val.Value + next.val.Value;
                        }

                        // delete the curr and next nodes
                        prev.val = finalValue;
                        prev.next = next.next;

                        if (next.next != null)
                        {
                            next.next.prev = prev;
                        }

                        // reset the curr node
                        curr = prev;

                    }

                    curr = curr.next;
                }
            }

            return head.val.Value;
        }

        private static string GetString(char[] arr, int j)
        {
            // 2"2+2 = 22+2
            List<char> result = new List<char>();

            for (int i = 0; i <= j; i++)
            {
                if (arr[i] != '"')
                {
                    result.Add(arr[i]);
                }
            }

            return new string(result.ToArray());
        }
    }
}
