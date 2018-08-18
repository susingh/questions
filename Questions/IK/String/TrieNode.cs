using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public bool isEow;

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
    }
}
