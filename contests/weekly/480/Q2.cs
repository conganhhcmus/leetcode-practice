public class Solution
{
    public string ReverseWords(string s)
    {
        string[] words = s.Split(' ');
        int cnt = CountVowels(words[0]);
        List<string> ans = [];
        ans.Add(words[0]);
        for (int i = 1; i < words.Length; i++)
        {
            string w = words[i];
            if (CountVowels(w) == cnt) w = ReverseWords(w);
            ans.Add(w);
        }
        return string.Join(" ", ans);

        string ReverseWords(string w)
        {
            char[] arr = w.ToCharArray();
            Array.Reverse(arr);
            return new(arr);
        }

        int CountVowels(string w)
        {
            int cnt = 0;
            foreach (char c in w)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') cnt++;
            }
            return cnt;
        }
    }
}
