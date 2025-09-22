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
            if (string.IsNullOrEmpty(s)) return 0;

            int i = s.Length - 1;
            // skip trailing spaces
            while (i >= 0 && s[i] == ' ') i--;
            int length = 0;
            while (i >= 0 && s[i] != ' ')
            {
                length++; i--;
            }

            return length;
        }
    }
}
