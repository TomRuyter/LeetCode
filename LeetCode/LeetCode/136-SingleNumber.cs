namespace LeetCode
{
    [TestClass]
    public class SingleNumber_136
    {
        [DataTestMethod]
        [DataRow(new int[] { 2,2,1 }, 1)]
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
            var numbers = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (numbers.ContainsKey(num))
                {
                    numbers[num] += 1;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }

            return numbers.First(x => x.Value == 1).Key;
        }
    }
}
