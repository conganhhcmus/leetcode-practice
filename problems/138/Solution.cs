/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if (head is null) return head;
        Dictionary<Node, Node> map = [];
        Node curr = head;
        while (curr is not null)
        {
            map[curr] = new Node(curr.val);
            curr = curr.next;
        }

        foreach (var kvp in map)
        {
            Node dist = kvp.Value;
            Node source = kvp.Key;
            dist.next = source.next is not null ? map[source.next] : null;
            dist.random = source.random is not null ? map[source.random] : null;
        }
        return map[head];
    }
}