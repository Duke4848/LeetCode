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
        var top = stack.Pop();
        PushLeft(top.right);
        return top.val;
    }

    public bool HasNext()
    {
        return stack.Any();
    }

    private void PushLeft(TreeNode node)
    {
        if (node != null)
        {
            stack.Push(node);
            PushLeft(node.left);
        }
    }

    public static void Main(string[] args)
    {
        var n7 = new TreeNode(7);
        var n3 = new TreeNode(3);
        var n15 = new TreeNode(15);
        var n9 = new TreeNode(9);
        var n20 = new TreeNode(20);

        n7.left = n3;
        n7.right = n15;
        n15.left = n9;
        n15.right = n20;

        BSTIterator bSTIterator = new BSTIterator(n7);
        Console.WriteLine(bSTIterator.Next());    // return 3
        Console.WriteLine(bSTIterator.Next());    // return 7
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());    // return 9
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());    // return 15
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());    // return 20
        Console.WriteLine(bSTIterator.HasNext()); // return False
    }
}