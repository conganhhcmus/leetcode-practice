public class Solution
{
    string s;
    int idx;

    public IList<string> BraceExpansionII(string expression)
    {
        s = expression;
        idx = 0;

        HashSet<string> result = ParseExpression();

        return result
            .OrderBy(x => x)
            .ToList();
    }

    HashSet<string> ParseExpression()
    {
        // expression = concatenation (',' concatenation)*
        HashSet<string> result = ParseConcatenation();

        while (idx < s.Length && s[idx] == ',')
        {
            idx++; // skip ','

            HashSet<string> right = ParseConcatenation();

            result.UnionWith(right);
        }

        return result;
    }

    HashSet<string> ParseConcatenation()
    {
        // concatenation = factor+
        HashSet<string> result = new() { "" };

        while (idx < s.Length &&
               s[idx] != '}' &&
               s[idx] != ',')
        {
            HashSet<string> factor = ParseFactor();

            result = Multiply(result, factor);
        }

        return result;
    }

    HashSet<string> ParseFactor()
    {
        if (s[idx] >= 'a' && s[idx] <= 'z')
        {
            return new HashSet<string>
            {
                s[idx++].ToString()
            };
        }

        // {
        idx++; // skip '{'

        HashSet<string> result = ParseExpression();

        idx++; // skip '}'

        return result;
    }

    HashSet<string> Multiply(
        HashSet<string> left,
        HashSet<string> right)
    {
        HashSet<string> result = [];

        foreach (string a in left)
        {
            foreach (string b in right)
            {
                result.Add(a + b);
            }
        }

        return result;
    }
}