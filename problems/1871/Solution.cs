public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;
        if (s[n - 1] == '1') return false;
        bool[] f = new bool[n];
        f[n - 1] = true;
        LinkedList<int> dq = new();
        dq.AddLast(n - 1);
        for (int i = n - 2; i >= 0; i--)
        {
            if (s[i] == '1') continue;
            while (dq.Count > 0 && i + maxJump < dq.First.Value)
            {
                dq.RemoveFirst();
            }
            if (dq.Count > 0 && i + minJump <= dq.First.Value)
            {
                f[i] = true;
                dq.AddLast(i);
            }
        }
        return f[0];
    }
}
