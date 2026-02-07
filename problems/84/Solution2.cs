public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        Stack<int> st = [];
        int ans = 0;
        for (int i = 0; i <= n; i++)
        {
            int height = i == n ? 0 : heights[i];
            while (st.Count > 0 && heights[st.Peek()] > height)
            {
                int currHeight = heights[st.Pop()];
                int prevIndex = st.Count == 0 ? -1 : st.Peek();
                ans = Math.Max(ans, currHeight * (i - 1 - prevIndex));
            }
            st.Push(i);
        }
        return ans;
    }
}