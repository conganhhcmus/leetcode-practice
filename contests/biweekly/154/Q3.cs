#if DEBUG
namespace Biweekly_154_Q3;
#endif

public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        int n = nums.Length;
        if (n < 3) return n;

        bool[] pair = new bool[2049]; // max 2048
        bool[] triple = new bool[2049]; // max 2048
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                pair[nums[i] ^ nums[j]] = true;
            }
        }

        for (int i = 0; i < 2049; i++)
        {
            if (!pair[i]) continue;
            for (int k = 0; k < n; k++)
            {
                triple[i ^ nums[k]] = true;
            }
        }
        int ret = 0;
        for (int i = 0; i < 2049; i++)
        {
            if (triple[i]) ret++;
        }
        return ret;
    }
}