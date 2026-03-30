public class Solution
{
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        int sum = 0;
        int[] res = new int[n];
        Stack<(int idx, int t)> st = [];
        int timeLine = 0;
        foreach (string log in logs)
        {
            string[] arr = log.Split(":");
            int id = int.Parse(arr[0]);
            string opt = arr[1];
            int time = int.Parse(arr[2]);
            if (opt == "start")
            {
                if (st.Count > 0)
                {
                    var (idx, t) = st.Pop();
                    res[idx] += time - Math.Max(timeLine, t);
                    st.Push((idx, time));
                }
                st.Push((id, time));
            }
            else
            {
                time++;
                var (idx, t) = st.Pop();
                res[idx] += time - Math.Max(t, timeLine);
            }
            timeLine = time;
        }
        return res;
    }
}