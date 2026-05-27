public class Solution
{
    public IList<IList<string>> WordSquares(string[] words)
    {
        int n = words.Length;
        List<IList<string>> ans = [];
        for (int top = 0; top < n; top++)
        {
            for (int left = 0; left < n; left++)
            {
                for (int right = 0; right < n; right++)
                {
                    for (int bottom = 0; bottom < n; bottom++)
                    {
                        if (top == left || top == right || top == bottom) continue;
                        if (left == right || left == bottom) continue;
                        if (right == bottom) continue;
                        if (words[top][0] == words[left][0]
                            && words[top][3] == words[right][0]
                            && words[bottom][0] == words[left][3]
                            && words[bottom][3] == words[right][3])
                        {
                            ans.Add([words[top], words[left], words[right], words[bottom]]);
                        }
                    }
                }
            }
        }
        ans.Sort((a, b) =>
        {
            if (a[0].CompareTo(b[0]) != 0) return a[0].CompareTo(b[0]);
            if (a[1].CompareTo(b[1]) != 0) return a[1].CompareTo(b[1]);
            if (a[2].CompareTo(b[2]) != 0) return a[2].CompareTo(b[2]);
            return a[3].CompareTo(b[3]);
        });
        return ans;
    }
}
