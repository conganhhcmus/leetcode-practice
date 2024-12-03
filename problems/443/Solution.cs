namespace Problem_443;

public class Solution
{
    public int Compress(char[] chars)
    {
        int count = 0;
        int current = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            if (i == 0 || chars[i] != chars[i - 1])
            {
                if (count > 1)
                {
                    foreach (char c in count.ToString())
                    {
                        chars[current++] = c;
                    }
                }

                chars[current] = chars[i];
                count = 1;
                current++;
            }
            else
            {
                count++;
            }
        }

        if (count > 1)
        {
            foreach (char c in count.ToString())
            {
                chars[current++] = c;
            }
        }

        return current;
    }
}