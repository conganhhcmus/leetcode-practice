public class Solution
{
    public int Calculate(string s)
    {
        return Calc(0, s).val;
    }

    private (int val, int idx) Calc(int idx, string s)
    {
        int num = 0;
        char sign = '+';
        Stack<int> st = [];
        while (idx < s.Length)
        {
            if (char.IsDigit(s[idx])) num = num * 10 + (s[idx] - '0');
            else if ("+-*/".Contains(s[idx]))
            {
                Update(st, sign, num);
                num = 0; sign = s[idx];
            }
            else if (s[idx] == '(')
            {
                (num, idx) = Calc(idx + 1, s);
            }
            else if (s[idx] == ')')
            {
                Update(st, sign, num);
                return (Sum(st), idx);
            }
            idx++;
        }
        Update(st, sign, num);
        return (Sum(st), idx);
    }

    private void Update(Stack<int> st, char op, int val)
    {
        if (op == '+') st.Push(val);
        if (op == '-') st.Push(-val);
        if (op == '*') st.Push(st.Pop() * val);
        if (op == '/') st.Push(st.Pop() / val);
    }

    private int Sum(Stack<int> st)
    {
        int sum = 0;
        while (st.Count > 0) sum += st.Pop();
        return sum;
    }
}