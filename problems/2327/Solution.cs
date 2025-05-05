#if DEBUG
namespace Problems_2327;
#endif

public class Solution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        int mod = (int)1e9 + 7;
        int curr = 1;
        Queue<(int val, int time)> insQueue = [];
        Queue<(int val, int time)> delQueue = [];
        insQueue.Enqueue((1, 1 + delay));
        delQueue.Enqueue((1, 1 + forget));
        int canShare = 0;
        for (int i = 2; i <= n; i++)
        {
            int add = 0, sub = 0;
            while (insQueue.Count > 0 && insQueue.Peek().time <= i)
            {
                add = (add + insQueue.Dequeue().val) % mod;
            }
            while (delQueue.Count > 0 && delQueue.Peek().time <= i)
            {
                sub = (sub + delQueue.Dequeue().val) % mod;
            }
            canShare = ((canShare + (add - sub) % mod) % mod + mod) % mod;
            insQueue.Enqueue((canShare, i + delay));
            delQueue.Enqueue((canShare, i + forget));
            curr = (((curr - sub) % mod + canShare) % mod + mod) % mod;
        }
        return curr;
    }
}