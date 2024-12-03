namespace Problem_1593;

public class Solution
{
    public int MaxUniqueSplit(string s)
    {
        HashSet<string> splits = [];
        int maxSplits = 0;

        void BackTracking(string s)
        {
            if (s.Length == 0)
            {
                maxSplits = Math.Max(maxSplits, splits.Count);
                return;
            }

            for (int i = 1; i <= s.Length; i++)
            {
                string prefix = s[..i];
                if (splits.Add(prefix))
                {
                    BackTracking(s[i..]);
                    splits.Remove(prefix);
                }
            }
        }

        BackTracking(s);

        return maxSplits;
    }
}