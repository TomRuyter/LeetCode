using System.Text;

namespace LeetCode
{
    [TestClass]
    public class ValidPalindrone_125
    {
        [DataTestMethod]
        [DataRow(" ", true)]
        [DataRow("a race car", false)]
        [DataRow("A man, a plan, a canal: Panama", true )]
        public void IsPalindrome(string s, bool expected)
        {
            Assert.AreEqual(expected, new Solution().IsPalindrome(s));
        }
    }

    public partial class Solution
    {
        public bool IsPalindrome(string s)
        {
            // Create valid items list
            var output = new StringBuilder();
            var valid = new char[] { 'a', 'b', 'c', 'd', 'e','f','g','h','i','j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            // sanitise
            s = s.ToLower();

            // Loop Through.
            foreach (var ch in s.ToCharArray())
            {
                if (valid.Contains(ch))
                {
                    output.Append(ch);
                }
            }

            // Run Check
            var final = output.ToString();
            return final == new string(final.Reverse().ToArray());
        }
    }
}
