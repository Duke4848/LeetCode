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

public class BSTIteratorLevelOrder
{
    private Queue<TreeNode> queue = new Queue<TreeNode>();
    public BSTIteratorLevelOrder(TreeNode root)
    {
        queue.Enqueue(root);
    }

    public int Next()
    {
        var dequeued = queue.Dequeue();
        if (dequeued.left is not null)
            queue.Enqueue(dequeued.left);
        if (dequeued.right is not null)
            queue.Enqueue(dequeued.right);
        return dequeued.val;
    }

    public bool HasNext()
    {
        return queue.Any();
    }
}

public class BSTIterator
{
    private Stack<TreeNode> stack = new Stack<TreeNode>();
    public BSTIterator(TreeNode root)
    {
        PushLeft(root);
    }

    public int Next()
    {
        PushLeft(stack.Peek().right);
        return stack.Pop().val;
    }

    public bool HasNext()
    {
        return stack.Any();
    }

    private void PushLeft(TreeNode node)
    {
        while (node != null)
        {
            stack.Push(node.left);
        }
    }

    public static void Main(string[] args)
    {
        var n7 = new TreeNode(7);
        var n3 = new TreeNode(3);
        var n15 = new TreeNode(15);
        var n9 = new TreeNode(9);
        var n20 = new TreeNode(20);
        BSTIterator bSTIterator = new BSTIterator(n7);
        bSTIterator.Next();    // return 3
        bSTIterator.Next();    // return 7
        bSTIterator.HasNext(); // return True
        bSTIterator.Next();    // return 9
        bSTIterator.HasNext(); // return True
        bSTIterator.Next();    // return 15
        bSTIterator.HasNext(); // return True
        bSTIterator.Next();    // return 20
        bSTIterator.HasNext(); // return False
    }
}