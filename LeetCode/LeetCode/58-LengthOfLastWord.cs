namespace LeetCode
{
    [TestClass]
    public class LengthOfLastWord_58
    {
        [DataTestMethod]
        [DataRow("Hello World", 5)]
        [DataRow("   fly me   to   the moon  ", 4)]
        [DataRow("luffy is still joyboy", 6)]
        public void LengthOfLastWord(string s, int expected)
        {
            var result = Solution.LengthOfLastWord(s);

            Assert.AreEqual(expected, result);
        }
    }

    public partial class Solution
    {
        public static int LengthOfLastWord(string s)
        {
            // Trim any traling spaces
            s = s.Trim();
            var items = s.Split(" ");

            // Return the index.
            return items[^1].Length;
        }
    }
}
