using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            Assert.IsNull(expectedResult);
            Assert.IsNull(actualResult);
        }

        private void CollectInOrder(TreeNode root, List<int> values)
        {
            if (root == null)
            {
                return;
            }

            CollectInOrder(root.left, values);
            values.Add(root.val);
            CollectInOrder(root.right, values);
        }

        private int HeightOrUnbalanced(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var left = HeightOrUnbalanced(root.left);
            var right = HeightOrUnbalanced(root.right);
            if (left < 0 || right < 0 || Math.Abs(left - right) > 1)
            {
                return -1;
            }

            return Math.Max(left, right) + 1;
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
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveElements_Test4()
        {
            var actualResult = linkedLists.RemoveElements(new ListNode(1, null), 1);
            Assert.IsNull(actualResult);
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
            Assert.IsNull(actualResult);
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

        [TestMethod]
        public void SortedListToBST_CreatesBalancedBst()
        {
            var root = linkedLists.SortedListToBST(CreateList(new[] { -10, -3, 0, 5, 9 }));
            var values = new List<int>();
            CollectInOrder(root, values);

            CollectionAssert.AreEqual(new List<int> { -10, -3, 0, 5, 9 }, values);
            Assert.AreNotEqual(-1, HeightOrUnbalanced(root));
            Assert.IsNull(linkedLists.SortedListToBST(null));
        }

        [TestMethod]
        public void CopyRandomList_CopiesValuesNextAndRandomPointers()
        {
            var node7 = new RandomNode(7);
            var node13 = new RandomNode(13);
            var node11 = new RandomNode(11);
            var node10 = new RandomNode(10);
            var node1 = new RandomNode(1);
            node7.next = node13;
            node13.next = node11;
            node11.next = node10;
            node10.next = node1;
            node13.random = node7;
            node11.random = node1;
            node10.random = node11;
            node1.random = node7;

            var copy = linkedLists.CopyRandomList(node7);

            Assert.AreNotSame(node7, copy);
            Assert.AreEqual(7, copy.val);
            Assert.AreEqual(13, copy.next.val);
            Assert.AreSame(copy, copy.next.random);
            Assert.AreSame(copy.next.next.next.next, copy.next.next.random);
            Assert.AreSame(copy.next.next, copy.next.next.next.random);
            Assert.AreSame(copy, copy.next.next.next.next.random);
            Assert.IsNull(copy.random);
            Assert.IsNull(linkedLists.CopyRandomList(null));
        }

        [TestMethod]
        public void HasCycle_Test1()
        {
            // Arrange
            var node3 = new ListNode(3);
            var node2 = new ListNode(2, node3);
            var node1 = new ListNode(1, node2);

            // Act
            var result = linkedLists.HasCycle(node1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasCycle_Test2()
        {
            // Arrange
            var node3 = new ListNode(3);
            var node2 = new ListNode(2, node3);
            var node1 = new ListNode(1, node2);
            node3.next = node1; // Create a cycle

            // Act
            var result = linkedLists.HasCycle(node1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasCycle_Test3()
        {
            // Arrange
            var node = new ListNode(1);
            node.next = node; // Create a cycle

            // Act
            var result = linkedLists.HasCycle(node);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DetectCycle_ReturnsCycleStartOrNull()
        {
            var node3 = new ListNode(3);
            var node2 = new ListNode(2);
            var node0 = new ListNode(0);
            var nodeMinus4 = new ListNode(-4);
            node3.next = node2;
            node2.next = node0;
            node0.next = nodeMinus4;
            nodeMinus4.next = node2;

            Assert.AreSame(node2, linkedLists.DetectCycle(node3));
            Assert.IsNull(linkedLists.DetectCycle(CreateList(new[] { 1, 2, 3 })));

            var single = new ListNode(1);
            single.next = single;
            Assert.AreSame(single, linkedLists.DetectCycle(single));
        }

        [TestMethod]
        public void ReorderList_ReordersOddEvenAndShortLists()
        {
            var odd = CreateList(new[] { 1, 2, 3, 4, 5 });
            linkedLists.ReorderList(odd);
            CompareLists(CreateList(new[] { 1, 5, 2, 4, 3 }), odd);

            var even = CreateList(new[] { 1, 2, 3, 4 });
            linkedLists.ReorderList(even);
            CompareLists(CreateList(new[] { 1, 4, 2, 3 }), even);

            var single = new ListNode(1);
            linkedLists.ReorderList(single);
            CompareLists(CreateList(new[] { 1 }), single);
            linkedLists.ReorderList(null);
        }

        [TestMethod]
        public void InsertionSortList_SortsExamplesAndEdgeCases()
        {
            CompareLists(CreateList(new[] { 1, 2, 3, 4 }),
                linkedLists.InsertionSortList(CreateList(new[] { 4, 2, 1, 3 })));
            CompareLists(CreateList(new[] { -1, 0, 3, 4, 5 }),
                linkedLists.InsertionSortList(CreateList(new[] { -1, 5, 3, 4, 0 })));
            Assert.IsNull(linkedLists.InsertionSortList(null));
        }

        [TestMethod]
        public void SortList_SortsExamplesAndEdgeCases()
        {
            CompareLists(CreateList(new[] { 1, 2, 3, 4 }),
                linkedLists.SortList(CreateList(new[] { 4, 2, 1, 3 })));
            CompareLists(CreateList(new[] { -1, 0, 3, 4, 5 }),
                linkedLists.SortList(CreateList(new[] { -1, 5, 3, 4, 0 })));
            CompareLists(CreateList(new[] { 1, 1, 2, 3 }),
                linkedLists.SortList(CreateList(new[] { 3, 1, 2, 1 })));
            Assert.IsNull(linkedLists.SortList(null));
        }

        [TestMethod]
        public void GetIntersectionNode_Test1()
        {
            // Arrange
            var node3 = new ListNode(3);
            var node2 = new ListNode(2, node3);
            var node1 = new ListNode(1, node2);
            var node5 = new ListNode(5);
            var node4 = new ListNode(4, node5);
            node5.next = node3; // Create an intersection
            // Act
            var result = linkedLists.GetIntersectionNode(node1, node4);
            // Assert
            Assert.AreEqual(node3, result);
        }

        [TestMethod]
        public void GetIntersectionNode_Test2()
        {
            var node = new ListNode(1);
            var node2 = new ListNode(2, node);
            var node3 = new ListNode(3, node2);
            var node4 = new ListNode(4, node3);
            var node5 = new ListNode(5, node4);
            var node6 = new ListNode(6, node5);
            // Act
            var result = linkedLists.GetIntersectionNode(node, node6);
            // Assert
            Assert.AreEqual(node, result);
        }

        [TestMethod]
        public void GetIntersectionNode_Test3()
        {
            // Arrange
            var node3 = new ListNode(3);
            var node2 = new ListNode(2);
            var node1 = new ListNode(1, node2);
            // Act
            var result = linkedLists.GetIntersectionNode(node3, node1);
            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void AddTwoNumbers_HandlesCarryAndEmptyLists()
        {
            CompareLists(CreateList(new[] { 7, 0, 8 }),
                linkedLists.AddTwoNumbers(CreateList(new[] { 2, 4, 3 }), CreateList(new[] { 5, 6, 4 })));
            CompareLists(CreateList(new[] { 0 }), linkedLists.AddTwoNumbers(null, new ListNode(0)));
            CompareLists(CreateList(new[] { 0, 0, 0, 1 }),
                linkedLists.AddTwoNumbers(CreateList(new[] { 9, 9, 9 }), new ListNode(1)));
        }

        [TestMethod]
        public void RemoveNthFromEnd_RemovesHeadMiddleAndOnlyNode()
        {
            CompareLists(CreateList(new[] { 1, 2, 3, 5 }),
                linkedLists.RemoveNthFromEnd(CreateList(new[] { 1, 2, 3, 4, 5 }), 2));
            CompareLists(CreateList(new[] { 2, 3 }),
                linkedLists.RemoveNthFromEnd(CreateList(new[] { 1, 2, 3 }), 3));
            Assert.IsNull(linkedLists.RemoveNthFromEnd(new ListNode(1), 1));
        }

        [TestMethod]
        public void MergeKLists_MergesMultipleAndHandlesEmptyInput()
        {
            CompareLists(CreateList(new[] { 1, 1, 2, 3, 4, 4, 5, 6 }),
                linkedLists.MergeKLists(new[]
                {
                    CreateList(new[] { 1, 4, 5 }),
                    CreateList(new[] { 1, 3, 4 }),
                    CreateList(new[] { 2, 6 })
                }));
            Assert.IsNull(linkedLists.MergeKLists(null));
            Assert.IsNull(linkedLists.MergeKLists(new ListNode[] { null, null }));
        }

        [TestMethod]
        public void SwapPairs_SwapsCompleteAndIncompletePairs()
        {
            CompareLists(CreateList(new[] { 2, 1, 4, 3 }),
                linkedLists.SwapPairs(CreateList(new[] { 1, 2, 3, 4 })));
            CompareLists(CreateList(new[] { 2, 1, 3 }),
                linkedLists.SwapPairs(CreateList(new[] { 1, 2, 3 })));
            Assert.IsNull(linkedLists.SwapPairs(null));
        }

        [TestMethod]
        public void ReverseKGroup_ReversesOnlyCompleteGroups()
        {
            CompareLists(CreateList(new[] { 2, 1, 4, 3, 5 }),
                linkedLists.ReverseKGroup(CreateList(new[] { 1, 2, 3, 4, 5 }), 2));
            CompareLists(CreateList(new[] { 3, 2, 1, 6, 5, 4 }),
                linkedLists.ReverseKGroup(CreateList(new[] { 1, 2, 3, 4, 5, 6 }), 3));
            CompareLists(CreateList(new[] { 1, 2 }), linkedLists.ReverseKGroup(CreateList(new[] { 1, 2 }), 3));
        }

        [TestMethod]
        public void RotateRight_RotatesAndReducesLargeK()
        {
            CompareLists(CreateList(new[] { 4, 5, 1, 2, 3 }),
                linkedLists.RotateRight(CreateList(new[] { 1, 2, 3, 4, 5 }), 2));
            CompareLists(CreateList(new[] { 2, 0, 1 }),
                linkedLists.RotateRight(CreateList(new[] { 0, 1, 2 }), 4));
            Assert.IsNull(linkedLists.RotateRight(null, 10));
        }

        [TestMethod]
        public void DeleteDuplicatesII_RemovesAllRepeatedValues()
        {
            CompareLists(CreateList(new[] { 1, 2, 5 }),
                linkedLists.DeleteDuplicatesII(CreateList(new[] { 1, 2, 3, 3, 4, 4, 5 })));
            Assert.IsNull(linkedLists.DeleteDuplicatesII(CreateList(new[] { 1, 1, 1 })));
            CompareLists(CreateList(new[] { 1, 2 }), linkedLists.DeleteDuplicatesII(CreateList(new[] { 1, 2 })));
        }

        [TestMethod]
        public void Partition_PreservesOrderAroundPivot()
        {
            CompareLists(CreateList(new[] { 1, 2, 2, 4, 3, 5 }),
                linkedLists.Partition(CreateList(new[] { 1, 4, 3, 2, 5, 2 }), 3));
            CompareLists(CreateList(new[] { 1, 2, 3 }), linkedLists.Partition(CreateList(new[] { 1, 2, 3 }), 0));
            Assert.IsNull(linkedLists.Partition(null, 3));
        }

        [TestMethod]
        public void ReverseBetween_ReversesRangeAndHandlesSinglePosition()
        {
            CompareLists(CreateList(new[] { 1, 4, 3, 2, 5 }),
                linkedLists.ReverseBetween(CreateList(new[] { 1, 2, 3, 4, 5 }), 2, 4));
            CompareLists(CreateList(new[] { 3, 2, 1 }),
                linkedLists.ReverseBetween(CreateList(new[] { 1, 2, 3 }), 1, 3));
            CompareLists(CreateList(new[] { 1, 2 }), linkedLists.ReverseBetween(CreateList(new[] { 1, 2 }), 2, 2));
        }

        [TestMethod]
        public void IsPalindrome_DetectsExamplesAndRestoresList()
        {
            var palindrome = CreateList(new[] { 1, 2, 2, 1 });

            Assert.IsTrue(linkedLists.IsPalindrome(palindrome));
            CompareLists(CreateList(new[] { 1, 2, 2, 1 }), palindrome);
            Assert.IsFalse(linkedLists.IsPalindrome(CreateList(new[] { 1, 2 })));
            Assert.IsTrue(linkedLists.IsPalindrome(CreateList(new[] { 1, 2, 1 })));
            Assert.IsTrue(linkedLists.IsPalindrome(null));
        }

        [TestMethod]
        public void DeleteNode_RemovesGivenMiddleNode()
        {
            var head = CreateList(new[] { 4, 5, 1, 9 });

            linkedLists.DeleteNode(head.next);

            CompareLists(CreateList(new[] { 4, 1, 9 }), head);

            var twoNodes = CreateList(new[] { 1, 2 });
            linkedLists.DeleteNode(twoNodes);
            CompareLists(CreateList(new[] { 2 }), twoNodes);
        }

        [TestMethod]
        public void OddEvenList_GroupsOddIndicesBeforeEvenIndices()
        {
            CompareLists(CreateList(new[] { 1, 3, 5, 2, 4 }),
                linkedLists.OddEvenList(CreateList(new[] { 1, 2, 3, 4, 5 })));
            CompareLists(CreateList(new[] { 2, 3, 6, 7, 1, 5, 4 }),
                linkedLists.OddEvenList(CreateList(new[] { 2, 1, 3, 5, 6, 4, 7 })));
            CompareLists(CreateList(new[] { 1, 3, 2, 4 }),
                linkedLists.OddEvenList(CreateList(new[] { 1, 2, 3, 4 })));
            Assert.IsNull(linkedLists.OddEvenList(null));
        }

        [TestMethod]
        public void AddTwoNumbersII_AddsForwardOrderDigits()
        {
            CompareLists(CreateList(new[] { 7, 8, 0, 7 }),
                linkedLists.AddTwoNumbersII(CreateList(new[] { 7, 2, 4, 3 }), CreateList(new[] { 5, 6, 4 })));
            CompareLists(CreateList(new[] { 1, 0, 0, 0, 0 }),
                linkedLists.AddTwoNumbersII(CreateList(new[] { 9, 9, 9, 9 }), new ListNode(1)));
            CompareLists(CreateList(new[] { 0 }), linkedLists.AddTwoNumbersII(new ListNode(0), new ListNode(0)));
        }

        [TestMethod]
        public void SplitListToParts_SplitsEvenlyAndPadsEmptyParts()
        {
            var parts = linkedLists.SplitListToParts(CreateList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }), 3);
            CompareLists(CreateList(new[] { 1, 2, 3, 4 }), parts[0]);
            CompareLists(CreateList(new[] { 5, 6, 7 }), parts[1]);
            CompareLists(CreateList(new[] { 8, 9, 10 }), parts[2]);

            parts = linkedLists.SplitListToParts(CreateList(new[] { 1, 2, 3 }), 5);
            CompareLists(CreateList(new[] { 1 }), parts[0]);
            CompareLists(CreateList(new[] { 2 }), parts[1]);
            CompareLists(CreateList(new[] { 3 }), parts[2]);
            Assert.IsNull(parts[3]);
            Assert.IsNull(parts[4]);
        }

        [TestMethod]
        public void NumComponents_CountsConnectedValueRuns()
        {
            Assert.AreEqual(2, linkedLists.NumComponents(CreateList(new[] { 0, 1, 2, 3 }), new[] { 0, 1, 3 }));
            Assert.AreEqual(2, linkedLists.NumComponents(CreateList(new[] { 0, 1, 2, 3, 4 }), new[] { 0, 3, 1, 4 }));
            Assert.AreEqual(0, linkedLists.NumComponents(null, Array.Empty<int>()));
        }

        [TestMethod]
        public void MiddleNode_ReturnsSecondMiddleForEvenLength()
        {
            CompareLists(CreateList(new[] { 3, 4, 5 }), linkedLists.MiddleNode(CreateList(new[] { 1, 2, 3, 4, 5 })));
            CompareLists(CreateList(new[] { 4, 5, 6 }), linkedLists.MiddleNode(CreateList(new[] { 1, 2, 3, 4, 5, 6 })));
            Assert.IsNull(linkedLists.MiddleNode(null));
        }

        [TestMethod]
        public void NextLargerNodes_FindsNextGreaterValues()
        {
            CollectionAssert.AreEqual(new[] { 5, 5, 0 }, linkedLists.NextLargerNodes(CreateList(new[] { 2, 1, 5 })));
            CollectionAssert.AreEqual(new[] { 7, 0, 5, 5, 0 }, linkedLists.NextLargerNodes(CreateList(new[] { 2, 7, 4, 3, 5 })));
            CollectionAssert.AreEqual(Array.Empty<int>(), linkedLists.NextLargerNodes(null));
        }

        [TestMethod]
        public void RemoveZeroSumSublists_RemovesAllZeroSumRanges()
        {
            CompareLists(CreateList(new[] { 3, 1 }), linkedLists.RemoveZeroSumSublists(CreateList(new[] { 1, 2, -3, 3, 1 })));
            CompareLists(CreateList(new[] { 1, 5, 1 }), linkedLists.RemoveZeroSumSublists(CreateList(new[] { 1, 2, 3, -3, -2, 5, 1 })));
            Assert.IsNull(linkedLists.RemoveZeroSumSublists(CreateList(new[] { 1, -1 })));
        }

        [TestMethod]
        public void GetDecimalValue_ConvertsBinaryListToInteger()
        {
            Assert.AreEqual(5, linkedLists.GetDecimalValue(CreateList(new[] { 1, 0, 1 })));
            Assert.AreEqual(0, linkedLists.GetDecimalValue(new ListNode(0)));
            Assert.AreEqual(0, linkedLists.GetDecimalValue(null));
        }

        [TestMethod]
        public void IsSubPath_FindsDownwardLinkedListPath()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(4)
                {
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(1)
                    }
                },
                right = new TreeNode(4)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(6),
                        right = new TreeNode(8)
                        {
                            left = new TreeNode(1),
                            right = new TreeNode(3)
                        }
                    }
                }
            };

            Assert.IsTrue(linkedLists.IsSubPath(CreateList(new[] { 4, 2, 8 }), root));
            Assert.IsFalse(linkedLists.IsSubPath(CreateList(new[] { 1, 4, 2, 6, 8 }), root));
            Assert.IsTrue(linkedLists.IsSubPath(null, root));
            Assert.IsFalse(linkedLists.IsSubPath(new ListNode(1), null));
        }

        [TestMethod]
        public void DeleteNodes_AppliesKeepDeletePattern()
        {
            CompareLists(CreateList(new[] { 1, 2, 5, 6, 9, 10, 13 }),
                linkedLists.DeleteNodes(CreateList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }), 2, 2));
            CompareLists(CreateList(new[] { 1, 5, 9 }),
                linkedLists.DeleteNodes(CreateList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }), 1, 3));
            Assert.IsNull(linkedLists.DeleteNodes(null, 1, 2));
        }

        [TestMethod]
        public void MergeInBetween_ReplacesInclusiveRange()
        {
            CompareLists(CreateList(new[] { 0, 1, 2, 1000000, 1000001, 1000002, 5 }),
                linkedLists.MergeInBetween(
                    CreateList(new[] { 0, 1, 2, 3, 4, 5 }),
                    3,
                    4,
                    CreateList(new[] { 1000000, 1000001, 1000002 })));
            CompareLists(CreateList(new[] { 0, 9, 10, 4, 5 }),
                linkedLists.MergeInBetween(CreateList(new[] { 0, 1, 2, 3, 4, 5 }), 1, 3, CreateList(new[] { 9, 10 })));
        }

        [TestMethod]
        public void SwapNodes_SwapsKthNodesFromBothEnds()
        {
            CompareLists(CreateList(new[] { 1, 4, 3, 2, 5 }),
                linkedLists.SwapNodes(CreateList(new[] { 1, 2, 3, 4, 5 }), 2));
            CompareLists(CreateList(new[] { 7, 9, 6, 6, 8, 7, 3, 0, 9, 5 }),
                linkedLists.SwapNodes(CreateList(new[] { 7, 9, 6, 6, 7, 8, 3, 0, 9, 5 }), 5));
            CompareLists(CreateList(new[] { 1 }), linkedLists.SwapNodes(new ListNode(1), 1));
        }

        [TestMethod]
        public void NodesBetweenCriticalPoints_ReturnsMinimumAndMaximumDistances()
        {
            CollectionAssert.AreEqual(new[] { 1, 3 },
                linkedLists.NodesBetweenCriticalPoints(CreateList(new[] { 5, 3, 1, 2, 5, 1, 2 })));
            CollectionAssert.AreEqual(new[] { -1, -1 },
                linkedLists.NodesBetweenCriticalPoints(CreateList(new[] { 2, 2, 1, 3 })));
            CollectionAssert.AreEqual(new[] { -1, -1 }, linkedLists.NodesBetweenCriticalPoints(CreateList(new[] { 2, 1 })));
        }

        [TestMethod]
        public void ReverseEvenLengthGroups_ReversesOnlyEvenActualLengthGroups()
        {
            CompareLists(CreateList(new[] { 5, 6, 2, 3, 9, 1, 7, 8, 4 }),
                linkedLists.ReverseEvenLengthGroups(CreateList(new[] { 5, 2, 6, 3, 9, 1, 7, 8, 4 })));
            CompareLists(CreateList(new[] { 1, 6, 0, 5, 4, 3, 2, 7, 8 }),
                linkedLists.ReverseEvenLengthGroups(CreateList(new[] { 1, 0, 6, 5, 4, 3, 2, 7, 8 })));
            CompareLists(CreateList(new[] { 1 }), linkedLists.ReverseEvenLengthGroups(new ListNode(1)));
        }

        [TestMethod]
        public void DeleteMiddle_RemovesMiddleNode()
        {
            CompareLists(CreateList(new[] { 1, 3, 4, 1, 2, 6 }),
                linkedLists.DeleteMiddle(CreateList(new[] { 1, 3, 4, 7, 1, 2, 6 })));
            CompareLists(CreateList(new[] { 1, 2, 4 }),
                linkedLists.DeleteMiddle(CreateList(new[] { 1, 2, 3, 4 })));
            Assert.IsNull(linkedLists.DeleteMiddle(new ListNode(1)));
        }

        [TestMethod]
        public void PairSum_ReturnsMaximumTwinSumAndRestoresList()
        {
            var list = CreateList(new[] { 5, 4, 2, 1 });

            Assert.AreEqual(6, linkedLists.PairSum(list));
            CompareLists(CreateList(new[] { 5, 4, 2, 1 }), list);
            Assert.AreEqual(7, linkedLists.PairSum(CreateList(new[] { 4, 2, 2, 3 })));
            Assert.AreEqual(100001, linkedLists.PairSum(CreateList(new[] { 100000, 1 })));
        }

        [TestMethod]
        public void MergeNodes_SumsValuesBetweenZeroDelimiters()
        {
            CompareLists(CreateList(new[] { 4, 11 }),
                linkedLists.MergeNodes(CreateList(new[] { 0, 3, 1, 0, 4, 5, 2, 0 })));
            CompareLists(CreateList(new[] { 1, 3, 4 }),
                linkedLists.MergeNodes(CreateList(new[] { 0, 1, 0, 3, 0, 2, 2, 0 })));
            Assert.IsNull(linkedLists.MergeNodes(null));
        }

        [TestMethod]
        public void SpiralMatrix_FillsMatrixInSpiralOrder()
        {
            var matrix = linkedLists.SpiralMatrix(3, 5, CreateList(new[] { 3, 0, 2, 6, 8, 1, 7, 9, 4, 2, 5, 5, 0 }));

            CollectionAssert.AreEqual(new[] { 3, 0, 2, 6, 8 }, matrix[0]);
            CollectionAssert.AreEqual(new[] { 5, 0, -1, -1, 1 }, matrix[1]);
            CollectionAssert.AreEqual(new[] { 5, 2, 4, 9, 7 }, matrix[2]);

            matrix = linkedLists.SpiralMatrix(1, 4, CreateList(new[] { 0, 1, 2 }));
            CollectionAssert.AreEqual(new[] { 0, 1, 2, -1 }, matrix[0]);
        }

        [TestMethod]
        public void RemoveNodes_RemovesNodesWithGreaterValueToRight()
        {
            CompareLists(CreateList(new[] { 13, 8 }),
                linkedLists.RemoveNodes(CreateList(new[] { 5, 2, 13, 3, 8 })));
            CompareLists(CreateList(new[] { 1, 1, 1, 1 }),
                linkedLists.RemoveNodes(CreateList(new[] { 1, 1, 1, 1 })));
            Assert.IsNull(linkedLists.RemoveNodes(null));
        }

        [TestMethod]
        public void InsertGreatestCommonDivisors_InsertsBetweenAdjacentNodes()
        {
            CompareLists(CreateList(new[] { 18, 6, 6, 2, 10, 1, 3 }),
                linkedLists.InsertGreatestCommonDivisors(CreateList(new[] { 18, 6, 10, 3 })));
            CompareLists(CreateList(new[] { 7 }), linkedLists.InsertGreatestCommonDivisors(new ListNode(7)));
            Assert.IsNull(linkedLists.InsertGreatestCommonDivisors(null));
        }

        [TestMethod]
        public void DoubleIt_DoublesForwardOrderNumber()
        {
            CompareLists(CreateList(new[] { 3, 7, 8 }), linkedLists.DoubleIt(CreateList(new[] { 1, 8, 9 })));
            CompareLists(CreateList(new[] { 1, 9, 9, 8 }), linkedLists.DoubleIt(CreateList(new[] { 9, 9, 9 })));
            CompareLists(CreateList(new[] { 0 }), linkedLists.DoubleIt(new ListNode(0)));
        }

        [TestMethod]
        public void ModifiedList_RemovesValuesPresentInArray()
        {
            CompareLists(CreateList(new[] { 4, 5 }),
                linkedLists.ModifiedList(new[] { 1, 2, 3 }, CreateList(new[] { 1, 2, 3, 4, 5 })));
            CompareLists(CreateList(new[] { 1, 2, 3 }),
                linkedLists.ModifiedList(new[] { 4, 5 }, CreateList(new[] { 1, 2, 3 })));
            Assert.IsNull(linkedLists.ModifiedList(new[] { 1 }, CreateList(new[] { 1, 1, 1 })));
        }

        [TestMethod]
        public void MinimumPairRemoval_CountsOperationsUntilNonDecreasing()
        {
            Assert.AreEqual(2, linkedLists.MinimumPairRemoval(new[] { 5, 2, 3, 1 }));
            Assert.AreEqual(0, linkedLists.MinimumPairRemoval(new[] { 1, 2, 2 }));
            Assert.AreEqual(2, linkedLists.MinimumPairRemoval(new[] { -1, -2, -3 }));
            Assert.AreEqual(0, linkedLists.MinimumPairRemoval(new[] { 42 }));
        }
    }
}
