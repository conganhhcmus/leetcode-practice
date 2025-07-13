#if DEBUG
namespace Problems_2410;
#endif

public class Solution
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        Array.Sort(players);
        Array.Sort(trainers);
        int ans = 0;
        for (int i = 0, j = 0; i < players.Length; i++)
        {
            while (j < trainers.Length && trainers[j] < players[i]) j++;
            if (j < trainers.Length)
            {
                ans++;
                j++;
            }
            else break;
        }
        return ans;
    }
}