namespace Problem_3043;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] arr1 = [1, 10, 100];
        int[] arr2 = [1000];

        Console.WriteLine(solution.LongestCommonPrefix(arr1, arr2));
    }

    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        //return UsingHashTable(arr1, arr2);
        return UsingTrie(arr1, arr2);
    }
    public int UsingHashTable(int[] arr1, int[] arr2)
    {
        HashSet<int> set1 = [];
        HashSet<int> set2 = [];
        for (int i = 0; i < arr1.Length; i++)
        {
            int tmp = arr1[i];
            while (tmp > 0)
            {
                set1.Add(tmp);
                tmp /= 10;
            }
        }

        for (int i = 0; i < arr2.Length; i++)
        {
            int tmp = arr2[i];
            while (tmp > 0)
            {
                set2.Add(tmp);
                tmp /= 10;
            }
        }

        //Console.WriteLine($"[{string.Join(",", set1)}]");
        //Console.WriteLine($"[{string.Join(",", set2)}]");
        int ans = 0;
        foreach (int num in set1)
        {
            if (set2.Contains(num))
            {
                ans = int.Max(ans, num);
            }
        }

        return ans > 0 ? ans.ToString().Length : 0;
    }

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[10];
    }

    public class Trie
    {
        private readonly TrieNode root = new();

        public void Insert(int num)
        {
            TrieNode node = root;
            string numStr = num.ToString();
            foreach (char digit in numStr.ToCharArray())
            {
                int idx = digit - '0';
                if (node.children[idx] == null)
                {
                    node.children[idx] = new TrieNode();
                }
                node = node.children[idx];
            }
        }

        public int FindLongestPrefix(int num)
        {
            TrieNode node = root;
            string numStr = num.ToString();
            int len = 0;
            foreach (char digit in numStr.ToCharArray())
            {
                int idx = digit - '0';
                if (node.children[idx] == null)
                {
                    break;
                }

                len++;
                node = node.children[idx];
            }

            return len;
        }
    }


    public int UsingTrie(int[] arr1, int[] arr2)
    {
        Trie trie = new();

        foreach (int num in arr1)
        {
            trie.Insert(num);
        }

        int maxLen = 0;
        foreach (int num in arr2)
        {
            maxLen = int.Max(maxLen, trie.FindLongestPrefix(num));
        }

        return maxLen;
    }
}