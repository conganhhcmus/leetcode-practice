#if DEBUG
namespace Contests_432_Q4;
#endif

public class Solution
{
    public long CountNonDecreasingSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        long ans = 0, tmp = k;
        Array.Reverse(nums);
        LinkedList<int> dq = new();
        for (int i = 0, j = 0; j < n; j++)
        {
            while (dq.Count > 0 && nums[dq.Last.Value] < nums[j])
            {
                int r = dq.Last.Value;
                dq.RemoveLast();
                int l = dq.Count > 0 ? dq.Last.Value : i - 1;
                tmp -= 1L * (r - l) * (nums[j] - nums[r]);
            }
            dq.AddLast(j);
            while (tmp < 0)
            {
                tmp += nums[dq.First.Value] - nums[i];
                if (dq.First.Value == i)
                {
                    dq.RemoveFirst();
                }
                i++;
            }
            ans += j - i + 1;
        }

        return ans;
    }
}