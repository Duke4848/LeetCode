namespace _938Range_Sum_Bst
{

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

    public class Solution
    {
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null) return 0;
            var ret = 0;
            if (root.val >= low && root.val <= high)
            {
                ret = root.val;
            }
            return ret + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
        }

        //public int RangeSumBST(TreeNode root, int low, int high, int sum)
        //{
        //    if (root == null) return sum;
        //    if (root.val <= low && root.val >= high)
        //    {
        //        sum += root.val;
        //    }
        //    RangeSumBST(root.left, low, high, sum);
        //    RangeSumBST(root.right, low, high, sum);

        //}


    }
}
