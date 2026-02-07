public class Solution
{
    int mod = (int)1e9 + 7;
    public int NumSubseq(int[] nums, int target)
    {
        long ret = 0;
        int n = nums.Length;
        Array.Sort(nums);
        for (int i = 0, j = n - 1; i < n; i++)
        {
            while (j >= i && nums[j] + nums[i] > target) j--;
            // can choose from [i..j]
            // total = 0Ck + 1Ck + 2Ck +.. +kCk = 2^k
            long val = FastPower(2, j - i);
            ret = (ret + val) % mod;
        }

        return (int)((ret + mod) % mod);
    }

    long FastPower(long a, long b)
    {
        if (b < 0) return 0;
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = ans * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return ans;
    }
}