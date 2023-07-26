namespace LeetCode
{
    [TestClass]
    public class PalindromeNumber_9
    {
        [DataTestMethod]
        [DataRow(121, true)]
        [DataRow(-121, false)]
        [DataRow(10, false)]
        public void PalindromeNumber(int number, bool expected)
        {
            Assert.AreEqual(expected, Solution.IsPalindrome(number));
        }
    }

    public partial class Solution
    {
        public static bool IsPalindrome(int x)
        {
            // See if this can't be reversed
            if (x < 0) return false;

            // Use strings.
            var array = x.ToString().ToCharArray();
            Array.Reverse(array);
            return x.ToString() == new string(array);
        }
    }
}
