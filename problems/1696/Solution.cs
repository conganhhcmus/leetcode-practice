public class Solution
{
    public int MaxResult(int[] nums, int k)
    {
        int n = nums.Length;
        int[] f = new int[n];
        f[n - 1] = nums[n - 1];
        LinkedList<int> dq = new();
        dq.AddLast(n - 1);
        for (int i = n - 2; i >= 0; i--)
        {
            while (dq.Count > 0 && dq.First.Value - i > k)
            {
                dq.RemoveFirst();
            }
            f[i] = nums[i] + f[dq.First.Value];
            while (dq.Count > 0 && f[dq.Last.Value] <= f[i])
            {
                dq.RemoveLast();
            }
            dq.AddLast(i);
        }
        return f[0];
    }
}
