using System.Text;

namespace LeetCode
{
    [TestClass]
    public class AddBinary_67
    {
        [TestMethod]
        [DataRow("11", "1", "100")]
        [DataRow("1111", "1111", "11110")]
        [DataRow("1010", "1011", "10101")]
        public void AddBinary(string a, string b, string expected)
        {
            Assert.AreEqual(expected, Solution.AddBinary(a, b));
        }
    }

    /// <summary>
    /// LeetCode starts here.
    /// </summary>
    public partial class Solution
    {
        public static string AddBinary(string a, string b)
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
                int va = a[i] - '0';
                int vb = b[i] - '0';
                int sum = va + vb + carry;
                result.Append((char)('0' + (sum & 1)));
                carry = sum >> 1;
            }

            // Still have left overs?
            if (carry > 0) { result.Append('1'); }

            // pass back what we have, but reverse it.
            return new string([.. result.ToString().Reverse()]);
        }
    }
}