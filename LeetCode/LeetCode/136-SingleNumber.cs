namespace LeetCode
{
    [TestClass]
    public class SingleNumber_136
    {
        [DataTestMethod]
        [DataRow(new int[] { 2, 2, 1 }, 1)]
        [DataRow(new int[] { 4, 1, 2, 2, 1 }, 4)]
        [DataRow(new int[] { 9 }, 9)]
        [DataRow(new int[] { 1, 1, 2, 2, 3, 4, 3, 4, 6 }, 6)]
        [DataRow(new int[] { 0 }, 0)]
        public void SingleNumber(int[] nums, int expected)
        {
            Assert.AreEqual(expected, Solution.SingleNumber(nums));
        }
    }

    public partial class Solution
    {
        public static int SingleNumber(int[] nums)
        {
            // XOR all numbers. Duplicates cancel out, leaving the unique number.
            int res = 0;
            foreach (var num in nums)
            {
                res ^= num;
            }
            return res;
        }
    }
}
