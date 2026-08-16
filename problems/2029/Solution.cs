public class Solution
{
    public bool StoneGameIX(int[] stones)
    {
        int[] cnt = new int[3];
        foreach (int x in stones) cnt[x % 3]++;

        if (cnt[0] % 2 == 0)
        {
            return cnt[1] > 0 && cnt[2] > 0;
        }

        return Math.Abs(cnt[1] - cnt[2]) > 2;
    }
}