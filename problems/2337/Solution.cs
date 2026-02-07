public class Solution
{
    public bool CanChange(string start, string target)
    {
        int p1 = 0, p2 = 0;
        while (p1 < start.Length && p2 < target.Length)
        {
            while (p1 < start.Length && start[p1] == '_') p1++;
            while (p2 < target.Length && target[p2] == '_') p2++;
            if (p1 == start.Length || p2 == target.Length) break;
            if (start[p1] != target[p2]) return false;
            if (p1 < p2 && start[p1] == 'L') return false;
            if (p1 > p2 && start[p1] == 'R') return false;
            p1++;
            p2++;
        }

        while (p1 < start.Length)
        {
            if (start[p1] != '_') return false;
            p1++;
        }

        while (p2 < target.Length)
        {
            if (target[p2] != '_') return false;
            p2++;
        }

        return true;
    }
}