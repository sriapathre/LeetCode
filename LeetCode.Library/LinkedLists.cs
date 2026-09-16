using System;
using System.Collections.Generic;

namespace LeetCode.Library
{
    /// <summary>
    /// Definition for singly-linked list
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

    }

    public static class LinkedListsCommon
    {
        /// <summary>
        /// Counts the nodes in a linked list.
        /// </summary>
        /// <param name="head">The head of the linked list to count.</param>
        /// <returns>The number of nodes in the linked list.</returns>
        public static int GetLength(ListNode head)
        {
            int count = 1;
            while (head != null)
            {
                count++;
                head = head.next;
            }

            return count;
        }
    }

    public class LinkedLists
    {
        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-two-sorted-lists/">21. Merge Two Sorted Lists (easy)</a>
        /// Merges two sorted linked lists into a single sorted list by reusing the existing nodes.
        /// </summary>
        /// <param name="list1">The head of the first sorted linked list.</param>
        /// <param name="list2">The head of the second sorted linked list.</param>
        /// <returns>The head of the merged sorted linked list.</returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode root = new ListNode(0, null);
            ListNode current = root;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }
            if (list1 != null)
            {
                current.next = list1;
            }
            if (list2 != null)
            {
                current.next = list2;
            }
            return root.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-list/">83. Remove Duplicates from Sorted List (easy)</a>
        /// Removes duplicate values from a sorted linked list so each value appears exactly once.
        /// </summary>
        /// <param name="head">The head of the sorted linked list.</param>
        /// <returns>The head of the linked list after duplicate nodes are removed.</returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;
            while (current != null && current.next != null)
            {
                while (current.next != null && current.val == current.next.val)
                {
                    current.next = current.next.next;
                }
                current = current.next;
            }
            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/linked-list-cycle/">141. Linked List Cycle (easy)</a>
        /// Determines whether a linked list contains a cycle by checking whether traversal can loop back to a previously visited node.
        /// </summary>
        /// <param name="head">The head of the linked list to inspect.</param>
        /// <returns><see langword="true"/> if the linked list contains a cycle; otherwise, <see langword="false"/>.</returns>
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head; ListNode slow = head;
            // loop covers my edge case
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) return true;
            }
            return false;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/intersection-of-two-linked-lists/">160. Intersection of Two Linked Lists (easy)</a>
        /// Finds the node where two singly linked lists intersect, or returns <see langword="null"/> when they do not share a tail.
        /// </summary>
        /// <param name="headA">The head of the first linked list.</param>
        /// <param name="headB">The head of the second linked list.</param>
        /// <returns>The intersecting node if one exists; otherwise, <see langword="null"/>.</returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int lengthA = LinkedListsCommon.GetLength(headA);
            int lengthB = LinkedListsCommon.GetLength(headB);

            while (lengthA > lengthB)
            {
                headA = headA.next;
                lengthA--;
            }

            while (lengthB > lengthA)
            {
                headB = headB.next;
                lengthB--;
            }

            while (headA != headB)
            {
                headA = headA.next;
                headB = headB.next;
            }

            return headA;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-linked-list-elements/">203. Remove Linked List Elements (easy)</a>
        /// Removes every node whose value equals the target value from the linked list.
        /// </summary>
        /// <param name="head">The head of the linked list to filter.</param>
        /// <param name="val">The value to remove from the list.</param>
        /// <returns>The head of the linked list after matching nodes are removed.</returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode current = head;
            ListNode previous = null;
            while (current != null && current.val == val)
            {
                current = current.next;
            }
            head = current;
            while (current != null)
            {
                if (current.val == val)
                {
                    if (previous == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }
            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-linked-list/">206. Reverse Linked List (easy)</a>
        /// Reverses a singly linked list and returns the new head.
        /// </summary>
        /// <param name="head">The head of the linked list to reverse.</param>
        /// <returns>The head of the reversed linked list.</returns>

        public ListNode ReverseList(ListNode head)
        {
            ListNode newRoot = null;
            while (head != null)
            {
                newRoot = new ListNode(head.val, newRoot);
                head = head.next;
            }
            return newRoot;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/add-two-numbers/">2. Add Two Numbers (medium)</a>
        /// Adds two non-negative integers stored in reverse-order linked lists and returns the sum as a linked list.
        /// </summary>
        /// <param name="l1">The head of the first reverse-order digit list.</param>
        /// <param name="l2">The head of the second reverse-order digit list.</param>
        /// <returns>The head of a linked list representing the summed value in reverse order.</returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode();
            var current = dummy;
            var carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                var sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                current.next = new ListNode(sum % 10);
                current = current.next;
                carry = sum / 10;
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-nth-node-from-end-of-list/">19. Remove Nth Node From End of List (medium)</a>
        /// Removes the nth node from the end of a singly linked list and returns the updated head.
        /// </summary>
        /// <param name="head">The head of the linked list.</param>
        /// <param name="n">The one-based position from the end of the list to remove.</param>
        /// <returns>The head of the linked list after the target node is removed.</returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n <= 0)
            {
                return head;
            }

            var dummy = new ListNode(0, head);
            var fast = dummy;
            var slow = dummy;

            for (var i = 0; i < n && fast != null; i++)
            {
                fast = fast.next;
            }

            if (fast == null)
            {
                return head;
            }

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;
            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-k-sorted-lists/">23. Merge k Sorted Lists (hard)</a>
        /// Merges k sorted linked lists into one sorted linked list.
        /// </summary>
        /// <param name="lists">The collection of sorted linked list heads to merge.</param>
        /// <returns>The head of the merged sorted linked list, or <see langword="null"/> when the input is empty.</returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            var queue = new PriorityQueue<ListNode, int>();
            foreach (var list in lists)
            {
                if (list != null)
                {
                    queue.Enqueue(list, list.val);
                }
            }

            var dummy = new ListNode();
            var current = dummy;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.next != null)
                {
                    queue.Enqueue(node.next, node.next.val);
                }

                current.next = node;
                current = node;
            }

            current.next = null;
            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/swap-nodes-in-pairs/">24. Swap Nodes in Pairs (medium)</a>
        /// Swaps every two adjacent nodes in the list without modifying node values.
        /// </summary>
        /// <param name="head">The head of the linked list to reorder.</param>
        /// <returns>The head of the linked list after each adjacent pair is swapped.</returns>
        public ListNode SwapPairs(ListNode head)
        {
            var dummy = new ListNode(0, head);
            var previous = dummy;

            while (previous.next != null && previous.next.next != null)
            {
                var first = previous.next;
                var second = first.next;
                first.next = second.next;
                second.next = first;
                previous.next = second;
                previous = first;
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-nodes-in-k-group/">25. Reverse Nodes in k-Group (hard)</a>
        /// Reverses nodes in contiguous groups of size k and leaves any remaining nodes in their original order.
        /// </summary>
        /// <param name="head">The head of the linked list to process.</param>
        /// <param name="k">The size of each group to reverse.</param>
        /// <returns>The head of the linked list after reversing each complete group.</returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k <= 1)
            {
                return head;
            }

            var dummy = new ListNode(0, head);
            var groupPrevious = dummy;

            while (true)
            {
                var kth = groupPrevious;
                for (var i = 0; i < k && kth != null; i++)
                {
                    kth = kth.next;
                }

                if (kth == null)
                {
                    break;
                }

                var groupNext = kth.next;
                var previous = groupNext;
                var current = groupPrevious.next;
                while (current != groupNext)
                {
                    var next = current.next;
                    current.next = previous;
                    previous = current;
                    current = next;
                }

                var oldGroupHead = groupPrevious.next;
                groupPrevious.next = kth;
                groupPrevious = oldGroupHead;
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotate-list/">61. Rotate List (medium)</a>
        /// Rotates a linked list to the right by k positions.
        /// </summary>
        /// <param name="head">The head of the linked list to rotate.</param>
        /// <param name="k">The number of positions to rotate the list to the right.</param>
        /// <returns>The head of the rotated linked list.</returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
            {
                return head;
            }

            var length = 1;
            var tail = head;
            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            k %= length;
            if (k == 0)
            {
                return head;
            }

            tail.next = head;
            var newTail = head;
            for (var i = 1; i < length - k; i++)
            {
                newTail = newTail.next;
            }

            var newHead = newTail.next;
            newTail.next = null;
            return newHead;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/">82. Remove Duplicates from Sorted List II (medium)</a>
        /// Removes all values that appear more than once from a sorted linked list.
        /// </summary>
        /// <param name="head">The head of the sorted linked list.</param>
        /// <returns>The head of the linked list after all duplicate values are removed entirely.</returns>
        public ListNode DeleteDuplicatesII(ListNode head)
        {
            var dummy = new ListNode(0, head);
            var previous = dummy;

            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    var duplicateValue = head.val;
                    while (head != null && head.val == duplicateValue)
                    {
                        head = head.next;
                    }

                    previous.next = head;
                }
                else
                {
                    previous = head;
                    head = head.next;
                }
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/partition-list/">86. Partition List (medium)</a>
        /// Reorders the list so nodes less than x come before nodes greater than or equal to x while preserving relative order.
        /// </summary>
        /// <param name="head">The head of the linked list to partition.</param>
        /// <param name="x">The partition value used to split smaller and larger nodes.</param>
        /// <returns>The head of the partitioned linked list.</returns>
        public ListNode Partition(ListNode head, int x)
        {
            var before = new ListNode();
            var after = new ListNode();
            var beforeCurrent = before;
            var afterCurrent = after;

            while (head != null)
            {
                var next = head.next;
                head.next = null;
                if (head.val < x)
                {
                    beforeCurrent.next = head;
                    beforeCurrent = head;
                }
                else
                {
                    afterCurrent.next = head;
                    afterCurrent = head;
                }

                head = next;
            }

            beforeCurrent.next = after.next;
            return before.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-linked-list-ii/">92. Reverse Linked List II (medium)</a>
        /// Reverses the nodes between the given left and right positions in one pass.
        /// </summary>
        /// <param name="head">The head of the linked list to modify.</param>
        /// <param name="left">The one-based starting position of the sublist to reverse.</param>
        /// <param name="right">The one-based ending position of the sublist to reverse.</param>
        /// <returns>The head of the linked list after the specified sublist is reversed.</returns>
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null || left == right)
            {
                return head;
            }

            var dummy = new ListNode(0, head);
            var before = dummy;
            for (var position = 1; position < left; position++)
            {
                before = before.next;
            }

            var current = before.next;
            for (var position = left; position < right; position++)
            {
                var moved = current.next;
                current.next = moved.next;
                moved.next = before.next;
                before.next = moved;
            }

            return dummy.next;
        }
    }
}
