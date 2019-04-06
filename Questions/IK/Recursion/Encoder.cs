using System.Collections.Generic;

namespace Questions.IK.Recursion
{
    class Encoder
    {
        static Dictionary<string, char> map = new Dictionary<string, char>()
        {
            {  "1", 'a' },
            {  "2", 'b' },
            {  "3", 'c' },
            {  "4", 'd' },
            {  "5", 'e' },
            {  "6", 'f' },
            {  "7", 'g' },
            {  "8", 'h' },
            {  "9", 'i' },
            {  "10",'j' },
            {  "11",'k' },
            {  "12",'l' },
            {  "13",'m'},
            {  "14",'n' },
            {  "15",'o' },
            {  "16",'p' },
            {  "17",'q' },
            {  "18",'r'},
            {  "19",'s' },
            {  "20",'t' },
            {  "21",'u' },
            {  "22",'v' },
            {  "23",'w' },
            {  "24",'x' },
            {  "25",'y' },
            {  "26",'z' },
        };

        public static int FindEncodingTypes(string a)
        {
            List<string> result = new List<string>();
            char[] arr = new char[a.Length];
            FindEncodingTypes(a, 0, arr, 0, result);
            return result.Count;
        }

        private static string GetString(char[] arr, int i)
        {
            return new string(arr, 0, i + 1);
        }

        private static void FindEncodingTypes(string s, int k, char[] arr, int i, List<string> result)
        {
            if (k >= s.Length)
            {
                result.Add(GetString(arr, i-1));
                return;
            }

            if (k < s.Length)
            {
                string temp = s.Substring(k, 1);
                arr[i] = map[temp];
                FindEncodingTypes(s, k + 1, arr, i + 1, result);
            }

            if (k < s.Length - 1)
            {
                string temp = s.Substring(k, 2);
                arr[i] = map[temp];
                FindEncodingTypes(s, k + 2, arr, i + 1, result);
            }
        }
    }
}