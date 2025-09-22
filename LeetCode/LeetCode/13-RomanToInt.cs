namespace LeetCode
{
    [TestClass]
    public class RomanToInt_13
    {
        [TestMethod]
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
            if (string.IsNullOrEmpty(s)) return 0;

            // Local mapper to convert Roman numeral char to its integer value.
            static int Val(char c) => c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };

            int result = 0;
            int i = 0;
            int n = s.Length;

            while (i < n)
            {
                int v = Val(s[i]);

                if (i + 1 < n)
                {
                    int next = Val(s[i + 1]);
                    if (v < next)
                    {
                        // Subtractive notation: e.g., IV = 5 - 1
                        result += (next - v);
                        i += 2;
                        continue;
                    }
                }

                result += v;
                i++;
            }

            return result;
        }
    }
}
