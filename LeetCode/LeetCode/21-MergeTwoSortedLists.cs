namespace LeetCode
{
    [TestClass]
    public class MergeTwoSortedLists_21
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 1, 2, 3, 4, 4 })]
        public void MergeTwoLists_OneToFour(int[] expected)
        {
            var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            var result = Solution.MergeTwoLists(list1, list2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result.val);
                result = result.next;
            }
        }

        [DataTestMethod]
        [DataRow(new int[] { })]
        public void MergeTwoLists_NoEntries(int[] expected)
        {
            var list1 = new ListNode();
            var list2 = new ListNode();

            var result = Solution.MergeTwoLists(list1, list2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result.val);
                result = result.next;
            }
        }

        [DataTestMethod]
        [DataRow(new int[] { 0 })]
        public void MergeTwoLists_OneEntry(int[] expected)
        {
            var list1 = new ListNode();
            var list2 = new ListNode(0, null!);

            var result = Solution.MergeTwoLists(list1, list2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result.val);
                result = result.next;
            }
        }
    }

    public partial class Solution
    {
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            // Validations
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            var newHead = new ListNode(0);
            var runnerHead = newHead;

            while (list1 != null && list2 != null)
            {
                if (list1.val >= list2.val)
                {
                    runnerHead.next = list2;
                    list2 = list2.next;
                }
                else
                {
                    runnerHead.next = list1;
                    list1 = list1.next;
                }

                runnerHead = runnerHead.next;
            }

            // Simply add the 'leftover' from the while loop at the end 
            if (list1 != null) runnerHead.next = list1;
            if (list2 != null) runnerHead.next = list2;

            return newHead.next;
        }
    }
}