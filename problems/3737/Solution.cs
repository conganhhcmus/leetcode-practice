public class Solution
{
    public int CountMajoritySubarrays(int[] nums, int target)
    {
        int n = nums.Length;
        int[] pref = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            pref[i + 1] = pref[i] + (nums[i] == target ? 1 : 0);
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int cnt = pref[j + 1] - pref[i];
                if (2 * cnt > j - i + 1) ans++;
            }
        }
        return ans;
    }
}
