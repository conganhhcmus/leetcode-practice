public class Solution
{
    public int[] ScoreValidator(string[] events)
    {
        int score = 0, counter = 0;
        for (int i = 0; i < events.Length; i++)
        {
            if (events[i] == "W") counter++;
            else if (events[i] == "WD" || events[i] == "NB") score++;
            else score += int.Parse(events[i]);
            if (counter == 10) break;
        }

        return [score, counter];
    }
}
