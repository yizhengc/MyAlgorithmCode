using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class CacheNode
    {
        public int Value;
        public int Key;
        public CacheNode Next;
        public CacheNode Prev;

        public CacheNode()
        {
            Value = Key = 0;
            Next = Prev = null;
        }
        
        public CacheNode(int key, int val)
        {
            Next = Prev = null;
            Value = val;
            Key = key;
        }
    }

    public class LRUCache
    {
        private Dictionary<int, CacheNode> map = new Dictionary<int, CacheNode>();
        private int maxCacheSize = 0;
        private CacheNode head = new CacheNode();
        private CacheNode tail;

        public LRUCache(int size)
        {
            tail = head;
            maxCacheSize = size;
        }

        public CacheNode GetCache(int key)
        {
            if (map.ContainsKey(key))
            {
                CacheNode node = map[key];

                if (node != head.Next)
                {
                    if (tail == node)
                    {
                        tail = node.Prev;
                        tail.Next = null;
                    }

                    node.Next = head.Next;
                    node.Prev = head;
                    head.Next = node;
                    if (node.Next != null)
                        node.Next.Prev = node;

                }

                return node;
            }

            return null;
        }

        public void AddCache(int key, int val)
        {
            CacheNode node = new CacheNode(key, val);

            node.Next = head.Next;
            node.Prev = head;
            head.Next = node;
            if (node.Next != null)
                node.Next.Prev = node;

            if (tail == head)
            {
                tail = head.Next;
            }

            map.Add(key, node);

            if (map.Count > maxCacheSize)
            {
                map.Remove(tail.Key);
                tail = tail.Prev;
                tail.Next = null;
            }
        }

        public void ShowCache()
        {
            CacheNode cur = head.Next;
            while (cur != null)
            {
                Console.Write(cur.Value);
                Console.Write(" ");
                cur = cur.Next;
            }

            Console.Write("\n");
        }

        public static void UnitTest()
        {
            LRUCache cache = new LRUCache(3);

            cache.AddCache(1, 1);
            cache.AddCache(2, 2);
            cache.AddCache(3, 3);
            cache.GetCache(1);

            cache.ShowCache();

            cache.AddCache(4, 4);
            cache.AddCache(5, 5);
            cache.AddCache(6, 6);

            cache.ShowCache();
        }
    }
}
