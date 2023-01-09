namespace MostLikedProblems.ValidParentheses;

public class SolutionTwo
{
    private static readonly Dictionary<char, char> OpeningToClosingMap = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    public bool IsValid(string s)
    {
        if (s.Length % 2 == 1)
        {
            return false;
        }

        var stack = new Stack<char>();

        foreach (char c in s)
        {
            if (OpeningToClosingMap.ContainsKey(c))
            {
                stack.Push(OpeningToClosingMap[c]);
            }
            else if (stack.Count == 0 || stack.Pop() != c)
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}