public class Solution
{
    public int NumSubmat(int[][] mat)
    {
        int n = mat[0].Length;
        int[] heights = new int[n];
        int ans = 0;
        foreach (var row in mat)
        {
            for (int i = 0; i < n; i++)
            {
                heights[i] = row[i] == 0 ? 0 : heights[i] + 1;
            }
            Stack<int[]> st = [];
            st.Push([-1, 0, -1]);
            for (int i = 0; i < n; i++)
            {
                int h = heights[i];
                while (st.Peek()[2] >= h)
                {
                    st.Pop();
                }

                var top = st.Peek();
                int j = top[0];
                int prev = top[1];
                int curr = prev + (i - j) * h;
                st.Push([i, curr, h]);
                ans += curr;
            }
        }
        return ans;
    }
}