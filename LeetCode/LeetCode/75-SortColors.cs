namespace LeetCode
{
    [TestClass]
    public class SortColors_75
    {
        [TestMethod]
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
            int low = 0, mid = 0, high = nums.Length - 1;
            while (mid <= high)
            {
                switch (nums[mid])
                {
                    case 0:
                        (nums[low], nums[mid]) = (nums[mid], nums[low]);
                        low++; mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        (nums[mid], nums[high]) = (nums[high], nums[mid]);
                        high--;
                        break;
                }
            }
        }
    }
}
