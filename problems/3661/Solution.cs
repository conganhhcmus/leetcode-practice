public class Solution {
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        Array.Sort(walls);
        Array.Sort(robots, distance);
        int n = robots.Length;

        int Count(int st, int ed){
            int lo = 0;
            int hi = walls.Length - 1;
            int r = -1;
            while (lo <= hi){
                int mid = lo + (hi - lo) / 2;
                if (walls[mid] <= ed){
                    r = mid;
                    lo = mid + 1;
                } else {
                    hi = mid - 1;
                }
            }

            lo = 0;
            hi = walls.Length - 1;
            int l = walls.Length;
            while(lo <= hi){
                int mid = lo + (hi - lo)/2;
                if (walls[mid] >= st){
                    l = mid;
                    hi = mid - 1;
                } else {
                    lo = mid + 1;
                }
            }

            return Math.Max(0, r - l + 1);
        }

        Dictionary<(int, int), int> memo = [];

        int DP(int p, int m){
            if (p >= n) return 0;
            var key = (p, m);
            if (memo.TryGetValue(key, out int cache)) return cache;
            int ans = 0;
            // fire left
            int st = Math.Max(m, robots[p] - distance[p]);
            int ed = robots[p];
            int count = Count(st, ed);
            ans = Math.Max(ans, count + DP(p+1, ed + 1));
            // fire right
            st = Math.Max(m, robots[p]);
            ed = robots[p] + distance[p];
            if (p + 1 < n) {
                ed = Math.Min(ed, robots[p+1]);
            }
            count = Count(st, ed);
            ans = Math.Max(ans, count + DP(p+1, ed + 1));
            return memo[key] = ans;
        }

        return DP(0, 0);
    }
}