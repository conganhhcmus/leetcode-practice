public class Solution
{
    public int CountMajoritySubarrays(int[] nums, int target)
    {
        int n = nums.Length;
        int[] pref = new int[n + 1];
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == target) cnt++;
            pref[i + 1] = cnt;
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (Ok(i, j)) ans++;
            }
        }
        return ans;

        bool Ok(int i, int j)
        {
            int l = j - i + 1;
            int c = pref[j + 1] - pref[i];
            return 2 * c > l;
        }
    }
}
