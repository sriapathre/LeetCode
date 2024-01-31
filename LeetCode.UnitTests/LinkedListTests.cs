using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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

        [TestMethod]
        public void RemoveElements_Test1()
        {
            var expectedResult = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var actualResult = linkedLists.RemoveElements(new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))))), 6);
            while (expectedResult != null && actualResult != null)
            {
                Assert.AreEqual(expectedResult.val, actualResult.val);
                expectedResult = expectedResult.next;
                actualResult = actualResult.next;
            }
        }

        [TestMethod]
        public void RemoveElements_Test2()
        {
            var expectedResult = new ListNode(2, null);
            var actualResult = linkedLists.RemoveElements(new ListNode(1, new ListNode(1, new ListNode(2, null))), 1);
            while (expectedResult != null && actualResult != null)
            {
                Assert.AreEqual(expectedResult.val, actualResult.val);
                expectedResult = expectedResult.next;
                actualResult = actualResult.next;
            }
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
            var expectedResult = new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))));
            var actualResult = linkedLists.ReverseList(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))));
            while (expectedResult != null && actualResult != null)
            {
                Assert.AreEqual(expectedResult.val, actualResult.val);
                expectedResult = expectedResult.next;
                actualResult = actualResult.next;
            }
        }

        [TestMethod]
        public void ReverseList_Test2()
        {
            var expectedResult = new ListNode(1, null);
            var actualResult = linkedLists.ReverseList(new ListNode(1, null));
            while (expectedResult != null && actualResult != null)
            {
                Assert.AreEqual(expectedResult.val, actualResult.val);
                expectedResult = expectedResult.next;
                actualResult = actualResult.next;
            }
        }

        [TestMethod]
        public void ReverseList_Test3()
        {
            var actualResult = linkedLists.ReverseList(null);
            Assert.AreEqual(actualResult, null);
        }
    }
}
