using System.Text;

namespace LeetCode
{
    [TestClass]
    public class TwoSum_1
    {
        [DataTestMethod]
        [DataRow(new int[] { 3, 4 }, 7, new int[] { 0, 1 })]
        [DataRow(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [DataRow(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        public void TwoSum(int[] nums, int target, int[] expected)
        {
            var result = Solution.TwoSum(nums, target);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }

    public partial class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            // Probably need this for figuring out the index of the ones that match.
            var numbers = new Dictionary<int, int>();

            // Go through each number.
            for (int i = 0; i < nums.Length; i++)
            {
                // Add the numbers into the list.
                numbers.Add(i, nums[i]);

                if (numbers.Count > 1)
                {
                    // See if we can find a match
                    foreach (var item in numbers)
                    {
                        if (item.Key != i)
                        {
                            if (item.Value + nums[i] == target)
                            {
                                return new int[] { item.Key, i };
                            }

                        }
                    }
                }

            }

            return new int[] { 0, 0 };
        }
    }
}
