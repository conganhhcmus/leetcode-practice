public class Solution
{
    public IList<long> MergeAdjacent(int[] nums)
    {
        Stack<long> st = [];
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            long val = nums[i];
            while (st.Count > 0 && st.Peek() == val)
            {
                st.Pop();
                val *= 2;
            }
            st.Push(val);
        }
        List<long> ans = [];
        while (st.Count > 0)
        {
            ans.Add(st.Pop());
        }
        ans.Reverse();

        return ans;
    }
}