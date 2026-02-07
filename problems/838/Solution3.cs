public class Solution
{
    public string PushDominoes(string dominoes)
    {
        int n = dominoes.Length;
        int[] points = new int[n];
        int point = 0;
        for (int i = 0; i < n; i++)
        {
            if (dominoes[i] == 'R') point = n;
            else if (dominoes[i] == 'L') point = 0;
            else point = Math.Max(point - 1, 0);
            points[i] += point;
        }

        point = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (dominoes[i] == 'L') point = n;
            else if (dominoes[i] == 'R') point = 0;
            else point = Math.Max(point - 1, 0);
            points[i] -= point;
        }

        StringBuilder sb = new();
        for (int i = 0; i < n; i++)
        {
            if (points[i] == 0) sb.Append('.');
            else if (points[i] > 0) sb.Append('R');
            else sb.Append('L');
        }
        return sb.ToString();
    }
}