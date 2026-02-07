public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        int n = matrix.Length, m = matrix[0].Length;
        int ans = 0;
        int[] height = new int[m + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i][j] == '0')
                {
                    height[j] = 0;
                }
                else
                {
                    height[j]++;
                }
            }

            ans = Math.Max(ans, Calc(height));
        }
        return ans;
    }

    int Calc(int[] height)
    {
        int ans = 0;
        Stack<int> st = [];
        for (int i = 0; i < height.Length; i++)
        {
            while (st.Count > 0 && height[i] < height[st.Peek()])
            {
                int h = height[st.Pop()];
                int l = st.Count > 0 ? st.Peek() : -1;
                int w = i - l - 1;
                ans = Math.Max(ans, w * h);
            }
            st.Push(i);
        }

        return ans;
    }
}