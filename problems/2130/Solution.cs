namespace Problem_2130;

using Helpers.ListNode;

public class Solution
{
    public static void Execute()
    {
        var head = ListNodeHelper.CreateListFromArray([5, 4, 2, 1]);
        var solution = new Solution();
        Console.WriteLine(solution.PairSum(head));
    }
    public int PairSum(ListNode head)
    {
        List<int> nums = [];
        while (head is not null)
        {
            nums.Add(head.val);
            head = head.next;
        }
        int max = 0;
        for (int i = 0; i < nums.Count / 2; i++)
        {
            max = Math.Max(max, nums[i] + nums[^(i + 1)]);
        }
        return max;
    }
}