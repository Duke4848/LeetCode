public class Solution
{
    public bool CheckSubarraySum(int[] t, int k)
    {
        var dict = new Dictionary<int, int>() { { 0, -1 } };
        var mod = 0;
        for (var i = 0; i < t.Length; i++)
        {
            mod = Math.Abs((mod + t[i]) % k);
            if (dict.ContainsKey(mod))
            {
                var distanceFromPreviousSameMod = i - dict[mod];
                if (distanceFromPreviousSameMod >= 2)
                {
                    return true;
                }
            }
            else
            {
                dict[mod] = i;
            }
        }
        return false;
    }

    public static void Main(string[] args)
    {
        var s = new Solution();
        var x = s.CheckSubarraySum([5, 0, 0, 0], 3);
        Console.WriteLine(
            x);
    }

}
