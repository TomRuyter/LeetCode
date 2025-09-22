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
            // Use a dictionary that maps value -> index for a single-pass O(n) solution.
            var seen = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // If we've seen the complement before, return its index and the current index.
                if (seen.TryGetValue(complement, out int j))
                {
                    return [j, i];
                }

                // Store the current number and its index. Do not overwrite an existing index;
                // we want the earliest index for correctness with duplicates.
                if (!seen.ContainsKey(nums[i]))
                {
                    seen[nums[i]] = i;
                }
            }

            // If no solution is found, return the original sentinel value used previously.
            return [0, 0];
        }
    }
}
