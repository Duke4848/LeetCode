using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class WordDictionary
    {
        private Node Root { get; set; }

        public WordDictionary()
        {
            Root = new Node();
        }

        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            var curr = Root;
            foreach (var ch in word)
            {
                if (!curr.Children.ContainsKey(ch))
                {
                    curr.Children[ch] = new Node();
                }
                curr = curr.Children[ch];
            }

            curr.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            return Search(word, 0, Root);
        }

        private bool Search(string word, int index, Node node)
        {
            if (index == word.Length)
            {
                return node.IsEndOfWord;
            }

            char ch = word[index];

            if (ch == '.')
            {
                foreach (var child in node.Children.Values)
                {
                    if (Search(word, index + 1, child))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }

                return Search(word, index + 1, node.Children[ch]);
            }
        }

        public void PrintTree2()
        {
            var d = new Dictionary<int, List<char>>();
            for (int i = 0; i < 10; i++)
            {
                d[i] = new List<char>();
            }
            Stack<(Node, int)> stack = new Stack<(Node, int)>();
            stack.Push((Root, 0));

            while (stack.Count > 0)
            {
                var (next, curLevel) = stack.Pop();

                foreach (var kv in next.Children)
                {
                    d[curLevel].Add(kv.Key);
                    stack.Push((kv.Value, curLevel + 1));
                }
            }

            foreach (var keyValuePair in d)
            {
                Console.WriteLine(keyValuePair.Key + " " + string.Join(' ', keyValuePair.Value));
            }
        }
    }

    public class Node
    {
        public Dictionary<char, Node> Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public Node()
        {
            Children = new Dictionary<char, Node>();
            IsEndOfWord = false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");
            wordDictionary.PrintTree2();
            Console.WriteLine(wordDictionary.Search("pad")); // return False
            Console.WriteLine(wordDictionary.Search("bad")); // return True
            Console.WriteLine(wordDictionary.Search(".ad")); // return True
            Console.WriteLine(wordDictionary.Search("b..")); // return True
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary(); obj.addWord(word); boolean param_2 = obj.search(word);
 */