public class Solution
{
    public int CountPermutations(int[] complexity)
    {
        int mod = (int)1e9 + 7;
        int n = complexity.Length;
        for (int i = 1; i < n; i++)
        {
            if (complexity[i] <= complexity[0]) return 0;
        }
        long ans = 1;
        for (int i = 1; i < n; i++)
        {
            ans = (ans * i) % mod;
        }
        return (int)ans;
    }
}