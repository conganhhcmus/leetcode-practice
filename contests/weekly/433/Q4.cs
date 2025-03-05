#if DEBUG
namespace Contests_433_Q4;
#endif

public class Solution
{
    public long MinMaxSubarraySum(int[] nums, int k)
    {
        int n = nums.Length;

        (int left, int right)[] minDP = new (int left, int right)[n];
        (int left, int right)[] maxDP = new (int left, int right)[n];

        for (int i = 0; i < n; i++)
        {
            minDP[i] = (-1, n);
            maxDP[i] = (-1, n);
        }
        Stack<int> minStack = [], maxStack = [];
        for (int i = 0; i < n; i++)
        {
            while (minStack.Count > 0 && nums[minStack.Peek()] > nums[i]) minStack.Pop();
            if (minStack.Count > 0) minDP[i].left = minStack.Peek();
            minStack.Push(i);

            while (maxStack.Count > 0 && nums[maxStack.Peek()] < nums[i]) maxStack.Pop();
            if (maxStack.Count > 0) maxDP[i].left = maxStack.Peek();
            maxStack.Push(i);
        }
        minStack = []; maxStack = [];
        for (int i = n - 1; i >= 0; i--)
        {
            while (minStack.Count > 0 && nums[minStack.Peek()] >= nums[i]) minStack.Pop();
            if (minStack.Count > 0) minDP[i].right = minStack.Peek();
            minStack.Push(i);

            while (maxStack.Count > 0 && nums[maxStack.Peek()] <= nums[i]) maxStack.Pop();
            if (maxStack.Count > 0) maxDP[i].right = maxStack.Peek();
            maxStack.Push(i);
        }

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans += 1L * nums[i] * Calc(minDP[i].left, minDP[i].right, i, k);
            ans += 1L * nums[i] * Calc(maxDP[i].left, maxDP[i].right, i, k);
        }
        return ans;
    }

    private long Calc(int left, int right, int cur, int k)
    {
        left = Math.Min(k, cur - left);
        right = Math.Min(k, right - cur);
        int extra = Math.Max(0, left + right - 1 - k);
        long sub = (1L * extra * (extra + 1)) / 2;
        return 1L * left * right - sub;
    }
}