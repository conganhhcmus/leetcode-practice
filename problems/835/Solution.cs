public class Solution
{
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        int n = img1.Length;
        int ans = 0;
        // check bottom left
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                int cnt = 0;
                for (int i = 0; i < n; i++)
                {
                    if (x + i >= n) break;
                    for (int j = 0; j < n; j++)
                    {
                        if (y + j >= n) break;
                        cnt += img1[x + i][y + j] & img2[i][j];
                    }
                }
                ans = Math.Max(ans, cnt);
            }
        }

        // check top right
        for (int x = n - 1; x >= 0; x--)
        {
            for (int y = 0; y < n; y++)
            {
                int cnt = 0;
                for (int i = 0; i < n; i++)
                {
                    if (x - i < 0) break;
                    for (int j = 0; j < n; j++)
                    {
                        if (y + j >= n) break;
                        cnt += img1[x - i][y + j] & img2[n - 1 - i][j];
                    }
                }
                ans = Math.Max(ans, cnt);
            }
        }

        // check bottom left
        for (int x = 0; x < n; x++)
        {
            for (int y = n - 1; y >= 0; y--)
            {
                int cnt = 0;
                for (int i = 0; i < n; i++)
                {
                    if (x + i >= n) break;
                    for (int j = 0; j < n; j++)
                    {
                        if (y - j < 0) break;
                        cnt += img1[x + i][y - j] & img2[i][n - 1 - j];
                    }
                }
                ans = Math.Max(ans, cnt);
            }
        }

        // check bottom right
        for (int x = n - 1; x >= 0; x--)
        {
            for (int y = n - 1; y >= 0; y--)
            {
                int cnt = 0;
                for (int i = 0; i < n; i++)
                {
                    if (x - i < 0) break;
                    for (int j = 0; j < n; j++)
                    {
                        if (y - j < 0) break;
                        cnt += img1[x - i][y - j] & img2[n - 1 - i][n - 1 - j];
                    }
                }
                ans = Math.Max(ans, cnt);
            }
        }

        return ans;
    }
}
