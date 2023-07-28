namespace LeetCode
{
    [TestClass]
    public class RomanToInt_13
    {
        [DataTestMethod]
        [DataRow("III", 3)]
        [DataRow("LVIII", 58)]
        [DataRow("MCMXCIV", 1994)]
        [DataRow("MMD", 2500)]
        public void RomanToInt(string numerals, int expected)
        {
            Assert.AreEqual(expected, Solution.RomanToInt(numerals));
        }
    }

    public partial class Solution
    {
        public static int RomanToInt(string s)
        {

            var result = 0;

            var romanLetters = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            s = s.Replace("IV", "IIII");
            s = s.Replace("IX", "VIIII");
            s = s.Replace("XL", "XXXX");
            s = s.Replace("XC", "LXXXX");
            s = s.Replace("CD", "CCCC");
            s = s.Replace("CM", "DCCCC");

            var chars = s.ToCharArray();

            foreach (var numeral in chars)
            {
                result += romanLetters[numeral];
            }

            return result;
        }
    }
}
