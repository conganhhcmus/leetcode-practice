namespace Problem_3217;

public class Solution
{
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