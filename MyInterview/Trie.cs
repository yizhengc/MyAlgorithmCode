using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MyInterview
{
    class Trie
    {
        class TrieNode
        {
            public char Key;
            public bool IsEnd;
            Dictionary<char, TrieNode> Children;

            public TrieNode(char key)
            {
                Key = key;
                IsEnd = false;
                Children = null;
            }

            public void Add(TrieNode node)
            {
                if (Children == null)
                    Children = new Dictionary<char, TrieNode>();

                if (!Children.ContainsKey(node.Key))
                    Children.Add(node.Key, node);
            }

            public bool Contains(char key)
            {
                return Children != null && Children.ContainsKey(key);
            }

            public TrieNode GetChild(char key)
            {
                return Children[key];
            }
        }

        TrieNode root = new TrieNode(' ');


        public void AddWord(string word)
        {
            TrieNode cur = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!cur.Contains(word[i]))
                {
                    cur.Add(new TrieNode(word[i]));
                }

                cur = cur.GetChild(word[i]);
            }

            cur.IsEnd = true;
        }

        public bool FindWord(string word)
        {
            TrieNode cur = root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!cur.Contains(word[i]))
                    return false;

                if (i == word.Length - 1 && cur.GetChild(word[i]).IsEnd)
                    return true;

                cur = cur.GetChild(word[i]);
            }

            return false;
        }

        public static void UnitTest()
        {
            Trie trie = new Trie();
            trie.AddWord("This");
            trie.AddWord("is");
            trie.AddWord("That");

            Debug.Assert(trie.FindWord("is"));
            Debug.Assert(trie.FindWord("That"));
            Debug.Assert(!trie.FindWord("the"));
        }
    }
}
