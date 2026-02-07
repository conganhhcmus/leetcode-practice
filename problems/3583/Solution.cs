public class Solution
{
    public int SpecialTriplets(int[] nums)
    {
        int mod = (int)1e9 + 7;
        long ans = 0;
        Dictionary<int, int> totCount = [];
        Dictionary<int, int> count = [];
        foreach (int num in nums)
        {
            totCount[num] = totCount.GetValueOrDefault(num, 0) + 1;
        }
        foreach (int num in nums)
        {
            int prev = count.GetValueOrDefault(2 * num, 0);
            int post = totCount.GetValueOrDefault(2 * num, 0) - prev;
            if (num == 0) post--;
            ans = (ans + 1L * prev * post) % mod;
            count[num] = count.GetValueOrDefault(num, 0) + 1;
        }

        return (int)ans;
    }
}