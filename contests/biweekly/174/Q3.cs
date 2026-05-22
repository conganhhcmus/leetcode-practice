public class Solution
{
    public int AlternatingXOR(int[] nums, int target1, int target2)
    {
        int n = nums.Length;
        int sz = 1 << 17;
        int M = (int)1e9 + 7;
        int dpOdd = 0, dpEven = 0;
        int[] sumOdd = new int[sz];
        int[] sumEven = new int[sz];
        sumEven[0] = 1;
        int xor = 0;
        for (int i = 0; i < n; i++)
        {
            xor ^= nums[i];
            dpOdd = sumEven[xor ^ target1];
            dpEven = sumOdd[xor ^ target2];

            sumEven[xor] += dpEven;
            sumOdd[xor] += dpOdd;
            if (sumEven[xor] > M) sumEven[xor] -= M;
            if (sumOdd[xor] > M) sumOdd[xor] -= M;
        }

        int ans = dpOdd + dpEven;
        if (ans > M) ans -= M;
        return ans;
    }
}
