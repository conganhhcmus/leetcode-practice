namespace Problem_725;

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

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] headArr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int k = 3;
        var tmpHead = new ListNode();
        var head = tmpHead;

        foreach (var num in headArr)
        {
            tmpHead.next = new ListNode(num);
            tmpHead = tmpHead.next;
        }

        PrintListNode(head.next);

        var res = solution.SplitListToParts(head.next, k);
        foreach (var node in res)
        {
            PrintListNode(node);
        }
    }

    private static void PrintListNode(ListNode node)
    {
        var tmpList = node;
        List<int> output = [];
        while (tmpList is not null)
        {
            output.Add(tmpList.val);
            tmpList = tmpList.next;
        }

        Console.WriteLine($"[{string.Join(", ", output)}]");
    }

    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        var res = new ListNode[k];
        if (head is null || k == 0) return res;

        int headLength = 0;
        var tmpHead = head;
        while (tmpHead is not null)
        {
            headLength++;
            tmpHead = tmpHead.next;
        }

        int div = headLength / k;
        int mod = headLength % k;

        for (int i = 0; i < k; i++)
        {
            res[i] = head;
            int pos = 0;
            int size = div + (mod > 0 ? 1 : 0);

            while (head is not null && pos < size)
            {
                pos++;
                tmpHead = head;
                head = head.next;
            }

            if (tmpHead is not null)
            {
                tmpHead.next = null;
            }
            mod--;
        }

        return res;
    }
}