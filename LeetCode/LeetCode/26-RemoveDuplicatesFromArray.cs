namespace LeetCode
{
    [TestClass]
    public class RemoveDuplicatesFromArray_26
    {
        [DataTestMethod]
        [DataRow(0, null)]
        [DataRow(0, new int[] { })]
        [DataRow(2, new[] { 1, 1, 2 })]
        [DataRow(3, new[] { 1, 3, 2, 2, 1, 3 })]
        [DataRow(5, new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 })]
        public void RemoveDuplicates(int expected, int[] nums)
        {
            Assert.AreEqual(expected, Solution.RemoveDuplicates(nums));
        }
    }

    public partial class Solution
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var seen = new HashSet<int>();
            var uniques = new List<int>();

            foreach (var v in nums)
            {
                if (seen.Add(v)) // Add returns true if v wasn't present
                {
                    uniques.Add(v);
                }
            }

            uniques.CopyTo(nums, 0);
            return uniques.Count;
        }
    }
}