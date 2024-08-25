using System;

namespace _278FirstBadVersion
{
    public class Solution
    {
        public int FirstBadVersion(int n)
        {
            if (n == 1) return n;
            int l = 1, r = n;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (!IsBadVersion(mid))
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return l;
        }

        public bool IsBadVersion(int v)
        {
            bool[] t = { false, false, false, true, true };
            return t[v - 1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FirstBadVersion(5));
        }
    }
}
