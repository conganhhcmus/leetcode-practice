#if DEBUG
using System.Text;

#endif

public class Solution
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        List<string> result = [];
        for (int i = 0; i < words.Length; i++)
        {
            int width = words[i].Length;
            int st = i;
            while (st + 1 < words.Length && (width + words[st + 1].Length) < maxWidth - (st - i))
            {
                st++;
                width += words[st].Length;
            }
            if (st == words.Length - 1)
            {
                string spaces = string.Join("", Enumerable.Repeat(' ', maxWidth - width - (st - i)));
                result.Add(string.Join(" ", words[i..(st + 1)]) + spaces);
            }
            else if (st == i)
            {
                string spaces = string.Join("", Enumerable.Repeat(' ', maxWidth - width));
                result.Add(words[i] + spaces);
            }
            else
            {
                if ((maxWidth - width) % (st - i) == 0)
                {
                    string spaces = string.Join("", Enumerable.Repeat(' ', (maxWidth - width) / (st - i)));
                    result.Add(string.Join(spaces, words[i..(st + 1)]));
                }
                else
                {
                    string spaces = string.Join("", Enumerable.Repeat(' ', (maxWidth - width) / (st - i)));
                    StringBuilder sb = new();
                    int k = 0;
                    for (; k < (maxWidth - width) % (st - i); k++)
                    {
                        sb.Append(words[k + i]);
                        sb.Append(spaces + " ");
                    }
                    for (; k < (st - i); k++)
                    {
                        sb.Append(words[k + i]);
                        sb.Append(spaces);
                    }
                    sb.Append(words[k + i]);
                    result.Add(sb.ToString());
                }

            }
            i = st;
        }

        return result;
    }
}