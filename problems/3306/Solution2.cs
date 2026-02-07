public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        Dictionary<char, int> map = [];
        map['a'] = 0;
        map['e'] = 1;
        map['i'] = 2;
        map['o'] = 3;
        map['u'] = 4;
        int[] vowelCount = new int[5];
        int consonantCount = 0;
        int n = word.Length;
        int[] nextConsonant = new int[n];
        int nextConsonantIndex = n;
        for (int i = n - 1; i >= 0; i--)
        {
            nextConsonant[i] = nextConsonantIndex;
            if (!IsVowel(word[i])) nextConsonantIndex = i;
        }

        long count = 0;
        int l = 0, r = 0;
        while (r < n)
        {
            // insert new letter
            char cRight = word[r];
            if (IsVowel(cRight))
            {
                vowelCount[map[cRight]]++;
            }
            else
            {
                consonantCount++;
            }

            // shrink window if too many consonants
            while (consonantCount > k)
            {
                char cLeft = word[l];
                if (IsVowel(cLeft))
                {
                    vowelCount[map[cLeft]]--;
                }
                else
                {
                    consonantCount--;
                }
                l++;
            }

            // while have a valid window, try to shrink it
            while (l < n && IsOk(vowelCount, consonantCount, k))
            {
                count += nextConsonant[r] - r;
                char cLeft = word[l];
                if (IsVowel(cLeft))
                {
                    vowelCount[map[cLeft]]--;
                }
                else
                {
                    consonantCount--;
                }
                l++;
            }
            r++;
        }

        return count;
    }

    bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    bool IsOk(int[] vowelCount, int consonantCount, int k)
    {
        if (consonantCount != k) return false;
        for (int i = 0; i < vowelCount.Length; i++)
        {
            if (vowelCount[i] == 0) return false;
        }
        return true;
    }
}