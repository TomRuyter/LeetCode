namespace LeetCode
{
    [TestClass]
    public class PascalsTriangle_118
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(30)]
        public void PascalsTriangle(int numRows)
        {
            var result = Solution.Generate(numRows);

            Assert.AreEqual(numRows, result.Count);
        }
    }

    public partial class Solution
    {
        public static IList<IList<int>> Generate(int numRows)
        {
            // Shouldn't run, just return empty lists
            if (numRows <= 0)
            {
                return [];
            }

            // Create the ones that we know don't change. Effectively "Seed" the result array with
            // static content.
            var result = new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 1, 1 }
            };

            // See if we need to just return static results.
            if (numRows == 1) { return [result.First()]; }
            if (numRows == 2) { return result; }

            // Loop through each row and build up as needed.
            for (int i = 2; i < numRows; i++)
            {
                // New row items and get me the previous nodes data
                var rowItems = new List<int>();
                var previous = result[i - 1];

                // Go through the previous node and see what indexes we need to create.
                for (int j = 0; j < previous.Count + 1; j++)
                {
                    if (j == 0 || j == previous.Count)
                    {
                        // Just add "1" if we are the start or end of this row.
                        rowItems.Add(1);
                    }
                    else
                    {
                        // Else calculate the number based on the previous node index plus the one
                        // next to it.
                        rowItems.Add(previous[j - 1] + previous[j]);
                    }
                }

                // Add this result.
                result.Add(rowItems);
            }

            return result;
        }
    }
}