namespace Problem_3217;

using Helpers.ListNode;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [5];
        var head = ListNodeHelper.CreateListFromArray([1, 2, 3, 4]);

        var solution = new Solution();
        var res = solution.ModifiedList(nums, head);
        ListNodeHelper.PrintList(res);
    }
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        var res = new ListNode();
        var headRes = res;
        var hashSet = nums.ToHashSet();
        while (head != null)
        {
            if (!hashSet.Contains(head.val))
            {
                res.next = new ListNode(head.val);
                res = res.next;
            }

            head = head.next;
        }

        return headRes.next;
    }
}