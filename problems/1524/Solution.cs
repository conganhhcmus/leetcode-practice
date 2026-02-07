public class Solution
{
    public int NumOfSubarrays(int[] arr)
    {
        int n = arr.Length;
        int[] map = new int[2];
        int prefixSumMod = 0;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            prefixSumMod = (prefixSumMod + arr[i]) % 2;
            ans = (ans + map[1 - prefixSumMod] + prefixSumMod) % 1000000007;

            map[prefixSumMod]++;
        }
        return ans;
    }
}