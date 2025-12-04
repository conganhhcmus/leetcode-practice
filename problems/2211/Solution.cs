#if DEBUG
namespace Problems_2211;
#endif

public class Solution
{
    public int CountCollisions(string directions)
    {
        Stack<char> st = [];
        int ans = 0;
        foreach (char d in directions)
        {
            char t = d;
            while (st.Count > 0)
            {
                if (st.Peek() == 'R' && t == 'L')
                {
                    st.Pop();
                    t = 'S';
                    ans += 2;
                    continue;
                }

                if (st.Peek() == 'R' && t == 'S' || st.Peek() == 'S' && t == 'L')
                {
                    st.Pop();
                    t = 'S';
                    ans++;
                    continue;
                }
                break;
            }
            st.Push(t);
        }
        return ans;
    }
}