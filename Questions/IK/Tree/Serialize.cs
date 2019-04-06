using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class Serialize
    {
        public static List<int> SerializeBST (TreeNode root)
        {
            List<int> result = new List<int>();
            SerializeBST(root, result);
            return result;
        }

        public static TreeNode DeserializeBST(List<int> arr)
        {
            return DeserializeBST(arr, 0, arr.Count - 1);
        }

        private static TreeNode DeserializeBST(List<int> arr, int l, int r)
        {
            if (l > r)
                return null;

            TreeNode root = new TreeNode(arr[l]);

            int j = l;
            while (j + 1 <= r)
            {
                if (arr[j + 1] < arr[l])
                {
                    j++;
                }
                else
                {
                    break;
                }
            }

            root.left = DeserializeBST(arr, l+1, j);
            root.right = DeserializeBST(arr, j + 1, r);

            return root;
        }

        private static void SerializeBST(TreeNode root, List<int> result)
        {
            if (root == null)
                return;

            result.Add(root.val);
            SerializeBST(root.left, result);
            SerializeBST(root.right, result);
        }

        public static List<int> SerializeCompleteBT(TreeNode root)
        {
            List<int> result = new List<int>();
            result.Add(-1);

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                var curr = q.Dequeue();
                result.Add(curr.val);

                if (curr.left != null)
                {
                    q.Enqueue(curr.left);
                }

                if (curr.right != null)
                {
                    q.Enqueue(curr.right);
                }
            }

            return result;
        }

        public static TreeNode DeserializeCompleteBT(List<int> arr)
        {
            return DeserializeCompleteBT(arr, 1);
        }

        private static TreeNode DeserializeCompleteBT(List<int> arr, int i)
        {
            if (i >= arr.Count)
                return null;

            TreeNode root = new TreeNode(arr[i]);
            root.left = DeserializeCompleteBT(arr, 2 * i);
            root.right = DeserializeCompleteBT(arr, 2 * i  + 1);

            return root;
        }

        public static List<int> SerializeBT(TreeNode root)
        {
            List<int> result = new List<int>();
            SerializeBT(root, result);
            return result;
        }

        private static void SerializeBT(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                result.Add(-1);
                return;
            }

            result.Add(root.val);
            SerializeBT(root.left, result);
            SerializeBT(root.right, result);
        }

        public static TreeNode DeserializeBT(List<int> arr)
        {
            TreeNode root = new TreeNode(arr[0]);

            int i = 1;
            TreeNode curr = root;
            while (i < arr.Count)
            {
                if (arr[i] == -1)
                    curr.left = null;
                else
                    curr.left = new TreeNode(arr[i]);

                i++;

                if (arr[i] == -1)
                    curr.right = null;
                else
                    curr.right = new TreeNode(arr[i]);
                 
                i++;
            }

            return root;
        }
    }
}
