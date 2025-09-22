namespace LeetCode
{
    [TestClass]
    public class RemoveElement_27
    {
        [DataTestMethod]
        [DataRow(0, null, 0)]
        [DataRow(0, new int[] { }, 0)]
        [DataRow(2, new[] { 3, 2, 2, 3 }, 3)]
        [DataRow(0, new[] { 1, 1, 1, 1, 1 }, 1)]
        [DataRow(5, new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2)]
        [DataRow(6, new[] { -1, -1, 2, 2, 3, 0, 4, 2 }, -1)]
        public void RemoveDuplicates(int expected, int[] nums, int val)
        {
            Assert.AreEqual(expected, Solution.RemoveElement(nums, val));
        }
    }

    public partial class Solution
    {
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0) return 0;

            int write = 0;
            for (int read = 0; read < nums.Length; read++)
            {
                if (nums[read] != val)
                {
                    nums[write++] = nums[read];
                }
            }
            return write;
        }
    }
}