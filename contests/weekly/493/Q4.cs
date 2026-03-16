public class Solution
{
    int[] parent;
    int[] size;

    int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    bool Union(int x, int y)
    {
        int pX = Find(x), pY = Find(y);
        if (pX == pY) return false;
        if (pX > pY)
        {
            parent[pX] = pY;
            size[pY] += size[pX];
        }
        else
        {
            parent[pY] = pX;
            size[pX] += size[pY];
        }

        return true;
    }

    public int MaxActivated(int[][] points)
    {
        int n = points.Length;
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
        Dictionary<int, int> sameX = [];
        Dictionary<int, int> sameY = [];
        for (int i = 0; i < n; i++)
        {
            int x = points[i][0], y = points[i][1];
            if (sameX.ContainsKey(x))
            {
                Union(i, sameX[x]);
            }
            if (sameY.ContainsKey(y))
            {
                Union(i, sameY[y]);
            }
            sameX[x] = i;
            sameY[y] = i;
        }
        int ans = 0;
        int m1 = 0, m2 = 0;
        HashSet<int> seen = [];
        for (int i = 0; i < n; i++)
        {
            int s = size[i];
            if (!seen.Add(Find(i))) continue;
            if (s > m1)
            {
                m2 = m1;
                m1 = s;
            }
            else if (s > m2)
            {
                m2 = s;
            }
            ans = Math.Max(ans, m1 + m2 + 1);
        }
        return ans;
    }
}