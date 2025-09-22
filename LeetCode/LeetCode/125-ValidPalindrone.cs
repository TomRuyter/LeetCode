using System.Text;

namespace LeetCode
{
    [TestClass]
    public class ValidPalindrone_125
    {
        [DataTestMethod]
        [DataRow(" ", true)]
        [DataRow("a race car", false)]
        [DataRow("A man, a plan, a canal: Panama", true)]
        public void IsPalindrome(string s, bool expected)
        {
            Assert.AreEqual(expected, Solution.IsPalindrome(s));
        }
    }

    public partial class Solution
    {
        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;

                if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right])) return false;

                left++; right--;
            }

            return true;
        }
    }
}
