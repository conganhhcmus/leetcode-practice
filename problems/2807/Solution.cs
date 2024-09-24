namespace Problem_2807;

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
        int[] headArr = [18, 6, 10, 3];
        var tmp = new ListNode();
        var head = tmp;

        foreach (var num in headArr)
        {
            tmp.next = new ListNode(num);
            tmp = tmp.next;
        }

        var res = solution.InsertGreatestCommonDivisors(head.next);
        PrintListNode(res);
    }

    private static void PrintListNode(ListNode head)
    {
        var list = new List<int>();
        while (head is not null)
        {
            list.Add(head.val);
            head = head.next;
        }

        Console.WriteLine($"[{string.Join(",", list)}]");
    }
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var res = head;
        var prvHead = head;
        head = head.next;

        while (head is not null)
        {
            int gdc = GDC(prvHead.val, head.val);
            prvHead.next = new ListNode(gdc, head);

            prvHead = head;
            head = head.next;
        }

        return res;
    }

    private int GDC(int a, int b)
    {
        if (b == 0) return a;

        return GDC(b, a % b);
    }
}