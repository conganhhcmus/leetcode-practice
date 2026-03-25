public class Solution
{
    public string MergeCharacters(string s, int k)
    {
        while (true)
        {
            bool merge = false;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j <= i + k && j < s.Length; j++)
                {
                    if (s[j] == s[i])
                    {
                        s = s.Remove(j, 1);
                        merge = true;
                        break;
                    }
                }
                if (merge) break;
            }
            if (!merge) break;
        }
        return s;
    }
}