public class Solution
{
    public long DividePlayers(int[] skill)
    {
        int target = skill.Sum();
        if (target % (skill.Length / 2) == 1) return -1;
        target /= skill.Length / 2;
        int[] frequency = new int[1001];

        foreach (int num in skill)
        {
            frequency[num]++;
        }

        long ans = 0L;
        foreach (int num in skill)
        {
            int remain = target - num;
            if (remain < 0 || remain > 1000 || frequency[remain] == 0) return -1;

            ans += num * remain;
            frequency[remain]--;
        }

        return ans / 2;
    }
}