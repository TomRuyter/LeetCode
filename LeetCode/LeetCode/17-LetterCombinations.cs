namespace LeetCode
{
    [TestClass]
    public class LetterCombinations_17
    {
        [TestMethod]
        [DataRow("", new string[] { "" })]
        [DataRow("2", new string[] { "a", "b", "c" })]
        [DataRow("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
        public void LetterCombinations(string nums, string[] expected)
        {
            var result = Solution.LetterCombinations(nums);

            foreach (var item in result)
            {
                Assert.IsTrue(expected.Contains(item));
            }
        }
    }

    public partial class Solution
    {
        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> res = [];
            if (string.IsNullOrEmpty(digits))
            {
                return res;
            }

            // initializing the input dictionary 
            var lettersMap = new Dictionary<char, char[]>
            {
                { '1', null! },
                { '2', new[] { 'a', 'b', 'c' } },
                { '3', new[] { 'd', 'e', 'f' } },
                { '4', new[] { 'g', 'h', 'i' } },
                { '5', new[] { 'j', 'k', 'l' } },
                { '6', new[] { 'm', 'n', 'o' } },
                { '7', new[] { 'p', 'q', 'r', 's' } },
                { '8', new[] { 't', 'u', 'v' } },
                { '9', new[] { 'w', 'x', 'y', 'z' } },
                { '0', null! }
            };

            res.Add(string.Empty);

            foreach (char d in digits)
            {
                IList<string> next = [];

                var letterList = lettersMap[d];

                foreach (char letter in letterList)
                {
                    foreach (string s in res)
                    {
                        next.Add(s + letter);
                    }
                }
                res = next;
            }

            return res;
        }
    }
}
