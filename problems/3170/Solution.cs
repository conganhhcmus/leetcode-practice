public class Solution
{
    public string ClearStars(string s)
    {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        Stack<int>[] map = new Stack<int>[26];
        for (int i = 0; i < 26; i++)
        {
            map[i] = new();
        }
        char minCh = 'z';
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '*')
            {
                while (minCh < 'z' && map[minCh - 'a'].Count <= 0) minCh++;
                int idx = map[minCh - 'a'].Pop();
                arr[idx] = '*';
            }
            else
            {
                map[s[i] - 'a'].Push(i);
                if (minCh > s[i]) minCh = s[i];
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == '*') continue;
            sb.Append(arr[i]);
        }
        return sb.ToString();
    }
}