public class Solution
{
    public int MinMaxWaitingTime(int[] demand, int[] fuel)
    {
        int n = demand.Length;
        Dictionary<(int, int, int), int> memo = [];
        int maxCars = Dp(0, fuel[0], fuel[1]);
        if (maxCars == 0) return -1;
        int left = 0, right = demand.Max(), ans = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (Can(mid))
            {
                ans = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return ans;

        int Dp(int pos, int f0, int f1)
        {
            if (pos >= n) return 0;
            var key = (pos, f0, f1);
            if (memo.TryGetValue(key, out int cache)) return cache;
            int best = 0;
            if (f0 >= demand[pos])
            {
                best = Math.Max(best, 1 + Dp(pos + 1, f0 - demand[pos], f1));
            }
            if (f1 >= demand[pos])
            {
                best = Math.Max(best, 1 + Dp(pos + 1, f0, f1 - demand[pos]));
            }
            return memo[key] = best;
        }

        bool Can(int W)
        {
            Dictionary<(int, int, int, int, int, int), bool> memo = [];

            return Dfs(0, fuel[0], fuel[1], 0, 0, 0);

            bool Dfs(int pos, int f0, int f1, int free0, int free1, int arrival)
            {
                if (pos >= maxCars) return true;
                var key = (pos, f0, f1, free0, free1, arrival);
                if (memo.TryGetValue(key, out bool cache)) return cache;
                int need = demand[pos];
                if (f0 >= need)
                {
                    int st = Math.Max(arrival, free0);
                    if (st - arrival <= W)
                    {
                        if (Dfs(pos + 1, f0 - need, f1, st + need, free1, st)) return memo[key] = true;
                    }
                }
                if (f1 >= need)
                {
                    int st = Math.Max(arrival, free1);
                    if (st - arrival <= W)
                    {
                        if (Dfs(pos + 1, f0, f1 - need, free0, st + need, st)) return memo[key] = true;
                    }
                }

                return memo[key] = false;
            }
        }
    }
}
