using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Models
{
    public class TrieNode
    {
        public bool isEOW;
        public Dictionary<char, TrieNode> Children;

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
    }
}