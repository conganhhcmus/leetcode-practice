public class Solution
{
    public string LexSmallest(string s)
    {
        string ans = s;
        char[] arr = s.ToCharArray();
        int n = s.Length;
        // opt1
        for (int i = 0; i < n; i++)
        {
            Reverse(arr, 0, i);
            string tmp = new(arr);
            if (ans.CompareTo(tmp) > 0) ans = tmp;
            Reverse(arr, 0, i);
        }
        // opt2
        for (int i = n - 1; i >= 0; i--)
        {
            Reverse(arr, i, n - 1);
            string tmp = new(arr);
            if (ans.CompareTo(tmp) > 0) ans = tmp;
            Reverse(arr, i, n - 1);
        }

        return ans;

        void Reverse(char[] arr, int st, int ed)
        {
            int len = ed - st + 1;
            for (int i = 0; i < len / 2; i++)
            {
                (arr[st + i], arr[ed - i]) = (arr[ed - i], arr[st + i]);
            }
        }
    }
}
