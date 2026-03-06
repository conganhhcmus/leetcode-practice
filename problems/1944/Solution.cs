public class Solution
{
    public int[] CanSeePersonsCount(int[] heights)
    {
        int n = heights.Length;
        int[] ans = new int[n];
        Stack<int> stack = new();

        for (int i = n - 1; i >= 0; i--)
        {
            int visible = 0;

            while (stack.Count > 0 && stack.Peek() < heights[i])
            {
                stack.Pop();
                visible++;
            }

            if (stack.Count > 0) visible++;

            ans[i] = visible;
            stack.Push(heights[i]);
        }

        return ans;
    }
}