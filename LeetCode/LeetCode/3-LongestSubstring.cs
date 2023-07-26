namespace LeetCode
{
    [TestClass]
    public class LongestSubstring_3
    {
        [DataTestMethod]
        [DataRow("abcabcbb", 3)]
        [DataRow("bbbbb", 1)]
        [DataRow("pwwkew", 3)]
        public void LengthOfLongestSubstring(string s, int expected)
        {
            Assert.AreEqual(expected, Solution.LengthOfLongestSubstring(s));
        }
    }
    public partial class Solution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            // Storage for the current item
            var highest = 0;
            var current = new Dictionary<char, int>();
            var chars = s.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                var currentChar = chars[i];

                if (current.Any())
                {
                    // See if this is contains the char key
                    if (current.ContainsKey(currentChar))
                    {
                        // Find the index of the last occurrence of this char.
                        var charCount = current.Count;
                        var index = current[currentChar] + 1;

                        // see if we need to update the highest.
                        if (charCount > highest)
                        {
                            highest = current.Count;
                        }

                        // Reset based on index of matching char
                        current.Clear();
                        current.Add(chars[index], index);

                        // Reset index.
                        i = index;
                    }
                    else
                    {
                        current.Add(currentChar, i);
                    }
                }
                else
                {
                    // just add the first
                    current.Add(currentChar, i);
                }
            }

            // So, second check here for getting to end of unique string.
            if (current.Count > highest) { highest = current.Count; }

            return highest;
        }
    }
}