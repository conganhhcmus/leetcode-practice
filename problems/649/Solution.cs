public class Solution
{
    public string PredictPartyVictory(string senate)
    {
        Queue<int> rad = new();
        Queue<int> dir = new();
        for (int i = 0; i < senate.Length; i++)
        {
            if (senate[i] == 'R') rad.Enqueue(i);
            else dir.Enqueue(i);
        }

        int index = senate.Length;
        while (rad.Count > 0 && dir.Count > 0)
        {
            if (rad.Dequeue() < dir.Dequeue())
            {
                rad.Enqueue(index);
            }
            else
            {
                dir.Enqueue(index);
            }
            index++;
        }

        return rad.Count > 0 ? "Radiant" : "Dire";
    }
}