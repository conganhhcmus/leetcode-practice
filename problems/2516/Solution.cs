namespace Problem_2516;

public class Solution
{
    public int TakeCharacters(string s, int k)
    {
        if (k == 0) return 0;
        int[] map = new int['c' - 'a' + 1];
        foreach (var c in s)
        {
            map[c - 'a']++;
        }
        if (map.Any(x => x < k)) return -1;

        int left = 0;
        int right = 0;
        while (right < s.Length && map[s[right] - 'a'] > k)
        {
            map[s[right] - 'a']--;
            right++;
        }

        int min = s.Length - right;
        while (left < s.Length)
        {
            map[s[left] - 'a']++;
            while (right < s.Length && map[s[right] - 'a'] > k)
            {
                map[s[right] - 'a']--;
                right++;
            }
            min = Math.Min(min, left + 1 + s.Length - right);
            left++;
        }

        return min;
    }
}