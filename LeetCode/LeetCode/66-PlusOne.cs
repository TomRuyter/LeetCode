namespace LeetCode
{
    [TestClass]
    public class PlusOne_66
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
        [DataRow(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
        [DataRow(new int[] { 9 }, new int[] { 1, 0 })]
        public void PlusOne(int[] digits, int[] expected)
        {
            var result = Solution.PlusOne(digits);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(result[i] == expected[i]);
            }
        }
    }

    public partial class Solution
    {
        public static int[] PlusOne(int[] digits)
        {
            var digitList = digits.Reverse().ToList();

            for (var i = 0; i < digitList.Count; i++)
            {
                digitList[i] += 1;

                // Reverse Array, Create List.
                bool previous9;
                if (digitList[i] > 9)
                {
                    previous9 = true;
                    digitList[i] = 0;
                }
                else
                {
                    break;
                }

                // Final check for a floating digit
                if (i == digitList.Count - 1 && previous9)
                {
                    digitList.Add(1);
                    break;
                }
            }

            digitList.Reverse();
            return digitList.ToArray();
        }
    }
}
