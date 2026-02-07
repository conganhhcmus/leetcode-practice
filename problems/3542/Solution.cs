public class Solution
{
    public int MinOperations(int[] nums)
    {
        Stack<int> st = [];
        int ans = 0;
        foreach (int num in nums)
        {
            while (st.Count > 0 && st.Peek() > num)
            {
                st.Pop();
            }
            if (num == 0) continue;
            if (st.Count == 0 || st.Peek() < num)
            {
                ans++;
                st.Push(num);
            }
        }
        return ans;
    }
}