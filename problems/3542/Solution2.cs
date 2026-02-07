public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int[] stack = new int[n + 1];
        int top = 0;
        int ans = 0;
        foreach (int num in nums)
        {
            // Pop while stack[top] > num
            while (top > 0 && stack[top] > num)
            {
                top--;
                ans++;
            }

            // Push if different
            if (stack[top] != num)
            {
                top++;
                stack[top] = num;
            }
        }

        return ans + top;
    }
}