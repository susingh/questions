using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
    class _05102018
    {
        private class Node
        {
            public object value;
            public Node next;
            public Node prev;
        }

        private class LRUCache
        {
            IDictionary<string, Node> _map = new Dictionary<string, Node>();

            object Get(string key)
            {
                if (Exists(key))
                {
                    return _map[key].value;
                }

                return null;
            }

            void Put(string key, object value)
            {
                Node node;
                if (Exists(key))
                {
                    node = _map[key];
                }
                else
                {
                    if (_map.Count > Size())
                    {

                    }
                }
            }

            int Size()
            {
                return 0;//_maxSize;
            }

            void Remove(string key)
            {

            }

            bool Exists(string key)
            {
                return _map.ContainsKey(key);
            }

            void Evict(string key)
            {
                if (Exists(key))
                {

                }
            }
        }
    }
}
