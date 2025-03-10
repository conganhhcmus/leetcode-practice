#if DEBUG
namespace Problems_3306_3;
#endif

public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        return AtLeastK(word, k) - AtLeastK(word, k + 1);
    }

    long AtLeastK(string word, int k)
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

            // while have a valid window, try to shrink it
            while (l < n && IsOk(vowelCount, consonantCount, k))
            {
                count += n - r;
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
        if (consonantCount < k) return false;
        for (int i = 0; i < vowelCount.Length; i++)
        {
            if (vowelCount[i] == 0) return false;
        }
        return true;
    }
}