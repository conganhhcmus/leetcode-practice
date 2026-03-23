public class Solution
{
    public long CountGoodSubarrays(int[] nums)
    {
        int n = nums.Length;
        int[] L = new int[n];
        int[] R = new int[n];

        int[] lastPos = new int[30];
        Dictionary<int, int> dict = [];
        Array.Fill(lastPos, -1);
        for (int i = 0; i < n; i++)
        {
            int lastBit = -1;
            for (int j = 0; j < 30; j++)
            {
                if ((nums[i] & (1 << j)) == 0)
                {
                    lastBit = Math.Max(lastBit, lastPos[j]);
                }
            }
            for (int j = 0; j < 30; j++)
            {
                if ((nums[i] & (1 << j)) != 0)
                {
                    lastPos[j] = i;
                }
            }

            if (dict.ContainsKey(nums[i]))
            {
                lastBit = Math.Max(lastBit, dict[nums[i]]);
            }

            L[i] = lastBit + 1;
            dict[nums[i]] = i;
        }

        int[] firstPos = new int[30];
        Array.Fill(firstPos, n);
        for (int i = n - 1; i >= 0; i--)
        {
            int firstBit = n;
            for (int j = 0; j < 30; j++)
            {
                if ((nums[i] & (1 << j)) == 0)
                {
                    firstBit = Math.Min(firstBit, firstPos[j]);
                }
            }

            for (int j = 0; j < 30; j++)
            {
                if ((nums[i] & (1 << j)) != 0)
                {
                    firstPos[j] = i;
                }
            }

            R[i] = firstBit - 1;
        }

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans += 1L * (i - L[i] + 1) * (R[i] - i + 1);
        }
        return ans;
    }
}