using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
    class Trees : IQuestion
    {
        static bool isBST(TreeNode node)    
        {
            List<int> array = new List<int>();
            inorderTraversal(node, array);
            return isSorted(array);
        }

        static bool isSorted(List<int> array)
        {
            int max = int.MinValue;
            foreach (var item in array)
            {
                if (max > item)
                    return false;

                max = item;
            }

            return true;
        }

        static void inorderTraversal(TreeNode node, List<int> array)
        {
            if (node == null)
            {
                return;
            }

            inorderTraversal(node.left, array);
            array.Add(node.val);
            inorderTraversal(node.right, array);
        }

        TreeNode BstInsert(TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }

            if (root.val > value)
            {
                root.left = BstInsert(root.left, value);
            }
            else
                root.right = BstInsert(root.right, value);

            return root;
        }

        static void printAllPaths(TreeNode node)
        {
            int[] list = new int[100];
            printAllPaths(node, list, 0);
        }

        static void printAllPaths(TreeNode node, int[] array, int curr)
        { 
            if (node == null)
            {
                return;
            }

            array[curr] = node.val;

            if (node.left == null && node.right == null)
            {
                PrintPath(array, curr);
                return;
            }

            printAllPaths(node.left, array, curr + 1);
            printAllPaths(node.right, array, curr + 1);
        }

        static void PrintPath(int[] array, int curr)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i <= curr; i++)
            {
                builder.Append(array[i]);

                if (i + 1 <= curr)
                {
                    builder.Append(" ");
                }
            }

            Console.WriteLine(builder.ToString());
        }

        static void BstToDLL(TreeNode root)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            inorderTraversal(root, nodeList);
            AdjustLinks(nodeList);

            nodeList[0].left = nodeList[nodeList.Count - 1];
            nodeList[nodeList.Count - 1].right = nodeList[0];

            root = nodeList[0];
        }

        static void Print(List<TreeNode> nodeList)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nodeList.Count - 1; i++)
            {
                builder.Append(nodeList[i].val + " ");
            }

            builder.Append(nodeList[nodeList.Count - 1].val);
            Console.WriteLine(builder.ToString());
        }

        static void AdjustLinks(List<TreeNode> nodeList)
        {
            for (int i = 1; i < nodeList.Count; i++)
            {
                nodeList[i].left = nodeList[i - 1];
            }

            for (int i = 0; i < nodeList.Count - 1; i++)
            {
                nodeList[i].right = nodeList[i + 1];
            }
        }

        static void inorderTraversal(TreeNode node, List<TreeNode> nodeList)
        {
            if (node == null)
            {
                return;
            }

            inorderTraversal(node.left, nodeList);
            nodeList.Add(node);
            inorderTraversal(node.right, nodeList);
        }

        //static TreeNode findLCA(TreeNode node, int n1, int n2)
        //{
        //    TreeNode[] n1Path = new TreeNode[100];
        //    TreeNode[] n2Path = new TreeNode[100];

        //    findLCA(node, n1, n1Path);
        //    findLCA(node, n2, n2Path);

        //    return findAncestor(n1Path, n2Path);
        //}

        private static TreeNode findAncestor(List<TreeNode> n1Path, List<TreeNode> n2Path)
        {
            throw new NotImplementedException();
        }

        static void findLCA(TreeNode node, int n, TreeNode[] path, int curr)
        {
            if (node == null) return;

            if (node.val == n)
            {
                
                return;
            }

            path[curr] = node;

            findLCA(node.left, n, path, curr + 1);
            findLCA(node.right, n, path, curr + 1);
        }

        static int kth_smallest_element(TreeNode root, int k)
        {
            List<int> arr = new List<int>();
            //inorderTraversal(root, arr, k);
            return arr[k - 1];
        }

        //static int inorderTraversal(TreeNode root, List<int> arr, int k)
        //{
        //    if (root != null)
        //    {
        //        inorderTraversal(root.left, arr, k);
        //        arr.Add(root.val);
        //        k--;
        //        if (k == 0)
        //        {
        //            return root.val;
        //        }
        //        inorderTraversal(root.right, arr, k);
        //    }
        //}

        static TreeNode build_balanced_bst(int[] a)
        {
            return buildTree(a, 0, a.Length - 1);
        }

        static TreeNode buildTree(int[] a, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            if (start == end)
            {
                return new TreeNode(a[start]);
            }

            int mid = start + (end - start) / 2;
            TreeNode root = new TreeNode(a[mid]);
            root.left = buildTree(a, start, mid - 1);
            root.right = buildTree(a, mid + 1, end);

            return root;
        }

        static string[] string_transformation(string[] words, string start, string stop)
        {
            IDictionary<string, HashSet<string>> adjList = BuildGraph(words.Concat(new string[] { start, stop }));
            return doBFS(adjList, start, stop);
        }

        static string[] doBFS(IDictionary<string, HashSet<string>> adjList, string start, string stop)
        {
            // add to seen when we have process a node completely, visited the node and added the children to the queue
            // add to seen when we have visited the node only

            HashSet<string> seen = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            IDictionary<string, string> paths = new Dictionary<string, string>();

            queue.Enqueue(start);
            seen.Add(start);
            paths.Add(start, start);
            
            while (queue.Count > 0)
            {
                string curr = queue.Dequeue();
                
                if (!string.IsNullOrEmpty(curr))
                {
                    if (curr == stop)
                    {
                        return GeneratePath(paths, start, stop);
                    }

                    foreach (var item in adjList[curr])
                    {
                        if (seen.Contains(item)) continue;

                        queue.Enqueue(item);
                        seen.Add(item);
                        paths.Add(item, curr);
                    }
                }
            }

            return new string[] { "-1" };
        }

        static string[] GeneratePath(IDictionary<string, string> paths, string start, string stop)
        {
            List<string> list = new List<string>();

            string curr = stop;

            while (curr != start)
            {
                list.Add(curr);
                curr = paths[curr];
            }

            list.Add(start);

            list.Reverse();
            return list.ToArray();
        }

        static IDictionary<string, HashSet<string>> BuildGraph(IEnumerable<string> words)
        {
            IDictionary<string, HashSet<string>> adjList = new Dictionary<string, HashSet<string>>();

            foreach (var i in words)
            {
                if (!adjList.ContainsKey(i))
                {
                    adjList.Add(i, new HashSet<string>());

                    foreach (var j in words)
                    {
                        if (i == j) continue;

                        if (isNeighbor(j, i))
                        {
                            adjList[i].Add(j);
                        }
                    }
                }
            }

            return adjList;
        }

        static bool isNeighbor(string a, string b)
        {
            int count = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    count++;

                if (count > 1) return false;
            }

            return true;
        }

        static TreeNode mergeTrees(TreeNode node1, TreeNode node2)
        {
            List<int> list1 = new List<int>();
            InorderTraversal(node1, list1);
            List<int> list2 = new List<int>();
            InorderTraversal(node2, list2);
            List<int> final = mergeArray(list1, list2);
            return buildTree(final.ToArray(), 0, final.Count - 1);
        }

        static List<int> mergeArray(List<int> list1, List<int> list2)
        {
            List<int> final = new List<int>();

            int i = 0, k = 0;
            while (i < list1.Count && k < list2.Count)
            {
                if (list1[i] > list2[k])
                {
                    final.Add(list2[k]);
                    k++;
                }
                else
                {
                    final.Add(list1[i]);
                    i++;
                }
            } 

            while (i < list1.Count)
            {
                final.Add(list1[i]);
                i++;
            }

            while (k < list2.Count)
            {
                final.Add(list2[k]);
                k++;
            }

            return final;
        }

        static void InorderTraversal(TreeNode node, List<int> nodeList)
        {
            if (node == null)
            {
                return;
            }

            InorderTraversal(node.left, nodeList);
            nodeList.Add(node.val);
            InorderTraversal(node.right, nodeList);
        }

        static TreeNode findLCA(TreeNode node, int n1, int n2)
        {
            if (node == null)
            {
                return null;
            }

            bool isN1Left = isPresent(node.left, n1);
            bool isN2Left = isPresent(node.left, n2);

            if (isPresent(node.left, n1) && isPresent(node.left, n2))
            {
                return findLCA(node.left, n1, n2);
            }
            else if (isPresent(node.right, n1) && isPresent(node.right, n2))
            {
                return findLCA(node.right, n1, n2);
            }
            else
            {
                return node;
            }
        }

        static bool isPresent(TreeNode node, int val)
        {
            if (node == null)
            {
                return false;
            }

            if (node.val == val)
            {
                return true;
            }

            return isPresent(node.left, val) | isPresent(node.right, val);
        }


        public void Run()
        {
            TreeNode root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(7)
                },
                right = new TreeNode(15)
                {
                    left = new TreeNode(12),
                    right = new TreeNode(20)
                }
            };

            TreeNode root2 = new TreeNode(14)
            {
                left = new TreeNode(7)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(10)
                },
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(25)
                }
            };

            //var result = isBST(root);
            // printAllPaths(root);
            // BstToDLL(root);
            //var result = kth_smallest_element(root, 5);
            //var result = build_balanced_bst(new int[] { 4, 5, 7, 10, 12, 15, 20 });
            //var result = string_transformation(new string[] { "cat", "hat", "bad", "had" }, "bat", "had");

            //var result = mergeTrees(root, root2);
            var result = findLCA(root, 4, 7);

        }
    }
}
