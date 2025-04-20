#if DEBUG
namespace Weekly_446_Q1;
#endif

public class Solution
{
    public long CalculateScore(string[] instructions, int[] values)
    {
        int n = values.Length;
        int curr = 0;
        long score = 0;

        bool[] visited = new bool[n];
        while (curr >= 0 && curr < n && !visited[curr])
        {
            if (instructions[curr] == "add")
            {
                visited[curr] = true;
                score += values[curr];
                curr++;
            }
            else
            {
                visited[curr] = true;
                curr += values[curr];
            }
        }

        return score;
    }
}