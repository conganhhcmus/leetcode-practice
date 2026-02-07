public class Solution
{
    int mod = (int)1e9 + 7;
    Dictionary<int, List<int>> transitions = [];
    List<int> validStates = [];
    Dictionary<int, int[]> decodedStates = [];

    // color: 0 - red, 1 - blue, 2 - green
    public int ColorTheGrid(int m, int n)
    {
        GenerateValidStates(m);
        GenerateTransitions(m);
        Dictionary<int, int> dp = [];
        foreach (int state in validStates)
        {
            dp[state] = 1;
        }

        for (int col = 1; col < n; col++)
        {
            Dictionary<int, int> next = [];
            foreach (int curr in validStates)
            {
                long count = 0;
                foreach (int prev in transitions[curr])
                {
                    count = (count + dp[prev]) % mod;
                }
                next[curr] = (int)count;
            }
            dp = next;
        }

        long ret = 0;
        foreach (int val in dp.Values)
        {
            ret = (ret + val) % mod;
        }

        return (int)ret;
    }

    void GenerateTransitions(int m)
    {
        foreach (var s1 in validStates)
        {
            transitions[s1] = [];
            foreach (var s2 in validStates)
            {
                if (CanFollow(decodedStates[s1], decodedStates[s2]))
                {
                    transitions[s1].Add(s2);
                }
            }
        }
    }

    void GenerateValidStates(int m)
    {
        int total = (int)Math.Pow(3, m);
        for (int mask = 0; mask < total; mask++)
        {
            int[] colors = Decode(mask, m);
            if (IsValidColumn(colors))
            {
                validStates.Add(mask);
                decodedStates[mask] = colors;
            }
        }
    }

    bool IsValidColumn(int[] colors)
    {
        for (int i = 1; i < colors.Length; i++)
        {
            if (colors[i] == colors[i - 1]) return false;
        }
        return true;
    }

    int[] Decode(int mask, int m)
    {
        int[] colors = new int[m];
        for (int i = 0; i < m; i++)
        {
            colors[i] = mask % 3;
            mask /= 3;
        }
        return colors;
    }

    bool CanFollow(int[] c1, int[] c2)
    {
        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i] == c2[i]) return false;
        }
        return true;
    }
}