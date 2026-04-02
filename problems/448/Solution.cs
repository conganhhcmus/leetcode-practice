public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        int n = nums.Length;
        bool[] seen = new bool[n + 1];
        foreach (int num in nums)
        {
            seen[num] = true;
        }
        IList<int> res = [];
        for (int i = 1; i <= n; i++)
        {
            if (!seen[i]) res.Add(i);
        }
        return res;
    }
}