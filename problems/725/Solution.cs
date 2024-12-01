namespace Problem_725;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        int k = 3;
        var head = ListNodeHelper.CreateListFromArray([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

        ListNodeHelper.PrintList(head.next);

        var solution = new Solution();
        var res = solution.SplitListToParts(head, k);
        foreach (var node in res)
        {
            ListNodeHelper.PrintList(node);
        }
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