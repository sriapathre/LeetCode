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

    /// <summary>
    /// Definition for a linked-list node with an additional random pointer.
    /// </summary>
    public class RandomNode
    {
        public int val;
        public RandomNode next;
        public RandomNode random;

        public RandomNode(int val = 0, RandomNode next = null, RandomNode random = null)
        {
            this.val = val;
            this.next = next;
            this.random = random;
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
        /// <a href="https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/">109. Convert Sorted List to Binary Search Tree (medium)</a>
        /// Converts an ascending sorted singly linked list into a height-balanced binary search tree.
        /// </summary>
        /// <param name="head">The head of the ascending sorted linked list.</param>
        /// <returns>The root of a height-balanced binary search tree containing the list values.</returns>
        public TreeNode SortedListToBST(ListNode head)
        {
            var length = 0;
            var current = head;
            while (current != null)
            {
                length++;
                current = current.next;
            }

            current = head;
            return SortedListToBST(ref current, 0, length - 1);
        }

        private TreeNode SortedListToBST(ref ListNode current, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var middle = left + (right - left) / 2;
            var leftChild = SortedListToBST(ref current, left, middle - 1);
            var root = new TreeNode(current.val);
            current = current.next;
            root.left = leftChild;
            root.right = SortedListToBST(ref current, middle + 1, right);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/copy-list-with-random-pointer/">138. Copy List with Random Pointer (medium)</a>
        /// Creates a deep copy of a linked list whose nodes each have next and random pointers.
        /// </summary>
        /// <param name="head">The head of the random-pointer linked list to copy.</param>
        /// <returns>The head of the copied list, or <see langword="null"/> when the input is empty.</returns>
        public RandomNode CopyRandomList(RandomNode head)
        {
            if (head == null)
            {
                return null;
            }

            var current = head;
            while (current != null)
            {
                current.next = new RandomNode(current.val, current.next);
                current = current.next.next;
            }

            current = head;
            while (current != null)
            {
                if (current.random != null)
                {
                    current.next.random = current.random.next;
                }

                current = current.next.next;
            }

            current = head;
            var copiedHead = head.next;
            while (current != null)
            {
                var copied = current.next;
                current.next = copied.next;
                copied.next = copied.next?.next;
                current = current.next;
            }

            return copiedHead;
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
        /// <a href="https://leetcode.com/problems/linked-list-cycle-ii/">142. Linked List Cycle II (medium)</a>
        /// Finds the node where a linked-list cycle begins using Floyd's two-pointer detection.
        /// </summary>
        /// <param name="head">The head of the linked list to inspect.</param>
        /// <returns>The node where the cycle starts, or <see langword="null"/> if the list has no cycle.</returns>
        public ListNode DetectCycle(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    var entry = head;
                    while (entry != slow)
                    {
                        entry = entry.next;
                        slow = slow.next;
                    }

                    return entry;
                }
            }

            return null;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reorder-list/">143. Reorder List (medium)</a>
        /// Reorders a list in-place from L0→L1→...→Ln into L0→Ln→L1→Ln-1→... order.
        /// </summary>
        /// <param name="head">The head of the linked list to reorder.</param>
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return;
            }

            var slow = head;
            var fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var second = slow.next;
            slow.next = null;

            ListNode previous = null;
            while (second != null)
            {
                var next = second.next;
                second.next = previous;
                previous = second;
                second = next;
            }

            var first = head;
            second = previous;
            while (second != null)
            {
                var firstNext = first.next;
                var secondNext = second.next;
                first.next = second;
                second.next = firstNext;
                first = firstNext;
                second = secondNext;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/insertion-sort-list/">147. Insertion Sort List (medium)</a>
        /// Sorts a singly linked list with insertion sort by relinking nodes in nondecreasing order.
        /// </summary>
        /// <param name="head">The head of the linked list to sort.</param>
        /// <returns>The head of the sorted linked list.</returns>
        public ListNode InsertionSortList(ListNode head)
        {
            var dummy = new ListNode();
            var current = head;

            while (current != null)
            {
                var next = current.next;
                var previous = dummy;
                while (previous.next != null && previous.next.val < current.val)
                {
                    previous = previous.next;
                }

                current.next = previous.next;
                previous.next = current;
                current = next;
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sort-list/">148. Sort List (medium)</a>
        /// Sorts a singly linked list in O(n log n) time by splitting and merge-sorting the nodes.
        /// </summary>
        /// <param name="head">The head of the linked list to sort.</param>
        /// <returns>The head of the sorted linked list.</returns>
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var slow = head;
            var fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var right = slow.next;
            slow.next = null;
            return MergeSortedLists(SortList(head), SortList(right));
        }

        private ListNode MergeSortedLists(ListNode left, ListNode right)
        {
            var dummy = new ListNode();
            var current = dummy;

            while (left != null && right != null)
            {
                if (left.val <= right.val)
                {
                    current.next = left;
                    left = left.next;
                }
                else
                {
                    current.next = right;
                    right = right.next;
                }

                current = current.next;
            }

            current.next = left ?? right;
            return dummy.next;
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
        /// <a href="https://leetcode.com/problems/palindrome-linked-list/">234. Palindrome Linked List (easy)</a>
        /// Determines whether the linked-list values read the same forward and backward.
        /// </summary>
        /// <param name="head">The head of the linked list to inspect.</param>
        /// <returns><see langword="true"/> when the list is empty or forms a palindrome; otherwise, <see langword="false"/>.</returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            var slow = head;
            var fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var secondHalf = ReverseListInPlace(slow.next);
            var currentFirst = head;
            var currentSecond = secondHalf;
            var isPalindrome = true;
            while (currentSecond != null)
            {
                if (currentFirst.val != currentSecond.val)
                {
                    isPalindrome = false;
                    break;
                }

                currentFirst = currentFirst.next;
                currentSecond = currentSecond.next;
            }

            slow.next = ReverseListInPlace(secondHalf);
            return isPalindrome;
        }

        private ListNode ReverseListInPlace(ListNode head)
        {
            ListNode previous = null;
            while (head != null)
            {
                var next = head.next;
                head.next = previous;
                previous = head;
                head = next;
            }

            return previous;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-node-in-a-linked-list/">237. Delete Node in a Linked List (medium)</a>
        /// Deletes the given non-tail node from a singly linked list when only that node is provided.
        /// </summary>
        /// <param name="node">The non-tail linked-list node to remove.</param>
        public void DeleteNode(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return;
            }

            node.val = node.next.val;
            node.next = node.next.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/odd-even-linked-list/">328. Odd Even Linked List (medium)</a>
        /// Groups nodes at odd indices before nodes at even indices while preserving each group's relative order.
        /// </summary>
        /// <param name="head">The head of the linked list to reorder.</param>
        /// <returns>The head of the reordered linked list.</returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var odd = head;
            var even = head.next;
            var evenHead = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
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

        /// <summary>
        /// <a href="https://leetcode.com/problems/add-two-numbers-ii/">445. Add Two Numbers II (medium)</a>
        /// Adds two non-negative integers stored in forward-order linked lists without modifying the input lists.
        /// </summary>
        /// <param name="l1">The head of the first forward-order digit list.</param>
        /// <param name="l2">The head of the second forward-order digit list.</param>
        /// <returns>The head of a linked list representing the summed value in forward order.</returns>
        public ListNode AddTwoNumbersII(ListNode l1, ListNode l2)
        {
            var first = new Stack<int>();
            var second = new Stack<int>();

            while (l1 != null)
            {
                first.Push(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                second.Push(l2.val);
                l2 = l2.next;
            }

            ListNode head = null;
            var carry = 0;
            while (first.Count > 0 || second.Count > 0 || carry != 0)
            {
                var sum = carry;
                if (first.Count > 0)
                {
                    sum += first.Pop();
                }

                if (second.Count > 0)
                {
                    sum += second.Pop();
                }

                head = new ListNode(sum % 10, head);
                carry = sum / 10;
            }

            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/split-linked-list-in-parts/">725. Split Linked List in Parts (medium)</a>
        /// Splits a linked list into k consecutive parts whose sizes differ by at most one, with earlier parts receiving extra nodes.
        /// </summary>
        /// <param name="head">The head of the linked list to split.</param>
        /// <param name="k">The number of parts to create.</param>
        /// <returns>An array containing the head node for each part, or <see langword="null"/> for empty parts.</returns>
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            var result = new ListNode[k];
            var length = 0;
            var current = head;
            while (current != null)
            {
                length++;
                current = current.next;
            }

            var baseSize = length / k;
            var extras = length % k;
            current = head;
            for (var part = 0; part < k; part++)
            {
                result[part] = current;
                var partSize = baseSize + (part < extras ? 1 : 0);
                for (var i = 1; i < partSize; i++)
                {
                    current = current.next;
                }

                if (current != null)
                {
                    var next = current.next;
                    current.next = null;
                    current = next;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/linked-list-components/">817. Linked List Components (medium)</a>
        /// Counts connected components whose node values belong to the supplied subset.
        /// </summary>
        /// <param name="head">The head of the linked list containing unique values.</param>
        /// <param name="nums">The values that may form connected components.</param>
        /// <returns>The number of maximal connected runs made only of values from <paramref name="nums"/>.</returns>
        public int NumComponents(ListNode head, int[] nums)
        {
            var values = new HashSet<int>(nums);
            var components = 0;
            var inComponent = false;

            while (head != null)
            {
                if (values.Contains(head.val))
                {
                    if (!inComponent)
                    {
                        components++;
                        inComponent = true;
                    }
                }
                else
                {
                    inComponent = false;
                }

                head = head.next;
            }

            return components;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/middle-of-the-linked-list/">876. Middle of the Linked List (easy)</a>
        /// Finds the middle node of a singly linked list, choosing the second middle node when the length is even.
        /// </summary>
        /// <param name="head">The head of the linked list.</param>
        /// <returns>The middle node, or <see langword="null"/> when the list is empty.</returns>
        public ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/next-greater-node-in-linked-list/">1019. Next Greater Node In Linked List (medium)</a>
        /// Finds the next node value greater than each linked-list node value.
        /// </summary>
        /// <param name="head">The head of the linked list to inspect.</param>
        /// <returns>An array where each position contains the next greater value to the right, or 0 when none exists.</returns>
        public int[] NextLargerNodes(ListNode head)
        {
            var values = new List<int>();
            for (var current = head; current != null; current = current.next)
            {
                values.Add(current.val);
            }

            var result = new int[values.Count];
            var stack = new Stack<int>();
            for (var i = 0; i < values.Count; i++)
            {
                while (stack.Count > 0 && values[i] > values[stack.Peek()])
                {
                    result[stack.Pop()] = values[i];
                }

                stack.Push(i);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list/">1171. Remove Zero Sum Consecutive Nodes from Linked List (medium)</a>
        /// Removes every consecutive sequence of nodes whose values sum to zero.
        /// </summary>
        /// <param name="head">The head of the linked list to simplify.</param>
        /// <returns>The head of the list after all zero-sum consecutive ranges are removed.</returns>
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            var dummy = new ListNode(0, head);
            var prefixToNode = new Dictionary<int, ListNode>();
            var prefix = 0;

            for (var current = dummy; current != null; current = current.next)
            {
                prefix += current.val;
                prefixToNode[prefix] = current;
            }

            prefix = 0;
            for (var current = dummy; current != null; current = current.next)
            {
                prefix += current.val;
                current.next = prefixToNode[prefix].next;
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/">1290. Convert Binary Number in a Linked List to Integer (easy)</a>
        /// Converts a linked-list binary representation into its integer value.
        /// </summary>
        /// <param name="head">The head of a linked list whose values are binary digits ordered from most to least significant.</param>
        /// <returns>The decimal value represented by the linked list, or 0 for an empty list.</returns>
        public int GetDecimalValue(ListNode head)
        {
            var value = 0;
            while (head != null)
            {
                value = (value << 1) | head.val;
                head = head.next;
            }

            return value;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/linked-list-in-binary-tree/">1367. Linked List in Binary Tree (medium)</a>
        /// Determines whether a linked list appears as a downward path in a binary tree.
        /// </summary>
        /// <param name="head">The head of the linked-list sequence to find.</param>
        /// <param name="root">The root of the binary tree to search.</param>
        /// <returns><see langword="true"/> if any downward tree path matches the linked list; otherwise, <see langword="false"/>.</returns>
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null)
            {
                return true;
            }

            if (root == null)
            {
                return false;
            }

            return IsMatchingPath(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
        }

        private bool IsMatchingPath(ListNode head, TreeNode root)
        {
            if (head == null)
            {
                return true;
            }

            if (root == null || root.val != head.val)
            {
                return false;
            }

            return IsMatchingPath(head.next, root.left) || IsMatchingPath(head.next, root.right);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-n-nodes-after-m-nodes-of-a-linked-list/">1474. Delete N Nodes After M Nodes of a Linked List (easy)</a>
        /// Keeps m nodes, deletes the next n nodes, and repeats until the linked list ends.
        /// </summary>
        /// <param name="head">The head of the linked list to edit.</param>
        /// <param name="m">The number of consecutive nodes to keep in each cycle.</param>
        /// <param name="n">The number of consecutive nodes to delete after each kept group.</param>
        /// <returns>The head of the linked list after applying the keep/delete pattern.</returns>
        public ListNode DeleteNodes(ListNode head, int m, int n)
        {
            var current = head;
            while (current != null)
            {
                for (var kept = 1; kept < m && current != null; kept++)
                {
                    current = current.next;
                }

                if (current == null)
                {
                    break;
                }

                var next = current.next;
                for (var deleted = 0; deleted < n && next != null; deleted++)
                {
                    next = next.next;
                }

                current.next = next;
                current = next;
            }

            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-in-between-linked-lists/">1669. Merge In Between Linked Lists (medium)</a>
        /// Replaces nodes from position a through b in the first list with the entire second list.
        /// </summary>
        /// <param name="list1">The head of the list containing the inclusive replacement range.</param>
        /// <param name="a">The zero-based start index of the range to remove from <paramref name="list1"/>.</param>
        /// <param name="b">The zero-based end index of the range to remove from <paramref name="list1"/>.</param>
        /// <param name="list2">The head of the list to splice into <paramref name="list1"/>.</param>
        /// <returns>The head of the merged list.</returns>
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var before = list1;
            for (var index = 0; index < a - 1; index++)
            {
                before = before.next;
            }

            var after = before.next;
            for (var index = a; index <= b; index++)
            {
                after = after.next;
            }

            before.next = list2;
            var tail = list2;
            while (tail.next != null)
            {
                tail = tail.next;
            }

            tail.next = after;
            return list1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/swapping-nodes-in-a-linked-list/">1721. Swapping Nodes in a Linked List (medium)</a>
        /// Swaps the values of the kth node from the start and the kth node from the end.
        /// </summary>
        /// <param name="head">The head of the linked list to update.</param>
        /// <param name="k">The one-based node position from both ends.</param>
        /// <returns>The head of the linked list after swapping the two node values.</returns>
        public ListNode SwapNodes(ListNode head, int k)
        {
            if (head == null || k <= 0)
            {
                return head;
            }

            var lead = head;
            for (var index = 1; index < k && lead != null; index++)
            {
                lead = lead.next;
            }

            if (lead == null)
            {
                return head;
            }

            var kthFromStart = lead;
            var kthFromEnd = head;
            while (lead.next != null)
            {
                lead = lead.next;
                kthFromEnd = kthFromEnd.next;
            }

            (kthFromStart.val, kthFromEnd.val) = (kthFromEnd.val, kthFromStart.val);
            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/">2058. Find the Minimum and Maximum Number of Nodes Between Critical Points (medium)</a>
        /// Finds the minimum and maximum distances between local minima or maxima in a linked list.
        /// </summary>
        /// <param name="head">The head of the linked list to inspect.</param>
        /// <returns>An array containing the minimum and maximum critical-point distances, or [-1, -1] if fewer than two exist.</returns>
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return new[] { -1, -1 };
            }

            var previous = head;
            var current = head.next;
            var index = 1;
            var firstCritical = -1;
            var lastCritical = -1;
            var minimumDistance = int.MaxValue;

            while (current.next != null)
            {
                var isCritical = (current.val > previous.val && current.val > current.next.val)
                    || (current.val < previous.val && current.val < current.next.val);
                if (isCritical)
                {
                    if (firstCritical == -1)
                    {
                        firstCritical = index;
                    }
                    else
                    {
                        minimumDistance = Math.Min(minimumDistance, index - lastCritical);
                    }

                    lastCritical = index;
                }

                previous = current;
                current = current.next;
                index++;
            }

            if (minimumDistance == int.MaxValue)
            {
                return new[] { -1, -1 };
            }

            return new[] { minimumDistance, lastCritical - firstCritical };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-nodes-in-even-length-groups/">2074. Reverse Nodes in Even Length Groups (medium)</a>
        /// Splits nodes into increasing-size groups and reverses only groups whose actual length is even.
        /// </summary>
        /// <param name="head">The head of the linked list to reorder.</param>
        /// <returns>The head of the linked list after reversing each even-length group.</returns>
        public ListNode ReverseEvenLengthGroups(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var previousGroupTail = head;
            var current = head.next;
            var groupSize = 2;
            while (current != null)
            {
                var count = 0;
                var nextGroupHead = current;
                while (count < groupSize && nextGroupHead != null)
                {
                    nextGroupHead = nextGroupHead.next;
                    count++;
                }

                if (count % 2 == 0)
                {
                    ListNode previous = nextGroupHead;
                    var node = current;
                    for (var index = 0; index < count; index++)
                    {
                        var next = node.next;
                        node.next = previous;
                        previous = node;
                        node = next;
                    }

                    previousGroupTail.next = previous;
                    previousGroupTail = current;
                }
                else
                {
                    previousGroupTail = current;
                    for (var index = 1; index < count; index++)
                    {
                        previousGroupTail = previousGroupTail.next;
                    }
                }

                current = nextGroupHead;
                groupSize++;
            }

            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/">2095. Delete the Middle Node of a Linked List (medium)</a>
        /// Deletes the middle node, choosing index n/2 for a zero-based list of length n.
        /// </summary>
        /// <param name="head">The head of the linked list to update.</param>
        /// <returns>The head of the linked list after removing the middle node.</returns>
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            var dummy = new ListNode(0, head);
            var slow = dummy;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            slow.next = slow.next.next;
            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/">2130. Maximum Twin Sum of a Linked List (medium)</a>
        /// Computes the largest sum of paired nodes equidistant from the start and end of an even-length list.
        /// </summary>
        /// <param name="head">The head of the even-length linked list.</param>
        /// <returns>The maximum twin sum across all symmetric node pairs.</returns>
        public int PairSum(ListNode head)
        {
            if (head == null)
            {
                return 0;
            }

            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var secondHalf = ReverseListInPlace(slow);
            var secondCurrent = secondHalf;
            var firstCurrent = head;
            var maximum = 0;
            while (secondCurrent != null)
            {
                maximum = Math.Max(maximum, firstCurrent.val + secondCurrent.val);
                firstCurrent = firstCurrent.next;
                secondCurrent = secondCurrent.next;
            }

            ReverseListInPlace(secondHalf);
            return maximum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-nodes-in-between-zeros/">2181. Merge Nodes in Between Zeros (medium)</a>
        /// Replaces each run of nonzero nodes between delimiter zeros with one node containing the run sum.
        /// </summary>
        /// <param name="head">The head of a linked list that starts and ends with zero delimiter nodes.</param>
        /// <returns>The head of the summed linked list without delimiter zeros.</returns>
        public ListNode MergeNodes(ListNode head)
        {
            var dummy = new ListNode();
            var tail = dummy;
            var sum = 0;

            for (var current = head?.next; current != null; current = current.next)
            {
                if (current.val == 0)
                {
                    tail.next = new ListNode(sum);
                    tail = tail.next;
                    sum = 0;
                }
                else
                {
                    sum += current.val;
                }
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/spiral-matrix-iv/">2326. Spiral Matrix IV (medium)</a>
        /// Fills an m-by-n matrix in spiral order with linked-list values and leaves unused cells as -1.
        /// </summary>
        /// <param name="m">The number of matrix rows.</param>
        /// <param name="n">The number of matrix columns.</param>
        /// <param name="head">The head of the linked list supplying values in order.</param>
        /// <returns>A jagged matrix filled in spiral order from the linked list.</returns>
        public int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            var matrix = new int[m][];
            for (var row = 0; row < m; row++)
            {
                matrix[row] = new int[n];
                Array.Fill(matrix[row], -1);
            }

            var directions = new[] { (Row: 0, Column: 1), (Row: 1, Column: 0), (Row: 0, Column: -1), (Row: -1, Column: 0) };
            var direction = 0;
            var currentRow = 0;
            var currentColumn = 0;

            while (head != null)
            {
                matrix[currentRow][currentColumn] = head.val;
                head = head.next;

                var nextRow = currentRow + directions[direction].Row;
                var nextColumn = currentColumn + directions[direction].Column;
                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n || matrix[nextRow][nextColumn] != -1)
                {
                    direction = (direction + 1) % directions.Length;
                    nextRow = currentRow + directions[direction].Row;
                    nextColumn = currentColumn + directions[direction].Column;
                }

                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n || matrix[nextRow][nextColumn] != -1)
                {
                    break;
                }

                currentRow = nextRow;
                currentColumn = nextColumn;
            }

            return matrix;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-nodes-from-linked-list/">2487. Remove Nodes From Linked List (medium)</a>
        /// Removes every node that has a strictly greater value somewhere to its right.
        /// </summary>
        /// <param name="head">The head of the linked list to filter.</param>
        /// <returns>The head of the linked list after removing dominated nodes.</returns>
        public ListNode RemoveNodes(ListNode head)
        {
            var reversed = ReverseListInPlace(head);
            var dummy = new ListNode();
            var tail = dummy;
            var maximum = int.MinValue;

            while (reversed != null)
            {
                var next = reversed.next;
                if (reversed.val >= maximum)
                {
                    maximum = reversed.val;
                    tail.next = reversed;
                    tail = reversed;
                }

                reversed = next;
            }

            tail.next = null;
            return ReverseListInPlace(dummy.next);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/insert-greatest-common-divisors-in-linked-list/">2807. Insert Greatest Common Divisors in Linked List (medium)</a>
        /// Inserts a new node between every adjacent pair containing the greatest common divisor of that pair's values.
        /// </summary>
        /// <param name="head">The head of the linked list to augment.</param>
        /// <returns>The head of the linked list after inserting greatest-common-divisor nodes.</returns>
        public ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            var current = head;
            while (current?.next != null)
            {
                current.next = new ListNode(GreatestCommonDivisor(current.val, current.next.val), current.next);
                current = current.next.next;
            }

            return head;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/">2816. Double a Number Represented as a Linked List (medium)</a>
        /// Doubles a non-negative integer whose digits are stored from most significant to least significant in a linked list.
        /// </summary>
        /// <param name="head">The head of the forward-order digit list.</param>
        /// <returns>The head of the linked list representing twice the input number.</returns>
        public ListNode DoubleIt(ListNode head)
        {
            var reversed = ReverseListInPlace(head);
            var current = reversed;
            var carry = 0;
            ListNode tail = null;

            while (current != null)
            {
                var doubled = (current.val * 2) + carry;
                current.val = doubled % 10;
                carry = doubled / 10;
                tail = current;
                current = current.next;
            }

            if (carry != 0)
            {
                tail.next = new ListNode(carry);
            }

            return ReverseListInPlace(reversed);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array/">3217. Delete Nodes From Linked List Present in Array (medium)</a>
        /// Removes every linked-list node whose value appears in the supplied array.
        /// </summary>
        /// <param name="nums">The values to delete from the linked list.</param>
        /// <param name="head">The head of the linked list to filter.</param>
        /// <returns>The head of the linked list after removing matching nodes.</returns>
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            var removedValues = new HashSet<int>(nums);
            var dummy = new ListNode(0, head);
            var previous = dummy;
            var current = head;

            while (current != null)
            {
                if (removedValues.Contains(current.val))
                {
                    previous.next = current.next;
                }
                else
                {
                    previous = current;
                }

                current = current.next;
            }

            return dummy.next;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-pair-removal-to-sort-array-i/">3507. Minimum Pair Removal to Sort Array I (easy)</a>
        /// <a href="https://leetcode.com/problems/minimum-pair-removal-to-sort-array-ii/">3510. Minimum Pair Removal to Sort Array II (hard)</a>
        /// Counts the required operations when repeatedly replacing the leftmost adjacent pair with minimum sum until the array is non-decreasing.
        /// </summary>
        /// <param name="nums">The array to transform by mandatory minimum-sum adjacent-pair replacements.</param>
        /// <returns>The number of pair-replacement operations needed to make the array non-decreasing.</returns>
        public int MinimumPairRemoval(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return 0;
            }

            var values = new long[nums.Length];
            var previous = new int[nums.Length];
            var next = new int[nums.Length];
            var alive = new bool[nums.Length];
            var queue = new PriorityQueue<PairRemovalEdge, (long Sum, int Left)>();
            var inversions = 0;

            for (var index = 0; index < nums.Length; index++)
            {
                values[index] = nums[index];
                previous[index] = index - 1;
                next[index] = index + 1 < nums.Length ? index + 1 : -1;
                alive[index] = true;

                if (index > 0 && values[index - 1] > values[index])
                {
                    inversions++;
                }
            }

            for (var index = 0; index < nums.Length - 1; index++)
            {
                EnqueuePair(queue, values, index, next[index]);
            }

            var operations = 0;
            while (inversions > 0)
            {
                var edge = DequeueValidPair(queue, values, next, alive);
                var left = edge.Left;
                var right = edge.Right;
                var before = previous[left];
                var after = next[right];

                inversions -= IsInversion(values, before, left) ? 1 : 0;
                inversions -= values[left] > values[right] ? 1 : 0;
                inversions -= IsInversion(values, right, after) ? 1 : 0;

                values[left] += values[right];
                next[left] = after;
                if (after != -1)
                {
                    previous[after] = left;
                }

                alive[right] = false;
                operations++;

                inversions += IsInversion(values, before, left) ? 1 : 0;
                inversions += IsInversion(values, left, after) ? 1 : 0;

                if (before != -1)
                {
                    EnqueuePair(queue, values, before, left);
                }

                if (after != -1)
                {
                    EnqueuePair(queue, values, left, after);
                }
            }

            return operations;
        }

        private static int GreatestCommonDivisor(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);
            while (second != 0)
            {
                var remainder = first % second;
                first = second;
                second = remainder;
            }

            return first;
        }

        private static bool IsInversion(long[] values, int left, int right)
        {
            return left != -1 && right != -1 && values[left] > values[right];
        }

        private static void EnqueuePair(PriorityQueue<PairRemovalEdge, (long Sum, int Left)> queue, long[] values, int left, int right)
        {
            var sum = values[left] + values[right];
            queue.Enqueue(new PairRemovalEdge(left, right, sum), (sum, left));
        }

        private static PairRemovalEdge DequeueValidPair(
            PriorityQueue<PairRemovalEdge, (long Sum, int Left)> queue,
            long[] values,
            int[] next,
            bool[] alive)
        {
            while (queue.Count > 0)
            {
                var edge = queue.Dequeue();
                if (alive[edge.Left] && alive[edge.Right] && next[edge.Left] == edge.Right && values[edge.Left] + values[edge.Right] == edge.Sum)
                {
                    return edge;
                }
            }

            return default;
        }

        private readonly struct PairRemovalEdge
        {
            public PairRemovalEdge(int left, int right, long sum)
            {
                Left = left;
                Right = right;
                Sum = sum;
            }

            public int Left { get; }

            public int Right { get; }

            public long Sum { get; }
        }
    }
}
