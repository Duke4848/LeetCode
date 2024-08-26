    public class Solution
    {

        public int FindKthLargest(int[] vals, int k)
        {
            var queue = new PriorityQueue<int, int>(vals.Length, Comparer<int>.Create((x, y) => x.CompareTo(y)));
            foreach (var val in vals)
            {
                queue.Enqueue(val, val);
                if (queue.Count > k)
                {
                    queue.Dequeue();
                }
            }
            return queue.Peek();
        }
        static void Main(string[] args)
        {
            var s = new Solution();
            s.FindKthLargest([3, 2, 3, 1, 2, 4, 5, 5, 6], 4);
        }
    }
