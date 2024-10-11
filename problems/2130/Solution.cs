namespace Problem_2130;

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
        int[] nums = [5, 4, 2, 1];
        ListNode head = new ListNode(nums[0]);
        var tmp = head;
        for (int i = 1; i < nums.Length; i++)
        {
            tmp.next = new ListNode(nums[i]);
            tmp = tmp.next;
        }
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