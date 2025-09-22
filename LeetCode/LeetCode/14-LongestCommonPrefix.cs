using System.Text;

namespace LeetCode
{
    [TestClass]
    public class LongestCommonPrefix_14
    {
        [DataTestMethod]
        [DataRow(new string[] { "flower", "flow", "flight" }, "fl", DisplayName = "Starts_FL")]
        [DataRow(new string[] { "dog", "racecar", "car" }, "", DisplayName = "NoCommonPrefix")]
        [DataRow(new string[] { "me", "myself", "motivation" }, "m", DisplayName = "SingleM")]
        [DataRow(new string[] { "computer", "computercode", "computerscience" }, "computer", DisplayName = "Computer")]
        public void LongestCommonPrefix(string[] strs, string expected)
        {
            Assert.AreEqual(expected, Solution.LongestCommonPrefix(strs));
        }
    }

    public partial class Solution
    {
        /// <summary>
        /// This one doesn't Look optimal. Might need to revisit.
        /// </summary>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;
            string first = strs[0];
            int i = 0;
            while (i < first.Length)
            {
                char c = first[i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != c) return first.Substring(0, i);
                }
                i++;
            }
            return first.Substring(0, i);
        }
    }
}
