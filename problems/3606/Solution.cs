public class Solution
{
    public IList<string> ValidateCoupons(
        string[] code,
        string[] businessLine,
        bool[] isActive)
    {
        var result = new List<(string Code, string BusinessLine)>();

        int n = code.Length;
        for (int i = 0; i < n; i++)
        {
            if (string.IsNullOrEmpty(code[i])) continue;
            if (!isActive[i]) continue;
            if (!IsValidBusinessLine(businessLine[i])) continue;

            bool isValid = true;
            foreach (char c in code[i])
            {
                if (!IsValidCode(c))
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                result.Add((code[i], businessLine[i]));
            }
        }

        // business line priority
        var order = new Dictionary<string, int>
        {
            { "electronics", 0 },
            { "grocery", 1 },
            { "pharmacy", 2 },
            { "restaurant", 3 }
        };

        result.Sort((a, b) =>
        {
            int cmp = order[a.BusinessLine].CompareTo(order[b.BusinessLine]);
            if (cmp != 0) return cmp;
            return string.CompareOrdinal(a.Code, b.Code);
        });

        return result.Select(x => x.Code).ToList();
    }

    bool IsValidCode(char c)
    {
        return char.IsDigit(c)
            || (c >= 'a' && c <= 'z')
            || (c >= 'A' && c <= 'Z')
            || c == '_';
    }

    bool IsValidBusinessLine(string val)
    {
        return val == "electronics"
            || val == "grocery"
            || val == "pharmacy"
            || val == "restaurant";
    }
}
