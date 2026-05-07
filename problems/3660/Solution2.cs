public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;
        Stack<(int val, int left, int right)> st = [];
        for (int i = 0; i < n; i++)
        {
            (int val, int left, int right) curr = (nums[i], i, i);
            while (st.Count > 0 && st.Peek().val > nums[i])
            {
                var top = st.Pop();
                curr = (Math.Max(curr.val, top.val), top.left, curr.right);
            }
            st.Push(curr);
        }
        int[] ans = new int[n];
        while (st.Count > 0)
        {
            var (val, left, right) = st.Pop();
            for (int i = left; i <= right; i++)
            {
                ans[i] = val;
            }
        }
        return ans;
    }
}
