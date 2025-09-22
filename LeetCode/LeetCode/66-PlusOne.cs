namespace LeetCode
{
    [TestClass]
    public class PlusOne_66
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
        [DataRow(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
        [DataRow(new int[] { 9 }, new int[] { 1, 0 })]
        public void PlusOne(int[] digits, int[] expected)
        {
            var result = Solution.PlusOne(digits);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }

    public partial class Solution
    {
        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }

            // If we're here all digits were 9, so we need an extra digit at the front.
            var res = new int[digits.Length + 1];
            res[0] = 1;
            return res;
        }
    }
}
