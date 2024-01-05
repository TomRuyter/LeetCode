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
            // Make this a holder for output.
            var numsToKeep = new Dictionary<int, int>();

            // Sanity checks
            if (nums == null || !nums.Any()) { return 0; }

            // Loop input and create list of items needed.
            foreach (var item in nums)
            {
                if (item != val)
                {
                    if (numsToKeep.ContainsKey(item))
                    {
                        numsToKeep[item]++;
                    }
                    else
                    {
                        numsToKeep.Add(item, 1);
                    }
                }
            }

            // Now re-order arrays using the key values.
            var index = 0;

            foreach (var item in numsToKeep)
            {
                for (var i = 0; i < item.Value; i++)
                {
                    nums[index] = item.Key;
                    index++;
                }
            }

            // Pass back the value now we've modified array.
            return index;
        }
    }
}