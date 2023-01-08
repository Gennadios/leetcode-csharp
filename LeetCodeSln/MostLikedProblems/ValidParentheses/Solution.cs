namespace MostLikedProblems.ValidParentheses;

/*
    Given a string s containing just the characters
    '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

    An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.
*/

public class Solution
{
    private static readonly Dictionary<char, char> CloseToOpenMap = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' }
    };

    public bool IsValid(string s)
    {
        if (s.Length % 2 == 1)
        {
            return false;
        }

        var resultStack = new Stack<char>();

        foreach (char c in s)
        {
            // If the first character is an opening parenthesis, it's not a valid string.
            if (resultStack.Count == 0 && CloseToOpenMap.ContainsKey(c))
            {
                return false;
            }

            if (!CloseToOpenMap.ContainsKey(c))
            {
                resultStack.Push(c);
            }
            else if (resultStack.Count != 0 && resultStack.Peek() == CloseToOpenMap[c])
            {
                resultStack.Pop();
            }
            else
            {
                resultStack.Push(c);
            }
        }

        return resultStack.Count == 0;
    }
}