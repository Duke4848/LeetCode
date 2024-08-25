namespace Trie
{

    public class WordDictionary
    {
        public Dictionary<int, HashSet<char>> Dict { get; set; }

        public WordDictionary()
        {
            Dict = new Dictionary<int, HashSet<char>>();
        }

        public void AddWord(string word)
        {
            HashSet<char> set;
            for (int i = 0; i < word.Length; i++)
            {
                Dict.TryGetValue(i, out set);
                if(set is null)
                {
                    set = new HashSet<char>();
                }
                set.Add(word[i]);
            }
        }

        public bool Search(string word)
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
