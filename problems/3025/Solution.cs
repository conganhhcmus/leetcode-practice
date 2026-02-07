public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        int n = points.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int ax = points[i][0];
            int ay = points[i][1];
            for (int j = 0; j < n; j++)
            {
                if (j == i) continue;
                int bx = points[j][0];
                int by = points[j][1];
                if (ax <= bx && ay >= by)
                {
                    bool isEmpty = true;
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i || k == j) continue;
                        int cx = points[k][0];
                        int cy = points[k][1];
                        if (cx >= ax && cx <= bx && cy >= by && cy <= ay)
                        {
                            isEmpty = false;
                            break;
                        }
                    }

                    if (isEmpty) ans++;
                }
            }
        }
        return ans;
    }
}