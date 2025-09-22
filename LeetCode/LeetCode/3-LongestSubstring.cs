namespace LeetCode
{
    [TestClass]
    public class LongestSubstring_3
    {
        [TestMethod]
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
            // Sliding-window approach: keep the last seen index of each character in a dictionary.
            // Move the start of the window forward when we encounter a repeated character inside the window.
            if (string.IsNullOrEmpty(s)) return 0;

            var lastIndex = new Dictionary<char, int>();
            int maxLen = 0;
            int start = 0; // left boundary of the sliding window

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (lastIndex.TryGetValue(c, out int prev) && prev >= start)
                {
                    // Duplicate inside current window: move start right after previous occurrence
                    start = prev + 1;
                }

                // Update last seen index for this character
                lastIndex[c] = i;

                // Update max length
                int windowLen = i - start + 1;
                if (windowLen > maxLen) maxLen = windowLen;
            }

            return maxLen;
        }
    }
}