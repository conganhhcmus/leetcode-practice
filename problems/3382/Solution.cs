public class Solution
{
    public long MaxRectangleArea(int[] xCoord, int[] yCoord)
    {
        int n = xCoord.Length;
        SortedDictionary<int, List<int>> map = [];
        int maxY = 0;
        for (int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(xCoord[i]))
            {
                map[xCoord[i]] = [];
            }
            map[xCoord[i]].Add(yCoord[i]);
            maxY = Math.Max(maxY, yCoord[i]);
        }

        long ans = -1;
        Dictionary<(int, int), (int val, int x)> saved = [];
        int[] ft = new int[maxY + 2];
        foreach (int x in map.Keys)
        {
            var yList = map[x];
            yList.Sort();
            for (int i = 0; i < yList.Count; i++)
            {
                AddFenwick(ft, yList[i], 1);
                if (i - 1 >= 0)
                {
                    var key = (yList[i], yList[i - 1]);
                    int val = SumFenwick(ft, yList[i]) - SumFenwick(ft, yList[i - 1] - 1);
                    (int val, int x) prev = saved.GetValueOrDefault(key, (-1, -1));
                    if (val - prev.val == 2)
                    {
                        long area = (long)(x - prev.x) * (yList[i] - yList[i - 1]);
                        ans = Math.Max(ans, area);
                    }
                    saved[key] = (val, x);
                }
            }
        }

        return ans;
    }

    private void AddFenwick(int[] ft, int pos, int val)
    {
        if (val == 0 || pos < 0) return;
        pos++;
        for (int i = pos; i < ft.Length; i += i & -i)
        {
            ft[i] += val;
        }
    }

    private int SumFenwick(int[] ft, int pos)
    {
        int sum = 0;
        pos++;
        while (pos > 0)
        {
            sum += ft[pos];
            pos -= pos & -pos;
        }
        return sum;
    }
}