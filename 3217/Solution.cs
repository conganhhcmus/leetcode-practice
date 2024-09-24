namespace Practice_3217;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode SetNext(ListNode nextNode)
    {
        this.next = nextNode;
        return nextNode;
    }

    public static int[] ToArray(ListNode head)
    {
        var res = new List<int>();
        while (head != null)
        {
            res.Add(head.val);
            head = head.next;
        }
        return [.. res];
    }
}

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [5];
        int[] head = [1, 2, 3, 4];
        var list = new ListNode(0);
        var headTmp = list;
        foreach (var i in head)
        {
            list.SetNext(new ListNode(i));
            list = list.next;
        }
        var res = solution.ModifiedList(nums, headTmp.next);
        Console.WriteLine($"[{string.Join(", ", ListNode.ToArray(res))}]");
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