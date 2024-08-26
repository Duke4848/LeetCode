public class Solution
{
    private int[] nums;
    private Random random;

    public Solution(int[] nums)
    {
        this.nums = nums;
        this.random = new Random();
    }

    public int Pick(int target)
    {
        int result = -1;
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                count++;
                // Reservoir sampling: with probability 1/count, choose the current index
                if (random.Next(count) == 0)
                {
                    result = i;
                }
            }
        }

        return result;
    }
}