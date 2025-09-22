namespace LeetCode
{
    [TestClass]
    public class LinkedList_206
    {
        [TestMethod]
        public void ReverseList_OneToSix()
        {
            var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, null!))))));

            var result = Solution.ReverseList(list);

            Assert.AreEqual(6, result.val);
        }

        [TestMethod]
        public void ReverseList_OneToTwo()
        {
            var list = new ListNode(1, new ListNode(2, null!));

            var result = Solution.ReverseList(list);

            Assert.AreEqual(2, result.val);
        }

        [TestMethod]
        public void ReverseList_Null()
        {
            var result = Solution.ReverseList(null!);

            Assert.IsNull(result);
        }
    }

    public partial class Solution
    {
        public static ListNode ReverseList(ListNode head)
        {
            // Define a few variables
            ListNode previous = null!;
            ListNode current = head;

            while (current != null)
            {
                // Store the next item before we loose access to it..
                var nextItem = current.next;

                // Set the next item of the current node as previous
                // At the start we zero this out to be a null to break the link.
                current.next = previous;

                // update the previous item to be the current one
                previous = current;

                // Set the current item to be the temp item.
                current = nextItem;
            }

            // Send back to node 
            return previous;
        }
    }

    public class ListNode(int val = 0, ListNode next = null!)
    {
        public int val = val;
        public ListNode next = next;
    }
}
