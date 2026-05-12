public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        // if tasks have two task A and B
        // we can choose [A, B] or [B, A]
        // if AB: 
        // for A: E >= max(aA, mA) = mA
        // for B: E - aA >= max(aB, mB) = mB 
        // E >= max(mB + aA, mA)
        // if BA:
        // E >= max(mA + aB, mB)
        // if want to pick [A, B] we need to E(AB) <= E(BA):
        // <=> max(mB + aA, mA) <= max(mA + aB, mB)
        // <=> mB + aA <= mA + aB
        // <=> mB - aB <= mA - aA
        // => Sort by mi - ai
        int n = tasks.Length;
        Array.Sort(tasks, (a, b) => (a[1] - a[0]).CompareTo(b[1] - b[0]));
        int ans = 0;
        // completed from n-1 to 0 tasks
        for (int i = 0; i < n; i++)
        {
            ans = Math.Max(ans + tasks[i][0], tasks[i][1]);
        }
        return ans;
    }
}
