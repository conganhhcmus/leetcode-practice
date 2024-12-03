namespace Problem_2807;

public class Solution
{
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