namespace Leetcode438FindAllAnagrams
{
    public class Solution
    {
        public IList<int> FindAnagrams(string s1, string s2)
        {
            if (s1 == null || s2 == null || s1.Length < s2.Length)
            {
                return new List<int>();
            }
            var counters2 = CharCount(s2);
            var counters1 = CharCount(s1.Substring(0, s2.Length));
            var startIndexes = new List<int>();
            var i = 0;
            for (; i + s2.Length <= s1.Length; i++)
            {
                if (Enumerable.SequenceEqual(counters1, counters2))
                {
                    startIndexes.Add(i);
                }
                counters1[s1[i] - 'a']--;
                counters1[s1[i + s2.Length] - 'a']++;

            }
            if (Enumerable.SequenceEqual(counters1, counters2))
            {
                startIndexes.Add(i);
            }
            return startIndexes;
        }

        public int[] CharCount(string s)
        {
            var t = new int[26];
            for (var i = 0; i < s.Length; i++)
            {
                t[s[i] - 'a']++;
            }
            return t;
        }


        static void Main(string[] args)
        {
            var p = new Solution();
            var x = p.FindAnagrams("cbaebabacd", "abc");
            Console.WriteLine(string.Join(' ',x));
        }
    }
}
