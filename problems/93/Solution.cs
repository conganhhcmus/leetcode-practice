public class Solution
{
    public IList<string> RestoreIpAddresses(string s)
    {
        IList<string> res = [];
        void Backtracking(int pos, int dot, string val, string curr, string s)
        {
            if (!IsValid(val)) return;

            if (pos >= s.Length)
            {
                if (dot == 0)
                {
                    curr += val;
                    res.Add(curr);
                }
                return;
            }

            // skip
            Backtracking(pos + 1, dot, val + s[pos], curr, s);

            // add dot
            if (val != "")
            {
                Backtracking(pos + 1, dot - 1, "" + s[pos], curr + val + ".", s);
            }
        }

        Backtracking(0, 3, "", "", s);

        return res;
    }

    bool IsValid(string s)
    {
        if (s != "" && int.Parse(s) > 255) return false;
        if (s.Length > 1 && s[0] == '0') return false;
        return true;
    }
}
