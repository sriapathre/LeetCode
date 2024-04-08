using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        LinkedLists linkedLists;
        [TestInitialize]
        public void Setup()
        {
            linkedLists = new LinkedLists();
        }

        private ListNode CreateList(int[] values)
        {
            ListNode head = null;
            ListNode current = null;
            foreach (var value in values)
            {
                if (head == null)
                {
                    head = new ListNode(value);
                    current = head;
                }
                else
                {
                    current.next = new ListNode(value);
                    current = current.next;
                }
            }
            return head;
        }

        private void CompareLists(ListNode expectedResult, ListNode actualResult)
        {
            while (expectedResult != null && actualResult != null)
            {
                Assert.AreEqual(expectedResult.val, actualResult.val);
                expectedResult = expectedResult.next;
                actualResult = actualResult.next;
            }
        }

        [TestMethod]
        public void RemoveElements_Test1()
        {
            var expectedResult = CreateList(new int[] { 1, 2, 3, 4, 5 });
            var actualResult = linkedLists.RemoveElements(CreateList(new int[] { 1, 2, 3, 4, 5, 6 }), 6);
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveElements_Test2()
        {
            var expectedResult = CreateList(new int[] { 2 });
            var actualResult = linkedLists.RemoveElements(CreateList(new int[] { 1, 2 }), 1);
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveElements_Test3()
        {
            ListNode expectedResult = null;
            var actualResult = linkedLists.RemoveElements(null, 1);
            Assert.AreEqual(expectedResult, null);
        }

        [TestMethod]
        public void RemoveElements_Test4()
        {
            var actualResult = linkedLists.RemoveElements(new ListNode(1, null), 1);
            Assert.AreEqual(actualResult, null);
        }

        [TestMethod]
        public void ReverseList_Test1()
        {
            var expectedResult = CreateList(new int[] { 5, 4, 3, 2, 1 });
            var actualResult = linkedLists.ReverseList(CreateList(new int[] { 1, 2, 3, 4, 5 }));
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReverseList_Test2()
        {
            var expectedResult = new ListNode(1, null);
            var actualResult = linkedLists.ReverseList(new ListNode(1, null));
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReverseList_Test3()
        {
            var actualResult = linkedLists.ReverseList(null);
            Assert.AreEqual(actualResult, null);
        }

        [TestMethod]
        public void MergeTwoLists_Test1()
        {
            var expectedResult = CreateList(new int[] { 1, 1, 2, 3, 4, 4 });
            var actualResult = linkedLists.MergeTwoLists(CreateList(new int[] { 1, 2, 4 }), CreateList(new int[] { 1, 3, 4 }));
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void MergeTwoLists_Test2()
        {
            var expectedResult = CreateList(new int[] { 1, 2, 3, 4, 4, 5 });
            var actualResult = linkedLists.MergeTwoLists(CreateList(new int[] { 1, 2, 4 }), CreateList(new int[] { 3, 4, 5 }));
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void MergeTwoLists_Test3()
        {
            var expectedResult = CreateList(new int[] { 1, 2, 3, 4, 5 });
            var actualResult = linkedLists.MergeTwoLists(CreateList(new int[] { 1, 2, 3, 4, 5 }), null);
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeleteDuplicates_Test1()
        {
            var expectedResult = CreateList(new int[] { 1, 2, 3, 4, 5 });
            var actualResult = linkedLists.DeleteDuplicates(CreateList(new int[] { 1, 1, 2, 3, 3, 4, 5, 5, 5, 5 }));
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeleteDuplicates_Test2()
        {
            var expectedResult = CreateList(new int[] { 1, 2 });
            var actualResult = linkedLists.DeleteDuplicates(CreateList(new int[] { 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 }));
            CompareLists(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeleteDuplicates_Test3()
        {
            var expectedResult = CreateList(new int[] { 1, 2, 3, 4, 5 });
            var actualResult = linkedLists.DeleteDuplicates(CreateList(new int[] { 1, 2, 3, 4, 5 }));
            CompareLists(expectedResult, actualResult);
        }
    }
}
