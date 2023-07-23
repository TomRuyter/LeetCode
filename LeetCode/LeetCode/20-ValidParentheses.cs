namespace LeetCode
{
    [TestClass]
    public class ValidParentheses_20
    {
        [DataTestMethod]
        [DataRow("()", true)]
        [DataRow("()[]{}", true)]
        [DataRow("(]", false)]
        [DataRow("(([]{}{}()))", true)]
        [DataRow("[]{}]", false)]
        public void ValidParentheses(string input, bool expected)
        {
            Assert.AreEqual(expected, Solution.IsValid(input));
        }
    }

    public partial class Solution
    {
        public static bool IsValid(string s)
        {
            // Short circuits
            if (string.IsNullOrEmpty(s) || s.Length == 1) { return false; }
            if (s.StartsWith("}")) { return false; }
            if (s.StartsWith("]")) { return false; }
            if (s.StartsWith(")")) { return false; }

            // Create an input stack
            var stack = new Stack<char>();
            var items = new Dictionary<char, char>
            {
                // Add items to refer to later
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            // go through char stream and see if it's in order
            foreach (var bracket in s.ToCharArray())
            {
                // is this character an opening bracket?
                if (items.ContainsKey(bracket))
                {
                    // Add this opening to the stack.
                    // we'll pop it off later if we need to.
                    stack.Push(bracket);
                }
                else
                {
                    // if this a closing bracket?
                    if (items.ContainsValue(bracket))
                    {
                        // Empty stack.. invalid.
                        if (!stack.Any()) { return false; }

                        // Previous bracket coming off.
                        var lastOpen = stack.Pop();

                        // if the last open bracket's closing value matches this closing bracket,
                        // then we carry on. until it fails or exits.
                        if (items[lastOpen] != bracket)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // Not an opener or a closer... wrong!
                        return false;
                    }
                }
            }

            // Go here? probably good if the stacks empty
            return !stack.Any();
        }
    }
}