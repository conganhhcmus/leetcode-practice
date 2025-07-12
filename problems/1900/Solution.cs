#if DEBUG
namespace Problems_1900;
#endif

public class Solution
{
    int min = int.MaxValue;
    int max = 0;
    public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
    {
        List<int> players = [];
        for (int i = 1; i <= n; i++) players.Add(i);
        Solve(firstPlayer, secondPlayer, 1, players);
        return [min, max];
    }

    void Solve(int firstPlayer, int secondPlayer, int round, List<int> players)
    {
        int index1 = players.IndexOf(firstPlayer);
        int index2 = players.IndexOf(secondPlayer);
        int n = players.Count;
        if ((n - index2 - 1) == index1)
        {
            min = Math.Min(min, round);
            max = Math.Max(max, round);
            return;
        }

        int maxBitMask = 1 << (n / 2);
        for (int bitMask = 0; bitMask < maxBitMask; bitMask++)
        {
            List<int> nextPlayers = NextRound(players, bitMask);
            if (nextPlayers.Contains(firstPlayer) && nextPlayers.Contains(secondPlayer))
            {
                Solve(firstPlayer, secondPlayer, round + 1, nextPlayers);
            }
        }
    }

    List<int> NextRound(List<int> players, int bitMask)
    {
        List<int> ret = [];
        int n = players.Count;
        if (n % 2 == 1)
        {
            ret.Add(players[n / 2]);
        }
        for (int i = 0; i < n / 2; i++)
        {
            if ((bitMask & (1 << i)) != 0)
            {
                ret.Add(players[i]);
            }
            else
            {
                ret.Add(players[n - i - 1]);
            }
        }
        ret.Sort();
        return ret;
    }
}