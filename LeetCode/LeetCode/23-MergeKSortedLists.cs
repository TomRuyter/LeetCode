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

            Assert.IsTrue(result.val == 1);
            Assert.IsTrue(result.next.val == 1);
            Assert.IsTrue(result.next.next.val == 2);
            Assert.IsTrue(result.next.next.next.val == 3);
            Assert.IsTrue(result.next.next.next.next.val == 4);
            Assert.IsTrue(result.next.next.next.next.next.val == 4);
            Assert.IsTrue(result.next.next.next.next.next.next.val == 5);
            Assert.IsTrue(result.next.next.next.next.next.next.next.val == 6);
        }

        [TestMethod]
        public void MergeKLists_Example2()
        {
            var lists = new List<ListNode>();
            var result = Solution.MergeKLists(lists.ToArray());

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void MergeKLists_Example3()
        {
            var lists = new List<ListNode>() { };
            var result = Solution.MergeKLists(lists.ToArray());

            Assert.IsTrue(result == null);
        }
    }

    public partial class Solution
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            var nodes = new Dictionary<int, int>();

            foreach (var node in lists)
            {
                if (node != null)
                {
                    ProcesNode(node, nodes);
                }
            }

            if (nodes.Count == 0)
            {
                return null!;
            }

            var sorted = nodes.OrderByDescending(x => x.Key);

            ListNode current = null!;
            ListNode previous = null!;

            foreach (var node in sorted)
            {
                for (var i = 0; i < node.Value; i++)
                {
                    var newNode = new ListNode(node.Key, previous);
                    previous = newNode;
                    current = newNode;
                }
            }

            return current;
        }

        private static void ProcesNode(ListNode node, Dictionary<int, int> nodes)
        {
            if (node != null)
            {
                if (nodes.ContainsKey(node.val))
                {
                    nodes[node.val]++;
                }
                else
                {
                    nodes.Add(node.val, 1);
                }

                if (node.next != null)
                {
                    ProcesNode(node.next, nodes);
                }
            }
        }
    }
}