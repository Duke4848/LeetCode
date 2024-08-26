using System.ComponentModel.Design.Serialization;

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => x.CompareTo(y)));
        ListNode curr = null;
        foreach (var l in lists)
        {
            curr = l;
            while (curr != null)
            {
                heap.Enqueue(curr.val, curr.val);
                curr = curr.next;
            }
        }
        ListNode head = null;
        while (heap.Count > 0)
        {
            var item = heap.Dequeue();
            var newNode = new ListNode(item);
            if (curr != null)
            {
                curr.next = newNode;
            }
            else { 
                head = newNode;
            }
            curr = newNode;
        }
        return head;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
