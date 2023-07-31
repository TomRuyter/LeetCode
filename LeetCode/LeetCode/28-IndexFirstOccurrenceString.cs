namespace LeetCode
{
    [TestClass]
    public class IndexFirstOccurrenceString_28
    {
        [DataTestMethod]
        [DataRow("sadbutsad", "sad", 0)]
        [DataRow("testingtimes", "imes", 8)]
        [DataRow("leetcode", "leeto", -1)]
        [DataRow("averylongboringstring", "string", 15)]
        public void IndexFirstOccurrenceString(string haystack, string needle, int expected)
        {
            var result = Solution.StrStr(haystack, needle);

            Assert.AreEqual(expected, result);
        }
    }

    public partial class Solution
    {
        public static int StrStr(string haystack, string needle)
        {
            // Seeing as this is an inbuilt C# function, I may have missed the point of this one?
            return haystack.IndexOf(needle);
        }
    }
}
