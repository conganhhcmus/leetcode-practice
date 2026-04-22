public class Solution
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var res = new List<string>();
        int n = s.Length;

        void Backtrack(int index, List<string> path)
        {
            // if we already have 4 parts
            if (path.Count == 4)
            {
                if (index == n)
                {
                    res.Add(string.Join(".", path));
                }
                return;
            }

            // pruning (important)
            int remainingChars = n - index;
            int remainingParts = 4 - path.Count;
            if (remainingChars < remainingParts || remainingChars > remainingParts * 3)
                return;

            // try length 1 -> 3
            for (int len = 1; len <= 3; len++)
            {
                if (index + len > n) break;

                string segment = s.Substring(index, len);

                // no leading zero
                if (segment.Length > 1 && segment[0] == '0') continue;

                // value check
                int value = int.Parse(segment);
                if (value > 255) continue;

                path.Add(segment);
                Backtrack(index + len, path);
                path.RemoveAt(path.Count - 1); // backtrack
            }
        }

        Backtrack(0, new List<string>());
        return res;
    }
}
