namespace LeetCode
{
    [TestClass]
    public class AddBinary_67
    {
        [DataTestMethod]
        [DataRow("11", "1", "100")]
        [DataRow("1010", "1011", "10101")]
        public void AddBinary(string a, string b, string output)
        {
            Assert.AreEqual(new Solution().AddBinary(a, b), output);
        }
    }

    /// <summary>
    /// LeetCode starts here.
    /// </summary>
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            return string.Empty;
        }
    }
}