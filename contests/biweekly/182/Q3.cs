public class Solution
{
    public int MinGenerations(int[][] points, int[] target)
    {
        HashSet<int> seen = [];
        int t = target[0] * 49 + target[1] * 7 + target[2];
        List<int[]> arr = [];
        foreach (int[] p in points)
        {
            seen.Add(p[0] * 49 + p[1] * 7 + p[2]);
            arr.Add(p);
        }

        if (seen.Contains(t)) return 0;
        bool changed = true;
        int k = 1;
        while (changed)
        {
            changed = false;
            int size = arr.Count;
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    int x = (arr[i][0] + arr[j][0]) / 2;
                    int y = (arr[i][1] + arr[j][1]) / 2;
                    int z = (arr[i][2] + arr[j][2]) / 2;
                    int[] p = [x, y, z];
                    if (seen.Add(p[0] * 49 + p[1] * 7 + p[2]))
                    {
                        arr.Add(p);
                        changed = true;
                    }
                }
            }
            if (seen.Contains(t)) return k;
            k++;
        }

        return -1;
    }
}
