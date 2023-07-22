using System.Text;

namespace LeetCode
{
    [TestClass]
    public class AddBinary_67
    {
        [DataTestMethod]
        [DataRow("11", "1", "100")]
        [DataRow("1111", "1111", "11110")]
        [DataRow("1010", "1011", "10101")]
        public void AddBinary(string a, string b, string expected)
        {
            Assert.AreEqual(expected, new Solution().AddBinary(a, b));
        }
    }

    /// <summary>
    /// LeetCode starts here.
    /// </summary>
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            // Variables
            var carry = 0;
            var result = new StringBuilder();

            // Normalise strings. Easier for loops
            if (a.Length > b.Length) { b = b.PadLeft(a.Length, '0'); }
            if (b.Length > a.Length) { a = a.PadLeft(b.Length, '0'); }

            // loop through characters
            for (int i = a.Length - 1; i >= 0; i--)
            {
                var value = int.Parse(a.Substring(i, 1)) + int.Parse(b.Substring(i, 1)) + carry;

                if (value > 1)
                {
                    if (value == 2)
                    {
                        carry = 1;
                        result.Append('0');
                    }

                    if (value == 3)
                    {
                        carry = 1;
                        result.Append('1');
                    }
                }
                else
                {
                    carry = 0;
                    result.Append(value);
                }
            }

            // Still have left overs?
            if (carry > 0) { result.Append('1'); }

            // pass back what we have, but reverse it.
            return new string(result.ToString().Reverse().ToArray());
        }
    }
}