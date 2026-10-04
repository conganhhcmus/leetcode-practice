public class Solution
{
    public bool CheckValidString(string s)
    {
        int n = s.Length;
        // check left -> right, no ')' > '(' + '*'
        int bal = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == ')') bal--;
            else bal++;
            if (bal < 0) return false;
        }
        // check right -> left , no '(' > ')' + '*'
        bal = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == '(') bal--;
            else bal++;
            if (bal < 0) return false;
        }
        return true;
    }
}