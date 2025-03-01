#if DEBUG
namespace Problems_127;
#endif

public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        Dictionary<string, List<string>> graph = [];
        foreach (var word in wordList)
        {
            if (IsDiffOne(beginWord, word))
            {
                graph.TryAdd(beginWord, []);
                graph[beginWord].Add(word);
                graph.TryAdd(word, []);
                graph[word].Add(beginWord);
            }
        }
        for (int i = 0; i < wordList.Count; i++)
        {
            for (int j = i + 1; j < wordList.Count; j++)
            {
                string wordA = wordList[i];
                string wordB = wordList[j];
                if (IsDiffOne(wordA, wordB))
                {
                    graph.TryAdd(wordA, []);
                    graph[wordA].Add(wordB);
                    graph.TryAdd(wordB, []);
                    graph[wordB].Add(wordA);
                }
            }
        }
        Queue<string> queue = [];
        HashSet<string> visited = [];
        queue.Enqueue(beginWord);
        visited.Add(beginWord);
        int step = 1;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                string curr = queue.Dequeue();
                if (curr == endWord) return step;
                foreach (var neighbor in graph.GetValueOrDefault(curr, []))
                {
                    if (!visited.Add(neighbor)) continue;
                    queue.Enqueue(neighbor);
                }
            }
            step++;
        }

        return 0;
    }

    private bool IsDiffOne(string a, string b)
    {
        int diff = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i]) diff++;
            if (diff > 1) return false;
        }
        return diff == 1;
    }
}