using System.Collections.Generic;

namespace Questions.IK.LinkedList
{
    class LRUCache
    {
        private class CacheNode
        {
            public int Key;
            public int Value;
            public CacheNode Next;
            public CacheNode Previous;
        }

        private Dictionary<int, CacheNode> map;
        private CacheNode head = null;
        private CacheNode tail = null;
        private int totalCount = 0;
        private int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            map = new Dictionary<int, CacheNode>();
        }

        public int? Get(int key)
        {
            CacheNode node;
            if (map.TryGetValue(key, out node))
            {
                // move the item to front of the LL;
                DeleteEntry(node);
                AddToFront(node);

                return node.Value;
            }

            return null;
        }

        public void Set(int key, int value)
        {
            CacheNode node;
            if (map.TryGetValue(key, out node))
            {
                // update the value
                node.Value = value;

                // move the item to front of the LL;
                DeleteEntry(node);
                AddToFront(node);
            }
            else
            {
                totalCount++;

                var newNode = new CacheNode()
                {
                    Key = key,
                    Value = value,
                };

                AddToFront(newNode);
                map.Add(newNode.Key, newNode);

                if (totalCount > _capacity)
                {
                    // evict the cache
                    map.Remove(tail.Key);
                    DeleteEntry(tail);
                    totalCount = _capacity;
                }
            }
        }
        
        private void DeleteEntry(CacheNode entry)
        {
            CacheNode next = entry.Next;
            CacheNode prev = entry.Previous;

            if (entry == head)
            {
                head = next;
            }
            else
            {
                prev.Next = next;
            }

            if (entry == tail)
            {
                tail = prev;
            }
            else
            {
                next.Previous = prev;
            }
            
            entry.Next = null;
            entry.Previous = null;
        }

        private void AddToFront(CacheNode entry)
        {
            if (head == null)
            {
                head = entry;
                tail = entry;
            }
            else
            {
                entry.Next = head;
                head.Previous = entry;
                entry.Previous = null;
                head = entry;
            }
        }

        public static int[] implement_LRU_cache(int capacity, int[] query_type, int[] key, int[] value)
        {
            List<int> getOperationValues = new List<int>();
            LRUCache cache = new LRUCache(capacity);

            for (int i = 0; i < query_type.Length; i++)
            {
                if (query_type[i] == 0) //GET
                {
                    int? keyValue = cache.Get(key[i]);
                    getOperationValues.Add(keyValue.HasValue ? keyValue.Value : -1);
                }
                else // SET
                {
                    cache.Set(key[i], value[i]);
                }
            }

            return getOperationValues.ToArray();
        }
    }
}
