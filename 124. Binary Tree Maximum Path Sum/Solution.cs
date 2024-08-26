public class Solution
{
    public int GlobalMax { get; set; } = int.MinValue;

    public int MaxPathSum(TreeNode node)
    {
        if (node == null) return 0;

        var val1 = Math.Max(MaxPathSum(node.left), 0);
        var val2 = Math.Max(MaxPathSum(node.right), 0);
        var sumWithLocalSplit = node.val + val1 + val2;
        var sumWithoutLocalSplit = node.val + Math.Max(val1, val2);
        if (sumWithLocalSplit > GlobalMax)
        {
            GlobalMax = sumWithLocalSplit;
        }
        return sumWithoutLocalSplit;
    }

    public static void Main(string[] args)
    {
        var s = new Solution();
        var n1 = new TreeNode(1);
        var n2 = new TreeNode(2);
        var n3 = new TreeNode(3);
        var n4 = new TreeNode(4);

        n1.left = n2;
        n1.right = n3;

        Console.WriteLine(s.MaxPathSum(n1));
    }
}


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}