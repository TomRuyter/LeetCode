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
            // Negative numbers are not palindromes.
            if (x < 0) return false;

            // Numbers ending with 0 are not palindromes unless the number is 0.
            if (x % 10 == 0 && x != 0) return false;

            // Reverse half of the number. When the reversed half is >= the remaining half,
            // we've processed at least half the digits. This avoids converting to string and
            // also avoids overflow by only reversing half the digits.
            int reverted = 0;
            while (x > reverted)
            {
                reverted = reverted * 10 + x % 10;
                x /= 10;
            }

            // For even length numbers, x == reverted. For odd length numbers, the middle digit
            // is in reverted, so remove it by reverted/10.
            return x == reverted || x == reverted / 10;
        }
    }
}
