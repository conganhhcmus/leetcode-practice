public class Solution
{
    public long TotalScore(int hp, int[] damage, int[] requirement)
    {
        int n = damage.Length;
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            pref[i + 1] = pref[i] + damage[i];
        }
        // score[0] = hp - damage[0] >= requirement[0]
        //  + hp - damage[0] - damage[1] >= requirement[1]
        //  score[1] = hp - damage[1] >= requirement[1]
        //  at i-index can contribute hp - requirement[i] >= sum (j -> i)
        // at i-index can contribute hp - requirement[i] >= pref[i+1] - pref[j]
        // at i-index can contribute hp - requirement[i] - pref[i+1] >= - pref[j];
        // pref[j] >= pref[i+1] + requirement[i] - hp
        // count j with pref[j] <= need
        long ans = 0L;
        for (int i = 0; i < n; i++)
        {
            long need = pref[i + 1] + requirement[i] - hp;
            int low = 0, high = i, best = i + 1;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (pref[mid] >= need)
                {
                    best = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            ans += i - best + 1;
        }
        return ans;
    }
}
