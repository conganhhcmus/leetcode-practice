namespace Problem_2491;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] skill = [5, 1, 1, 2, 1, 4];
        Console.WriteLine(solution.DividePlayers(skill));
    }
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