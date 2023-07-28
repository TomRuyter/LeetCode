using System.Text;

namespace LeetCode
{
    [TestClass]
    public class LongestCommonPrefix_14
    {
        [DataTestMethod]
        [DataRow(new string[] { "flower", "flow", "flight" }, "fl", DisplayName = "Starts_FL" )]
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
            // Variables
            var finished = false;
            var currentChar = 0;
            var parts = new Dictionary<string, int>();
            var returnString = new StringBuilder();

            // Short circuits.
            if (!strs.Any()) { return string.Empty; };
            if (strs.Count() == 1 && strs[0].Length == 1) { return strs[0]; }

            // Drop into loop to go through this all.
            while (!finished)
            {
                // What character Key we're currently on.
                var key = string.Empty;

                foreach (var str in strs)
                {
                    // Make sure we don't go over string length.
                    if (!string.IsNullOrWhiteSpace(str) && str.Length - 1 >= currentChar)
                    {
                        // get the part we need to check.
                        key = str[currentChar].ToString();

                        if (parts.ContainsKey(key))
                        {
                            // This exists so increment count.
                            parts[key] += 1;
                        }
                        else
                        {
                            // Add a new one.
                            parts.Add(key, 1);
                        }
                    }
                }

                // See if we have a complete set
                if (parts.ContainsKey(key) && parts[key] == strs.Count())
                {
                    // we do add this char to the output
                    returnString.Append(key);
                    currentChar += 1;

                    // Remove key this incase of duplicates
                    parts.Clear();
                }
                else
                {
                    // We're done.
                    finished = true;
                }
            }

            return returnString.ToString();
        }
    }
}
