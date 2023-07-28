namespace LeetCode
{
    [TestClass]
    public class SortColors_75
    {
        [DataTestMethod]
        [DataRow(new int[] { 2, 0, 2, 1, 1, 0 }, new int[] { 0, 0, 1, 1, 2, 2 }, DisplayName = $"{nameof(SortColors)}_Five")]
        [DataRow(new int[] { 2, 0, 1 }, new int[] { 0, 1, 2 }, DisplayName = $"{nameof(SortColors)}_ThreeStartsWithTwo")]
        [DataRow(new int[] { 0, 0, 1 }, new int[] { 0, 0, 1 }, DisplayName = $"{nameof(SortColors)}_DuplicateZeros")]
        [DataRow(new int[] { 2, 2, 0 }, new int[] { 0, 2, 2 }, DisplayName = $"{nameof(SortColors)}_DuplicateTwos")]
        public void SortColors(int[] nums, int[] expected)
        {
            Solution.SortColors(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                Assert.AreEqual(expected[i], nums[i]);
            }
        }
    }

    public partial class Solution
    {
        public static void SortColors(int[] nums)
        {
            var colourCounts = new Dictionary<int, int>
            {
                { 0, 0 },
                { 1, 0 },
                { 2, 0 }
            };

            // Store the amounts of each number.
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                colourCounts[nums[i]] += 1;
            }

            // Write them back out.
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                if (colourCounts[0] > 0)
                {
                    nums[i] = 0;
                    colourCounts[0] -= 1;
                    continue;
                }

                if (colourCounts[1] > 0)
                {
                    nums[i] = 1;
                    colourCounts[1] -= 1;
                    continue;
                }

                if (colourCounts[2] > 0)
                {
                    nums[i] = 2;
                    colourCounts[2] -= 1;
                    continue;
                }
            }
        }
    }
}
