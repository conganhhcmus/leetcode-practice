namespace Problem_328;

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
    public ListNode OddEvenList(ListNode head)
    {
        if (head is null || head.next is null) return head;

        ListNode oddHead = head;
        ListNode evenHead = head.next;
        ListNode tmp = evenHead;

        while (oddHead.next is not null && evenHead.next is not null)
        {
            oddHead.next = evenHead.next;
            oddHead = evenHead.next;

            evenHead.next = oddHead.next;
            evenHead = oddHead.next;
        }

        oddHead.next = tmp;
        return head;
    }

    public static void Execute()
    {
        int[] list = [1, 2, 3, 4, 5, 6, 7, 8];
        var solution = new Solution();
        var head = new ListNode(list[0]);
        var tmp = head;
        for (int i = 1; i < list.Length; i++)
        {
            tmp.next = new ListNode(list[i]);
            tmp = tmp.next;
        }
        var resHead = solution.OddEvenList(head);
        List<int> res = [];
        while (resHead is not null)
        {
            res.Add(resHead.val);
            resHead = resHead.next;
        }
        Console.WriteLine($"[{string.Join(", ", res)}]");
    }
}