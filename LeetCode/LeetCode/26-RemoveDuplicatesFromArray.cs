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
            // Make this a holder for output.
            var singleNums = new List<int>();

            // Sanity checks
            if (nums == null || !nums.Any()) { return 0; }

            // Loop input and create list of items needed.
            // If we need to create an index in the dictionary, it means it's in the array.
            foreach (var item in nums)
            {
                if (!singleNums.Contains(item))
                {
                    singleNums.Add(item);
                }
            }

            // Now re-order arrays using the key values.
            singleNums.CopyTo(nums, 0);

            // Pass back the value now we've modified array.
            return singleNums.Count;
        }
    }
}