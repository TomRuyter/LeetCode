namespace LeetCode
{
    [TestClass]
    public class MergeKSortedLists_23
    {
        [TestMethod]
        public void MergeKLists_Example1()
        {
            var lists = new List<ListNode>
            {
                new(1, new ListNode(4, new ListNode(5, null!))),
                new(1, new ListNode(3, new ListNode(4, null!))),
                new(2, new ListNode(6,null!))
            };

            var result = Solution.MergeKLists(lists.ToArray());

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.val);
            Assert.AreEqual(1, result.next.val);
            Assert.AreEqual(2, result.next.next.val);
            Assert.AreEqual(3, result.next.next.next.val);
            Assert.AreEqual(4, result.next.next.next.next.val);
            Assert.AreEqual(4, result.next.next.next.next.next.val);
            Assert.AreEqual(5, result.next.next.next.next.next.next.val);
            Assert.AreEqual(6, result.next.next.next.next.next.next.next.val);
        }

        [TestMethod]
        public void MergeKLists_Example2()
        {
            var lists = new List<ListNode>();
            var result = Solution.MergeKLists(lists.ToArray());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void MergeKLists_Example3()
        {
            var lists = new List<ListNode>() { };
            var result = Solution.MergeKLists(lists.ToArray());

            Assert.IsNull(result);
        }
    }

    public partial class Solution
    {
        public static ListNode? MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            // Use a min-heap priority queue keyed by node value.
            var pq = new PriorityQueue<ListNode, int>();
            foreach (var node in lists)
            {
                if (node != null) pq.Enqueue(node, node.val);
            }

            var dummy = new ListNode(0);
            var tail = dummy;

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();
                tail.next = node;
                tail = tail.next;
                if (node.next != null) pq.Enqueue(node.next, node.next.val);
            }

            return dummy.next;
        }
    }
}