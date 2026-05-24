public class Solution
{
    public int PasswordStrength(string password)
    {
        HashSet<char> seen = [];
        int point = 0;
        foreach (char c in password)
        {
            if (seen.Add(c))
            {
                if (c >= 'a' && c <= 'z') point += 1;
                else if (c >= 'A' && c <= 'Z') point += 2;
                else if (c >= '0' && c <= '9') point += 3;
                else if (c == '!' || c == '@' || c == '#' || c == '$') point += 5;
            }
        }
        return point;
    }
}
