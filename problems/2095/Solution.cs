namespace Problem_2095;

public class Solution
{
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
    public ListNode DeleteMiddle(ListNode head)
    {
        if (head is null || head.next is null) return null;

        int n = 0;
        var tmp = head;

        while (tmp is not null)
        {
            n++;
            tmp = tmp.next;
        }

        n /= 2;
        tmp = head;
        while (--n > 0)
        {
            tmp = tmp.next;
        }
        tmp.next = tmp.next.next;
        return head;
    }

    public static void Execute()
    {
        int[] list = [1, 3, 4, 7, 1, 2, 6];
        var solution = new Solution();
        var head = new ListNode(list[0]);
        var tmp = head;
        for (int i = 1; i < list.Length; i++)
        {
            tmp.next = new ListNode(list[i]);
            tmp = tmp.next;
        }
        var resHead = solution.DeleteMiddle(head);
        List<int> res = [];
        while (resHead is not null)
        {
            res.Add(resHead.val);
            resHead = resHead.next;
        }
        Console.WriteLine($"[{string.Join(", ", res)}]");
    }
}