namespace LeetCode
{
    public class WordDictionary
    {
        public const char ROOT_CHAR = (char)'@';
        public const char TERMINATE_WORD = '!';
        public Node Root { get; set; }

        public WordDictionary()
        {
            Root = new Node(ROOT_CHAR);
        }

        public void AddWord(string word)
        {
            if (word == null || word.Length == 0)
            {
                return;
            }

            var curr = Root;
            int i = 0;
            for (; i < word.Length; i++)
            {
                var matchedChild = curr.GetMatchingChild(word[i]);
                if (matchedChild == null)
                {
                    break;
                }
                curr = matchedChild;
            }

            for (; i < word.Length; i++)
            {
                var child = new Node(word[i]);
                curr.Children.Add(child);
                curr = child;
            }

            curr.Children.Add(new Node(TERMINATE_WORD));
        }

        public bool Search(String word)
        {
            if (word == null || word.Length == 0)
                return false;
            word += TERMINATE_WORD;

            return Search(Root, word, 0);

        }

        public bool Search(Node currentNode, string word, int i)
        {
            if (i == word.Length)
                return true;

            var matchedChildren = currentNode.GetMatchingChildren(word[i]);
            if (!matchedChildren.Any())
                return false;

            foreach (Node child in matchedChildren)
            {
                if(Search(child, word, i + 1))
                {
                    return true;
                }
            }
            return false;
        }
        public void PrintTree2()
        {
            var d = new Dictionary<int, List<char>>();
            for (int i = 0; i < 10; i++)
            {
                d[i] = new List<char>();
            }
            Stack<Node> stack = new Stack<Node>();
            Stack<int> nodeLevel = new Stack<int>();
            stack.Push(Root);
            nodeLevel.Push(0);

            while (stack.Count > 0)
            {
                Node next = stack.Pop();
                int curLevel = nodeLevel.Pop();

                d[curLevel].Add(next.C);

                //Console.WriteLine(curLevel + " " + next.C);

                foreach (Node c in next.Children)
                {
                    nodeLevel.Push(curLevel + 1);
                    stack.Push(c);
                }
            }

            foreach (var keyValuePair in d)
            {
                Console.WriteLine(keyValuePair.Key + " " + string.Join(' ', keyValuePair.Value));
            }
        }
    }

    public class Node : IComparable<Node>
    {
        public char C { get; set; }
        public List<Node> Children { get; set; }
        public Node(char c)
        {
            C = c;
            Children = new List<Node>();
        }

        public Node GetMatchingChild(char c)
        {
            return Children.FirstOrDefault(child => child.C == c);

        }

        public List<Node> GetMatchingChildren(char c)
        {
            if (c == '.')
                return Children.Where(n => n.C != WordDictionary.TERMINATE_WORD).ToList();

            return Children.Where(child => child.C == c).ToList();
        }

        public int CompareTo(Node? other)
        {
            return C - other.C;
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
 * WordDictionary obj = new WordDictionary(); obj.addWord(word); boolean param_2
 * = obj.search(word);
 */