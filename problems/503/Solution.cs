public class Solution
{
    public int[] NextGreaterElements(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        Stack<int> stack = [];
        for (int i = 2 * n - 1; i >= 0; i--)
        {
            int idx = i % n;
            while (stack.Count > 0 && nums[idx] >= nums[stack.Peek()])
            {
                stack.Pop();
            }
            ans[idx] = stack.Count > 0 ? nums[stack.Peek()] : -1;
            stack.Push(idx);
        }
        return ans;
    }
}