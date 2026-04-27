public class Solution
{
    public string SortVowels(string s)
    {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
        List<int> spots = [];
        Dictionary<char, int> freq = [];
        Dictionary<char, int> debut = [];
        for (int i = 0; i < n; i++)
        {
            char c = arr[i];
            if (vowels.Contains(c))
            {
                spots.Add(i);
                freq[c] = freq.GetValueOrDefault(c, 0) + 1;
                if (!debut.ContainsKey(c))
                {
                    debut[c] = i;
                }
            }
        }

        char[] picked = spots.Select(p => arr[p]).ToArray();
        Array.Sort(picked, (a, b) =>
        {
            if (freq[a] == freq[b]) return debut[a] - debut[b];
            return freq[b] - freq[a];
        });

        for (int i = 0; i < spots.Count; i++)
        {
            arr[spots[i]] = picked[i];
        }

        return new string(arr);
    }
}
