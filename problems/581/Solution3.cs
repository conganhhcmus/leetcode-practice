#if DEBUG
namespace Problems_581_3;
#endif

public class Solution
{
    public int FindUnsortedSubarray(int[] nums)
    {
        int n = nums.Length;
        Stack<int> st = new();
        int left = n;
        for (int i = 0; i < n; i++)
        {
            while (st.Count > 0 && nums[st.Peek()] > nums[i])
            {
                left = Math.Min(left, st.Pop());
            }
            st.Push(i);
        }

        st.Clear();
        int right = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            while (st.Count > 0 && nums[st.Peek()] < nums[i])
            {
                right = Math.Max(right, st.Pop());
            }
            st.Push(i);
        }
        if (left >= right) return 0;
        return right - left + 1;
    }
}