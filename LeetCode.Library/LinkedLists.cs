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

    public class LinkedLists
    {
        /// <summary>
        /// 21. Merge Two Sorted Lists (easy)
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
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
        /// 83. Remove Duplicates from Sorted List (easy)
        /// Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
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
        /// 203. Remove Linked List Elements (easy)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
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
        /// 206. Reverse Linked List (easy)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>

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
    }
}
